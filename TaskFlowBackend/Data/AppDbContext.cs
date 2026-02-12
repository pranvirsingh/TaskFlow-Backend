using Microsoft.EntityFrameworkCore;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsActive)
                      .HasDefaultValue(true);

                entity.Property(e => e.IsDeleted)
                      .HasDefaultValue(false);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("NOW()");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.IsActive)
                      .HasDefaultValue(true);

                entity.Property(e => e.IsDeleted)
                      .HasDefaultValue(false);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("NOW()");
            });

        }

    }
}
