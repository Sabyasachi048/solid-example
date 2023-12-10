using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SolidExample.Models.Entities;

namespace SolidExample.Models
{
    public interface ISolidExampleDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
