using CalendarEvents.Data;
using CalendarEvents.Helpers;
using CalendarEvents.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web.Helpers;

namespace CalendarEvents.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDAL _dal;

        public HomeController(IDAL db)
        {
            _dal = db;
        }

        public IActionResult Index()
        {
            ViewData["Resources"] = JsonListHelper.GetResourceListJsonString(_dal.GetAllLocations().ToList());
            ViewData["Events"] = JsonListHelper.GetEventListJsonString(_dal.GetAllEvents().ToList());
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public JsonResult GetEventsAjax()
        {
            var JsonObj = Json(_dal.GetAllEvents().ToList());
            return JsonObj;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}