using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CalendarEvents.Models.VMs;
using CalendarEvents.Data;
using CalendarEvents.Models.Objs;

namespace CalendarEvents.Controllers
{
    public class EventsController : Controller
    {
        private readonly IDAL _dal;

        public EventsController(IDAL dal)
        {
            _dal = dal;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var vms = _dal.GetAllEvents().ToArray()
                               .Select(c => new EventVM(c))
                               .ToList();
            return View(vms);

        }

        //GET: Events
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new EventVM();
            vm.StartTime = DateTime.Now;
            vm.EndTime = DateTime.Now + TimeSpan.FromDays(1);
            vm.Locations = new SelectList(_dal.GetAllLocations().ToList(), "Id", "Name");

            return View(vm);
        }


        // POST: Events
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventVM vm)
        {
            // vm.LocationName = await _context.Locations.FindAsync(vm.LocationId).Name;

            /* 
             if (!ModelState.IsValid)
             {
                 vm.Locations = new SelectList(_context.Locations.ToList(), "id", "Name");
                 ModelState.AddModelError("Error!", "Some values are missing!");
                 return View(vm);
             }
           */
            var obj = new Event
            {
                Name = vm.Name,
                Description = vm.Description,
                LocationId = vm.LocationId,
                StartTime = vm.StartTime,
                EndTime = vm.EndTime,
                LocationName = _dal.GetLocation(vm.LocationId).Name
            };

            _dal.AddEvent(obj);

            return RedirectToAction(nameof(Index));
        }
            /*
                    // GET: Events/Details/5
                    public async Task<IActionResult> Details(int? id)
                    {
                        if (id == null || _context.Events == null)
                        {
                            return NotFound();
                        }

                        var @event = await _context.Events
                            .Include(@ => @.Location)
                            .FirstOrDefaultAsync(m => m.id == id);
                        if (@event == null)
                        {
                            return NotFound();
                        }

                        return View(@event);
                    }

                    // GET: Events/Create
                    public IActionResult Create()
                    {
                        ViewData["LocationId"] = new SelectList(_context.Locations, "id", "id");
                        return View();
                    }

                    // POST: Events/Create
                    // To protect from overposting attacks, enable the specific properties you want to bind to.
                    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                    [HttpPost]
                    [ValidateAntiForgeryToken]
                    public async Task<IActionResult> Create([Bind("id,Name,description,StartTime,EndTime,LocationId,LocationName")] Event @event)
                    {
                        if (ModelState.IsValid)
                        {
                            _context.Add(@event);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["LocationId"] = new SelectList(_context.Locations, "id", "id", @event.LocationId);
                        return View(@event);
                    }

                    // GET: Events/Edit/5
                    public async Task<IActionResult> Edit(int? id)
                    {
                        if (id == null || _context.Events == null)
                        {
                            return NotFound();
                        }

                        var @event = await _context.Events.FindAsync(id);
                        if (@event == null)
                        {
                            return NotFound();
                        }
                        ViewData["LocationId"] = new SelectList(_context.Locations, "id", "id", @event.LocationId);
                        return View(@event);
                    }

                    // POST: Events/Edit/5
                    // To protect from overposting attacks, enable the specific properties you want to bind to.
                    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                    [HttpPost]
                    [ValidateAntiForgeryToken]
                    public async Task<IActionResult> Edit(int id, [Bind("id,Name,description,StartTime,EndTime,LocationId,LocationName")] Event @event)
                    {
                        if (id != @event.id)
                        {
                            return NotFound();
                        }

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                _context.Update(@event);
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!EventExists(@event.id))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            return RedirectToAction(nameof(Index));
                        }
                        ViewData["LocationId"] = new SelectList(_context.Locations, "id", "id", @event.LocationId);
                        return View(@event);
                    }

            

        }
        */
            // GET: Events/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || _dal.GetEvent(id) == null)
            {
                return NotFound();
            }

            _dal.DeleteEvent(id);

            return RedirectToAction("Index");
        }

            
    }
}
