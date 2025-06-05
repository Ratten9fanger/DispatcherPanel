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
    }
}
