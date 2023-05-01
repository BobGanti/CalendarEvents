using CalendarEvents.Models.Objs;
using System.Text.Json;

namespace CalendarEvents.Helpers
{
    public static class JsonListHelper
    {
        public static string GetEventListJsonString(List<Event> eventObjs)
        {
            var calendarEventList = new List<CalendarEvent>();
            foreach (var eventObj in eventObjs)
            {
                var calendarEvent = new CalendarEvent
                {
                    id = eventObj.Id,
                    title = eventObj.Name,
                    start = eventObj.StartTime,
                    end = eventObj.EndTime,
                    resourceId = eventObj.Location.Id,
                    locationName = eventObj.Location.Name,
                    description = eventObj.Description
                };
                
                calendarEventList.Add(calendarEvent);
            }
            return JsonSerializer.Serialize(calendarEventList);
        }

        public static string GetResourceListJsonString(List<Location> locations)
        {
            var resourceList = new List<Resource>();
            foreach (var location in locations)
            {
                var resource = new Resource
                {
                    id = location.Id,
                    title = location.Name
                };
                resourceList.Add(resource);
            }
            return JsonSerializer.Serialize(resourceList);
        }
    }

    public class CalendarEvent
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end{ get; set; }
        public int resourceId { get; set; }
        public string locationName { get; set; }
        public string description { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
