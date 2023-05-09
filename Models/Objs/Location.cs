using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarEvents.Models.Objs
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}