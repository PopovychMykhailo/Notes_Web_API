using System;
using Notes.Tests.Common;
using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.DeleteNote;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.Tests.Notes.Commands
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(context);
            var noteId = NotesContextFactory.NoteIdForDelete;
            var noteUserId = NotesContextFactory.UserAId;

            // Act
            await handler.Handle(
                new DeleteNoteCommand()
                {
                    Id = noteId,
                    UserId = noteUserId
                },
                CancellationToken.None);

            // Assert
            Assert.Null(await context.Notes.SingleOrDefaultAsync(note => 
                note.Id == noteId));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(context);
            var noteId = Guid.NewGuid();
            var noteUserId = NotesContextFactory.UserAId;

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteNoteCommand()
                    {
                        Id = noteId,
                        UserId = noteUserId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteNoteCommandHandler(context);
            var anotherUserId = NotesContextFactory.UserBId;
            var noteId = NotesContextFactory.NoteIdForDelete;

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => 
                await deleteHandler.Handle(
                    new DeleteNoteCommand()
                    {
                        Id = noteId,
                        UserId = anotherUserId
                    },
                    CancellationToken.None));
        }
    }
}
