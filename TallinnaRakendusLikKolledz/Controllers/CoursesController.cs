using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakendusLikKolledz.Data;
using TallinnaRakendusLikKolledz.Models;

namespace TallinnaRakendusLikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department)
                .AsNoTracking();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {
			ViewData["action"] = "Create";
			PopulateDepartmentsDropDownList();
            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
			ViewData["action"] = "Create";
			if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                PopulateDepartmentsDropDownList(course.DepartmentID);
                
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
			ViewData["action"] = "Edit";
			if (id == null || _context.Courses == null)
			{
				return NotFound();

			}
			var courses = await _context.Courses
				.Include(c => c.Department)
				.AsNoTracking()
				.FirstOrDefaultAsync(m => m.CourseId == id);
			if (courses == null)
			{
				return NotFound();
			}
			return View("Create", courses);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Course course)
		{
			ViewData["action"] = "Edit";
			if (ModelState.IsValid)
			{
				_context.Courses.Add(course);
				await _context.SaveChangesAsync();
				PopulateDepartmentsDropDownList(course.DepartmentID);

			}
			return RedirectToAction("Index");

		}


		[HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
			ViewData["action"] = "Delete";
			if (id == null || _context.Courses==null)
            { return NotFound(); 
            
            }
            var courses= await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m=> m.CourseId ==id);
            if (courses == null)
            {
                return NotFound();
            }
            return View(courses);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
			ViewData["action"] = "Delete";
			if (_context.Courses == null)
            {
                return NotFound();
            }
            var course= await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment =null)
        {
            var departmentQuery= from d in _context.Departments
                                 orderby d.Name 
                                 select d;
            ViewBag.DepartmentID =new SelectList(departmentQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
       
        [HttpGet]
        
        public async Task< IActionResult> Details(int?id)
        {
			ViewData["action"] = "Details";
			if (id == null || _context.Courses == null)
			{
				return NotFound();

			}
			var courses = await _context.Courses
				.Include(c => c.Department)
				.AsNoTracking()
				.FirstOrDefaultAsync(m => m.CourseId == id);
			if (courses == null)
			{
				return NotFound();
			}
			return View("Delete", courses);


		}
        

    }
}
