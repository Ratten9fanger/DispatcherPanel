using Microsoft.EntityFrameworkCore;
using DispatcherPanel.Models;

namespace DispatcherPanel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<EmergencyRequest> EmergencyRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настраиваем типы для Latitude и Longitude
            modelBuilder.Entity<EmergencyRequest>(entity =>
            {
                entity.Property(e => e.Latitude)
                      .HasColumnType("decimal(9,6)");  // 9 цифр всего,Ы 6 после запятой

                entity.Property(e => e.Longitude)
                      .HasColumnType("decimal(9,6)");
            });
        }
    }
}
