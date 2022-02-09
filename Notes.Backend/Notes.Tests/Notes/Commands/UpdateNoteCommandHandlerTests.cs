using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Domain;
using Notes.Tests.Common;
using Notes.Application.Common.Exceptions;

namespace Notes.Tests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(context);
            var noteId = NotesContextFactory.NoteIdForUpdate;
            var noteUserId = NotesContextFactory.UserBId;
            var updatedTitle = "New title for note";
            var updatedDetails = "New details for note";


            // Act
            await handler.Handle(new UpdateNoteCommand()
            {
                Id = noteId,
                UserId = noteUserId,
                Title = updatedTitle,
                Details = updatedDetails
            },
            CancellationToken.None);


            // Assert
            Assert.NotNull(await context.Notes.SingleOrDefaultAsync(note =>
                   note.Id == noteId
                && note.UserId == noteUserId
                && note.Title == updatedTitle
                && note.Details == updatedDetails));

        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(context);
            var wrongNoteId = Guid.NewGuid();
            var noteUserId = NotesContextFactory.UserBId;


            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateNoteCommand()
                    {
                        Id = wrongNoteId,
                        UserId = noteUserId,
                    },
                    CancellationToken.None);
            });
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(context);
            var noteId = NotesContextFactory.NoteIdForUpdate;
            var wrongUserId = NotesContextFactory.UserAId;

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateNoteCommand()
                    {
                        Id = noteId,
                        UserId = wrongUserId,
                    },
                    CancellationToken.None);
            });
        }
    }
}
