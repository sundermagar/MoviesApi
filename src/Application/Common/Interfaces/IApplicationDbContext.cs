using SunderTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SunderTest.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Genre> Genres { get; set; }
        DbSet<Movie> Movies { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
