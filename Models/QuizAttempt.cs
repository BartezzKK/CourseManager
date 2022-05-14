using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public class QuizAttempt
    {
        [Key]
        public int Id { get; set; }
        public string QuizId { get; set; }
        public string Answers { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }
    }
}
