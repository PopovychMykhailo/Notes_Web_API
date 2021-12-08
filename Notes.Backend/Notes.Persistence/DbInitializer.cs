namespace Notes.Persistence
{
    // DbInitializer - to ensure the created database.

    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
