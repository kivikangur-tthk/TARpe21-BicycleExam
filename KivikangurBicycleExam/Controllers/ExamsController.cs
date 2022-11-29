using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KivikangurBicycleExam.Data;
using KivikangurBicycleExam.Models;

namespace KivikangurBicycleExam.Controllers
{
	public class ExamsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ExamsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Exams
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Exam.Include(e => e.Examinee);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Exams/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Exam == null)
			{
				return NotFound();
			}

			var exam = await _context.Exam
							.Include(e => e.Examinee)
							.FirstOrDefaultAsync(m => m.Id == id);
			if (exam == null)
			{
				return NotFound();
			}

			return View(exam);
		}

		// GET: Exams/Create
		public IActionResult Create()
		{
			ViewData["ExamineeId"] = CreateExamineeSelectList();
			return View();
		}

		private List<SelectListItem> CreateExamineeSelectList(int? selected=null)
		{
			var selectList = new SelectList(_context.Set<Examinee>(), "Id", "SSID", selected).ToList();
			selectList.Insert(0, new SelectListItem("Vali eksamineeritav","-1"));
			return selectList;
		}

		// POST: Exams/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,ExamineeId,TheoryResult,ParkingLotResult,SlalomResult,CircleResult")] Exam exam)
		{
			var examinee = await _context.Examinee.FirstOrDefaultAsync(m => m.Id == exam.ExamineeId);
			exam.Examinee = examinee;
			ModelState.ClearValidationState(nameof(Exam.Examinee));
			TryValidateModel(exam);
			if (ModelState.IsValid)
			{
				_context.Add(exam);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["ExamineeId"] = CreateExamineeSelectList(exam.ExamineeId);
			return View(exam);
		}

		// GET: Exams/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Exam == null)
			{
				return NotFound();
			}

			var exam = await _context.Exam.FindAsync(id);
			if (exam == null)
			{
				return NotFound();
			}
			ViewData["ExamineeId"] = CreateExamineeSelectList(exam.ExamineeId);
			return View(exam);
		}

		// POST: Exams/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,ExamineeId,TheoryResult,ParkingLotResult,SlalomResult,CircleResult")] Exam exam)
		{
			if (id != exam.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(exam);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ExamExists(exam.Id))
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
			ViewData["ExamineeId"] = CreateExamineeSelectList(exam.ExamineeId);
			return View(exam);
		}

		// GET: Exams/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Exam == null)
			{
				return NotFound();
			}

			var exam = await _context.Exam
							.Include(e => e.Examinee)
							.FirstOrDefaultAsync(m => m.Id == id);
			if (exam == null)
			{
				return NotFound();
			}

			return View(exam);
		}

		// POST: Exams/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Exam == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Exam'  is null.");
			}
			var exam = await _context.Exam.FindAsync(id);
			if (exam != null)
			{
				_context.Exam.Remove(exam);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ExamExists(int id)
		{
			return _context.Exam.Any(e => e.Id == id);
		}
	}
}
