using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseManager.Data;
using CourseManager.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CourseManager.Controllers
{
    public class QuizQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuizQuestions
        [Authorize(Roles = "Administrator, Teacher, User")]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole("User") && !UserHasPayment(this.User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("MissingPayment", "Administration");
            }
            return View(await _context.QuizQuestions.ToListAsync());
        }

        [Authorize(Roles = "Administrator, Teacher, User")]
        // GET: QuizQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestion = await _context.QuizQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            return View(quizQuestion);
        }


        // GET: QuizQuestions/Create
        [Authorize(Roles = "Administrator, Teacher")]
        public IActionResult Create(string quizName, int quizId)
        {
            ViewBag.QuizId = quizId;
            ViewBag.QuizName = quizName;

            ViewBag.QuizId = new SelectList(_context.QuizEdus, "Id", "Name");

            ViewBag.Options = new List<SelectListItem>
            {
                new SelectListItem{Value="A", Text ="A"},
                new SelectListItem{Value="B", Text ="B"},
                new SelectListItem{Value="C", Text ="C"},
                new SelectListItem{Value="D", Text ="D"}
            };
            return View();
        }

        // POST: QuizQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                quizQuestion.UserId = userId;
                _context.Add(quizQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quizQuestion);
        }


        // POST: QuizQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Administrator, Teacher")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(IFormCollection formCollection)
        //{
        //    string[] cos = formCollection[""];
        //    if (ModelState.IsValid)
        //    {
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        quizQuestion.UserId = userId;
        //        _context.Add(quizQuestion);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(quizQuestion);
        //}

        // GET: QuizQuestions/Edit/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestion = await _context.QuizQuestions.FindAsync(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }
            return View(quizQuestion);
        }

        // POST: QuizQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,QuizId,AnswerA,AnswerB,AnswerC,AnswerD,CorrectAnswer,UserId")] QuizQuestion quizQuestion)
        {
            if (id != quizQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizQuestionExists(quizQuestion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quizQuestion);
        }

        // GET: QuizQuestions/Delete/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestion = await _context.QuizQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            return View(quizQuestion);
        }

        // POST: QuizQuestions/Delete/5
        [Authorize(Roles = "Administrator, Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizQuestion = await _context.QuizQuestions.FindAsync(id);
            _context.QuizQuestions.Remove(quizQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizQuestionExists(int id)
        {
            return _context.QuizQuestions.Any(e => e.Id == id);
        }

        private bool UserHasPayment(string userId)
        {
            return _context.Payments.Where(p => p.UserId == userId && DateTime.Today > p.PaymentDate && DateTime.Now < p.EndSubscription).Any();
        }

    }
}
