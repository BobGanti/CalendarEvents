using CalendarEvents.Models.SMs;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarEvents.Models.Objs
{
    public class Event : EventSM
    {
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

    }
}
