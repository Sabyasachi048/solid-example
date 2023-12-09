using Microsoft.EntityFrameworkCore;
using SolidExample.Models.Entities;

namespace SolidExample.Models
{
    public interface ISolidExampleDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Article> Articles { get; set; }
    }
}
