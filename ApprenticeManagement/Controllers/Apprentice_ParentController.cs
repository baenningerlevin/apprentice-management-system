using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApprenticeManagement.Data;
using ApprenticeManagement.Models;

namespace ApprenticeManagement.Controllers
{
    public class Apprentice_ParentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Apprentice_ParentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apprentice_Parent
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Apprentice_Parents.Include(a => a.Apprentice).Include(a => a.Parent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Apprentice_Parent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apprentice_Parent = await _context.Apprentice_Parents
                .Include(a => a.Apprentice)
                .Include(a => a.Parent)
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (apprentice_Parent == null)
            {
                return NotFound();
            }

            return View(apprentice_Parent);
        }

        // GET: Apprentice_Parent/Create
        public IActionResult Create()
        {
            ViewData["ApprenticeId"] = new SelectList(_context.Apprentices.Select(a => new
            {
                a.Id,
                FullName = a.FirstName + " " + a.LastName
            }), "Id", "FullName");
            ViewData["ParentId"] = new SelectList(_context.Parents.Select(a => new 
            {
                a.Id,
                FullName = a.FirstName + " " + a.LastName
            }), "Id", "FullName");
            return View();
        }

        // POST: Apprentice_Parent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,ApprenticeId")] Apprentice_Parent apprentice_Parent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apprentice_Parent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprenticeId"] = new SelectList(_context.Apprentices.Select(a => new 
            { 
                a.Id, 
                FullName = a.FirstName + " " + a.LastName 
            }), "Id", "FullName");
            ViewData["ParentId"] = new SelectList(_context.Parents.Select(a => new 
            { 
                a.Id, 
                FullName = a.FirstName + " " + a.LastName 
            }), "Id", "FullName");
            return View(apprentice_Parent);
        }

        // GET: Apprentice_Parent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apprentice_Parent = await _context.Apprentice_Parents.FindAsync(id);
            if (apprentice_Parent == null)
            {
                return NotFound();
            }
            ViewData["ApprenticeId"] = new SelectList(_context.Apprentices.Select(a => new { a.Id, FullName = a.FirstName + " " + a.LastName }), "Id", "FullName");
            ViewData["ParentId"] = new SelectList(_context.Parents.Select(a => new { a.Id, FullName = a.FirstName + " " + a.LastName }), "Id", "FullName");
            return View(apprentice_Parent);
        }

        // POST: Apprentice_Parent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentId,ApprenticeId")] Apprentice_Parent apprentice_Parent)
        {
            if (id != apprentice_Parent.ParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apprentice_Parent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Apprentice_ParentExists(apprentice_Parent.ParentId))
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
            ViewData["ApprenticeId"] = new SelectList(_context.Apprentices.Select(a => new { a.Id, FullName = a.FirstName + " " + a.LastName }), "Id", "FullName");
            ViewData["ParentId"] = new SelectList(_context.Parents.Select(a => new { a.Id, FullName = a.FirstName + " " + a.LastName }), "Id", "FullName");
            return View(apprentice_Parent);
        }

        // GET: Apprentice_Parent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apprentice_Parent = await _context.Apprentice_Parents
                .Include(a => a.Apprentice)
                .Include(a => a.Parent)
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (apprentice_Parent == null)
            {
                return NotFound();
            }

            return View(apprentice_Parent);
        }

        // POST: Apprentice_Parent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apprentice_Parent = await _context.Apprentice_Parents.FindAsync(id);
            if (apprentice_Parent != null)
            {
                _context.Apprentice_Parents.Remove(apprentice_Parent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Apprentice_ParentExists(int id)
        {
            return _context.Apprentice_Parents.Any(e => e.ParentId == id);
        }
    }
}
