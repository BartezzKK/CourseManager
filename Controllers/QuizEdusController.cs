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
using Microsoft.AspNetCore.Authorization;
using CourseManager.Repositories.Interfaces;

namespace CourseManager.Controllers
{
    public class QuizEdusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaymentsRepository paymentsRepository;

        public QuizEdusController(ApplicationDbContext context, IPaymentsRepository paymentsRepository)
        {
            _context = context;
            this.paymentsRepository = paymentsRepository;
        }

        // GET: QuizEdus
        [Authorize(Roles = "Administrator, Teacher, User")]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole("User") && !UserHasPayment(this.User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("MissingPayment", "Administration");
            }
            return View(await _context.QuizEdus.ToListAsync());
        }

        // GET: QuizEdus/Details/5
        [Authorize(Roles = "Administrator, Teacher, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizEdu = await _context.QuizEdus
                .Include("Questions")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizEdu == null)
            {
                return NotFound();
            }

            return View(quizEdu);
        }

        // GET: QuizEdus/Create
        [Authorize(Roles = "Administrator, Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuizEdus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,UserId")] QuizEdu quizEdu)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                quizEdu.UserId = userId;
                _context.Add(quizEdu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quizEdu);
        }

        // GET: QuizEdus/Edit/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizEdu = await _context.QuizEdus.FindAsync(id);
            if (quizEdu == null)
            {
                return NotFound();
            }
            return View(quizEdu);
        }

        // POST: QuizEdus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,UserId")] QuizEdu quizEdu)
        {
            if (id != quizEdu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizEdu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizEduExists(quizEdu.Id))
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
            return View(quizEdu);
        }

        // GET: QuizEdus/Delete/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizEdu = await _context.QuizEdus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizEdu == null)
            {
                return NotFound();
            }

            return View(quizEdu);
        }

        // POST: QuizEdus/Delete/5
        [Authorize(Roles = "Administrator, Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizEdu = await _context.QuizEdus.FindAsync(id);
            _context.QuizEdus.Remove(quizEdu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizEduExists(int id)
        {
            return _context.QuizEdus.Any(e => e.Id == id);
        }

        private bool UserHasPayment(string userId)
        {
            return _context.Payments.Where(p => p.UserId == userId && DateTime.Today > p.PaymentDate && DateTime.Now < p.EndSubscription).Any();
        }
    }
}
