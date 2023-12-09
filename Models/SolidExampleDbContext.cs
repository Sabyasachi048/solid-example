using Microsoft.EntityFrameworkCore;
using SolidExample.Models.Entities;

namespace SolidExample.Models
{
    public class SolidExampleDbContext : DbContext, ISolidExampleDbContext
    {
        public SolidExampleDbContext(DbContextOptions options) 
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("SolidExampleDbContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors");

                entity.HasMany(d => d.Articles)
                    .WithOne(p => p.Author)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Articles");

                entity.HasOne(d => d.Author)
                    .WithMany(p =>  p.Articles)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
