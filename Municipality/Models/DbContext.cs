using Microsoft.EntityFrameworkCore;
using Municipality.Models;

namespace Municipality
{
    public class MunicipalServicesDbContext : DbContext
    {
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<EventAnnouncement> EventAnnouncements { get; set; }

        public MunicipalServicesDbContext(DbContextOptions<MunicipalServicesDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Recommended: Configure only if options aren't provided by DI
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=municipal_services.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If EventAnnouncement maps to a view/query without a key:
            // modelBuilder.Entity<EventAnnouncement>().HasNoKey();
            // Optionally, add: .ToView("EventAnnouncementsView") if mapping to a DB view
        }
    }
}
