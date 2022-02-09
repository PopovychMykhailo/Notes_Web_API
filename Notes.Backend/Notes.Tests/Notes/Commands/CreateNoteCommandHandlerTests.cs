using System;
using Xunit;
using Notes.Tests.Common;
using System.Threading.Tasks;
using Notes.Application.Notes.Commands.CreateNote;
using System.Threading;
using Microsoft.EntityFrameworkCore;



namespace Notes.Tests.Notes.Commands
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateNoteCommandHandler(context);
            var noteTitle = "Test note title";
            var noteDetails = "Test note details";
            var noteUserId = NotesContextFactory.UserAId;

            // Act
            var noteId = await handler.Handle(
                new CreateNoteCommand
                {
                    Title = noteTitle,
                    Details = noteDetails,
                    UserId = noteUserId
                }, 
                CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Notes.SingleOrDefaultAsync(
                note => 
                    note.Id == noteId && 
                    note.Title == noteTitle && 
                    note.Details == noteDetails &&
                    note.UserId == noteUserId));

        }
    }
}
