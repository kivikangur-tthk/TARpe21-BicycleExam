using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KivikangurBicycleExam.Data;
using KivikangurBicycleExam.Models;
using Microsoft.AspNetCore.Authentication;

namespace KivikangurBicycleExam.Controllers
{
    public class ExamineesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamineesController(ApplicationDbContext context)
        {
            _context = context;
        }

		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([Bind("Id,FirstName,LastName,SSID")] Examinee examinee)
		{
			if (ModelState.IsValid)
			{
				_context.Add(examinee);
				await _context.SaveChangesAsync();
    return RedirectToAction(nameof(ExamsController.CreateForUser),
                            nameof(ExamsController).Replace("Controller", ""),
                            new {examineeId=examinee.Id});
			}
			return View(examinee);
		}

		// GET: Examinees
		public async Task<IActionResult> Index()
        {
              return View(await _context.Examinee.ToListAsync());
        }

        // GET: Examinees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Examinee == null)
            {
                return NotFound();
            }

            var examinee = await _context.Examinee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examinee == null)
            {
                return NotFound();
            }

            return View(examinee);
        }

        // GET: Examinees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Examinees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,SSID")] Examinee examinee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examinee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examinee);
        }

        // GET: Examinees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Examinee == null)
            {
                return NotFound();
            }

            var examinee = await _context.Examinee.FindAsync(id);
            if (examinee == null)
            {
                return NotFound();
            }
            return View(examinee);
        }

        // POST: Examinees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,SSID")] Examinee examinee)
        {
            if (id != examinee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examinee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamineeExists(examinee.Id))
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
            return View(examinee);
        }

        // GET: Examinees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Examinee == null)
            {
                return NotFound();
            }

            var examinee = await _context.Examinee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examinee == null)
            {
                return NotFound();
            }

            return View(examinee);
        }

        // POST: Examinees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Examinee == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Examinee'  is null.");
            }
            var examinee = await _context.Examinee.FindAsync(id);
            if (examinee != null)
            {
                _context.Examinee.Remove(examinee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamineeExists(int id)
        {
          return _context.Examinee.Any(e => e.Id == id);
        }
    }
}
