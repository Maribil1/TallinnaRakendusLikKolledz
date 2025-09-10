using Microsoft.AspNetCore.Mvc;

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
            return View(await_context.Students.ToListAsync());
        }
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
                _contex.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
          }

          return View();
        }
    }
}  
