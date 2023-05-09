using CalendarEvents.Models.Objs;

using Location = CalendarEvents.Models.Objs.Location;

namespace CalendarEvents.Data
{
    public class DAL : IDAL
    {
        private readonly CalendarEventsContext _context;

        public DAL(CalendarEventsContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations;
        }

        public Location GetLocation(int id)
        {
            return _context.Locations.Find(id);
        }

        public async Task<Location> UpdateLocation(Location location)
        {
            var locationInDb = _context.Locations.Attach(location);
            locationInDb.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }
        public async Task<Location> AddLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }
        public async Task<Location> DeleteLocation(int id)
        {
            Location location = _context.Locations.Find(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
            return location;
        }

        // Get All Events
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events;
        }

        // Get an Event
        public Event GetEvent(int id)
        {
            return _context.Events.Find(id);
        }

        // Edit Event
        public async Task<Event> UpdateEvent(Event obj)
        {
            var eventInDb = _context.Events.Attach(obj);
            //eventInDb.State = System.Data.Entity.EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
      
        // Add Event
        public async Task<Event> AddEvent(Event obj)
        {
            _context.Events.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        // Delete Event
        public async Task<Event> DeleteEvent(int id)
        {
            var eventInDb = _context.Events.Find(id);
                               
            _context.Events.Remove(eventInDb);
            await _context.SaveChangesAsync();

            return eventInDb;
        }
    }
}
