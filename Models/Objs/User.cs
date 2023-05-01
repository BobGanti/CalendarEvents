using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CalendarEvents.Models.Objs
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
