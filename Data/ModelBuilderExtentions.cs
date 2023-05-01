using CalendarEvents.Models.Objs;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CalendarEvents.Data
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Loc 1",
                },
                new Location
                {
                    Id = 2,
                    Name = "Loc 2",
                },
                new Location
                {
                    Id = 3,
                    Name = "Loc 3",
                },
                new Location
                {
                    Id = 4,
                    Name = "Loc 4",
                },
                new Location
                {
                    Id = 5,
                    Name = "Loc 5",
                }
            ); ;
        }
    }
}
