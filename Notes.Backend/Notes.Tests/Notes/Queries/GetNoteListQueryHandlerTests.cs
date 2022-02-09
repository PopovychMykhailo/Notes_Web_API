using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Threading;
using AutoMapper;

using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Persistence;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        private readonly NotesDbContext context;
        private readonly IMapper mapper;


        public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }


        [Fact]
        public async void GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteListQueryHandler(context, mapper);
            var userId = NotesContextFactory.UserBId;

            // Act
            var result = await handler.Handle(
                new GetNoteListQuery()
                {
                    UserId = userId
                }, 
                CancellationToken.None);


            // Assert
            result.ShouldBeOfType<NoteListVm>();
            result.Notes.Count.ShouldBe(2);
        }
    }
}
