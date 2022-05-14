using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models
{
    public class QuizQuestion
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Question")]
        public string Question { get; set; }
        [DisplayName("Quiz")]
        public int QuizEduId { get; set; }
        [DisplayName("A")]
        public string AnswerA { get; set; }
        [DisplayName("B")]
        public string AnswerB { get; set; }
        [DisplayName("C")]
        public string AnswerC { get; set; }
        [DisplayName("D")]
        public string AnswerD { get; set; }
        [DisplayName("Correct Answer")]
        public string CorrectAnswer { get; set; }
        public string UserId { get; set; }



    }

    public class QuizQuestionViewModel
    {
        public int Id { get; set; }
        [DisplayName("Question")]
        public string Question { get; set; }
        [DisplayName("Quiz")]
        public int QuizId { get; set; }
        [DisplayName("A")]
        public string QuizName { get; set; }
        public string AnswerA { get; set; }
        [DisplayName("B")]
        public string AnswerB { get; set; }
        [DisplayName("C")]
        public string AnswerC { get; set; }
        [DisplayName("D")]
        public string AnswerD { get; set; }
        [DisplayName("Correct Answer")]
        public string CorrectAnswer { get; set; }
        public string UserId { get; set; }
    }
}
