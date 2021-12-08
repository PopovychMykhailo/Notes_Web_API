using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfigurations;


namespace Notes.Persistence
{
    // NotesDbContext - configuration of our entities (notes) for Entity Framework Core

    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<ApiVersion> ApiVersions { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            builder.ApplyConfiguration(new ApiVersionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
