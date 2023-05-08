using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Models.SMs
{
    public class EventSM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
