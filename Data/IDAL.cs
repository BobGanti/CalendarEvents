using CalendarEvents.Models.Objs;

namespace CalendarEvents.Data
{
    public interface IDAL
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocation(int id);
        Task<Location> UpdateLocation(Location obj);
        Task<Location> AddLocation(Location obj);
        Task<Location> DeleteLocation(int id);

        /*
         * Events
         */
        IEnumerable<Event> GetAllEvents();
        Event GetEvent(int id);
        Task<Event> UpdateEvent(Event obj);
        Task<Event> AddEvent(Event obj);
        Task<Event> DeleteEvent(int id);
    }
}
