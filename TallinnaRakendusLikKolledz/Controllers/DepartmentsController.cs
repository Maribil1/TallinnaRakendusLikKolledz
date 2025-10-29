using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakendusLikKolledz.Data;
using TallinnaRakendusLikKolledz.Models;

namespace TallinnaRakendusLikKolledz.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;
        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(d => d.Administrator);
            return View(await schoolContext.ToListAsync());


        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["action"] = "Create";
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName");

            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID, Name, Budget, StarDate, RowVersion, InstructorID, Cleaner, StaffHired, CloseTime")] Department department)
        {
			ViewData["action"] = "Create";
			if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName", department.InstructorID);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments
                .Include(d => d.Administrator)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            if (await _context.Departments.AnyAsync(m => m.DepartmentID == department.DepartmentID))
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
			ViewData["action"] = "Edit";
			if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments
                .Include(d => d.Administrator)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Create" , department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("DepartmentID, Name, Budget, StarDate, RowVersion, InstructorID, Cleaner, StaffHired, CloseTime")] Department department)
        {

            if (ModelState.IsValid)
            {
                _context.Update(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName", department.InstructorID);
            return RedirectToAction(nameof(Index));
        }
    }
}