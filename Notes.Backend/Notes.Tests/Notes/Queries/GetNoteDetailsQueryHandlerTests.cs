using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Shouldly;
using Notes.Persistence;
using AutoMapper;
using Notes.Tests.Common;
using Notes.Application.Notes.Queries.GetNoteDetails;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext context;
        private readonly IMapper mapper;


        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteDetailsQueryHandler(context, mapper);
            var noteId = NotesContextFactory.NoteIdForUpdate;
            var noteUserId = NotesContextFactory.UserBId;

            // Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    Id = noteId,
                    UserId = noteUserId
                },
                CancellationToken.None);


            // Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Note_4");
            result.Detail.ShouldBe("Details_4");
            result.CreationDate.ShouldBe(DateTime.Today);
            result.EditDate.ShouldBe(null);
            
        }
    }
}
