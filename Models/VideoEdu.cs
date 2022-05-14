using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public class VideoEdu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
    }
}
