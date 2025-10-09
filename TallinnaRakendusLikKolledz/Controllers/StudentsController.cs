using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakendusLikKolledz.Data;
using TallinnaRakendusLikKolledz.Models;



namespace TallinnaRakendusLikKolledz.Controllers
{
    public class StudentsController : Controller
    { 
        private readonly SchoolContext _context;
        public StudentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,EnrollmentDate")] Student student)
        {
          if (ModelState.IsValid)
          {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
          }

          return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(x => x.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,FirstName,LastName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}  
