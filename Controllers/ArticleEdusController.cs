﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseManager.Data;
using CourseManager.Models;
using System.Security.Claims;

namespace CourseManager.Views
{
    public class ArticleEdusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleEdusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArticleEdus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticleEdu.ToListAsync());
        }

        // GET: ArticleEdus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleEdu = await _context.ArticleEdu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleEdu == null)
            {
                return NotFound();
            }

            return View(articleEdu);
        }

        // GET: ArticleEdus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleEdus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,UserId,PublicationDate")] ArticleEdu articleEdu)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                articleEdu.UserId = userId;
                articleEdu.PublicationDate = DateTime.Now;
                _context.Add(articleEdu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleEdu);
        }

        // GET: ArticleEdus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleEdu = await _context.ArticleEdu.FindAsync(id);
            if (articleEdu == null)
            {
                return NotFound();
            }
            return View(articleEdu);
        }

        // POST: ArticleEdus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,UserId,PublicationDate")] ArticleEdu articleEdu)
        {
            if (id != articleEdu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleEdu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleEduExists(articleEdu.Id))
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
            return View(articleEdu);
        }

        // GET: ArticleEdus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleEdu = await _context.ArticleEdu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleEdu == null)
            {
                return NotFound();
            }

            return View(articleEdu);
        }

        // POST: ArticleEdus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleEdu = await _context.ArticleEdu.FindAsync(id);
            _context.ArticleEdu.Remove(articleEdu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleEduExists(int id)
        {
            return _context.ArticleEdu.Any(e => e.Id == id);
        }
    }
}
