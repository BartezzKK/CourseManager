using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public class QuizEdu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Category { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
    }
}
