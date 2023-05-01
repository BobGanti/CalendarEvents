using CalendarEvents.Models.Objs;
using Microsoft.EntityFrameworkCore;

namespace CalendarEvents.Data
{
    public class CalendarEventsContext : DbContext
    {
        public CalendarEventsContext(DbContextOptions<CalendarEventsContext> options) : base(options) 
        {
        }

        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Event> Events { get; set; }
    }
}
