using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public class VideoEdu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }
    }
}
