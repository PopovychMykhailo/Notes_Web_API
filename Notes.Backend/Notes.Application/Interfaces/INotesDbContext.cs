using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { set; get; }
        DbSet<ApiVersion> ApiVersions { set; get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
