using System;
using Notes.Domain;
using Notes.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Notes.Tests.Common
{
    public static class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();




        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();

            context.Notes.AddRange(
                new Note
                {
                    Id = Guid.Parse("3CF21ABD-1B50-4E69-A079-106A3E2CE5ED"),
                    UserId = UserAId,
                    Title = "Note_1",
                    Details = "Details_1",
                    CreationDate = DateTime.Now,
                    EditDate = null
                },
                new Note
                {
                    Id = Guid.Parse("CCAE8C0F-87F1-4CA6-AB3A-70335D7D3450"),
                    UserId = UserBId,
                    Title = "Note_2",
                    Details = "Details_2",
                    CreationDate = DateTime.Now,
                    EditDate = null
                },
                new Note
                {
                    Id = NoteIdForDelete,
                    UserId = UserAId,
                    Title = "Note_3",
                    Details = "Details_3",
                    CreationDate = DateTime.Now,
                    EditDate = null
                },
                new Note
                {
                    Id = NoteIdForUpdate,
                    UserId = UserBId,
                    Title = "Note_4",
                    Details = "Details_4",
                    CreationDate = DateTime.Today,
                    EditDate = null
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
