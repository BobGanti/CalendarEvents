using CalendarEvents.Models.Objs;
using CalendarEvents.Models.SMs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalendarEvents.Models.VMs
{
    public class EventVM : EventSM
    {
        public EventVM() { }

        public EventVM(Event obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            Description = obj.Description;
            StartTime = obj.StartTime;
            EndTime = obj.EndTime;
            LocationId = obj.LocationId;
            LocationName = obj.LocationName;
        }

        public virtual IEnumerable<SelectListItem> Locations { get; set; }
    }
}
