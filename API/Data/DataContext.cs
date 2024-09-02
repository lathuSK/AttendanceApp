using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); 
                entity.Property(u => u.Username).IsRequired();
                entity.Property(u => u.Name).IsRequired();
                entity.Property(u => u.Department).IsRequired();
                entity.Property(u => u.JobId).IsRequired(); 
            });
        }
    }
}
