using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime{ get; set; }
        public string Location { get; set; }
    }
}
