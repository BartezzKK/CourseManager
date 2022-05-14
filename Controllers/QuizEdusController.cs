using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseManager.Data;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class QuizEdusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizEdusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuizEdus
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuizEdus.ToListAsync());
        }

        // GET: QuizEdus/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: QuizEdus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuizEdus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,UserId")] QuizEdu quizEdu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizEdu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quizEdu);
        }

        // GET: QuizEdus/Edit/5
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
    }
}
