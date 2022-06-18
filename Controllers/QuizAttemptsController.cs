using CourseManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CourseManager.Controllers
{
    public class QuizAttemptsController : Controller
    {
        private readonly ApplicationDbContext context;

        public QuizAttemptsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Roles = "Administrator, Teacher, User")]
        public IActionResult Index()
        {
            ViewBag.Quizes = context.QuizEdus.ToList();
            return View();
        }

        [Authorize(Roles = "Administrator, Teacher, User")]
        public IActionResult StartQuiz(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewBag.Questions = context.QuizQuestions.Where(p => p.QuizEduId == id).ToList();
            return View();
        }

        [Authorize(Roles = "Administrator, Teacher, User")]
        [HttpPost]
        public IActionResult SubmitQuiz(IFormCollection iform)
        {
            var questionIds = iform.Keys.Where(p => p.Contains("QAns")).ToList();
            //var answers = iform.Keys.First();
            var questionId = Convert.ToInt32(iform.Keys.Where(p=> p.Contains("questionId")).FirstOrDefault().Split('=')[1]);
            var quizId = context.QuizQuestions.Where(p => p.Id == questionId).Select(p => p.QuizEduId).FirstOrDefault();
            var questionsList = context.QuizQuestions.Where(p => p.QuizEduId == quizId).ToList();
            int score = 0;
            for (int i = 0; i < questionIds.Count; i++)
            {
                string answer = questionIds[i].Substring(0, 1);
                if (questionsList[i].CorrectAnswer == answer)
                {
                    score++;
                }
            }

            string color;
            if(score/questionsList.Count() > 0.75)
            {
                color = "green";
            }
            else
            {
                color = "red";
            }
            ViewBag.Score = score + "/" + questionIds.Count();
            ViewBag.Color = color;

            return View("Result");
        }
    }
}
