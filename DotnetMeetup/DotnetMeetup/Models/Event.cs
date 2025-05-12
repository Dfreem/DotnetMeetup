using System.ComponentModel.DataAnnotations;

namespace DotnetMeetup.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? Location { get; set; }

        public bool IsPastEvent => Date < DateTime.Now;
    }
}
