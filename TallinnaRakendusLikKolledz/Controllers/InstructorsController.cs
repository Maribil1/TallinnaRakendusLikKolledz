using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakendusLikKolledz.Data;
using TallinnaRakendusLikKolledz.Models;

namespace TallinnaRakendusLikKolledz.Controllers
{
    public class InstructorsController : Controller
    {
       private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index(int? id,int? courseId) 
        {
            var vm = new InstructorIndexData();
            vm.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssigments)
                .Include(i => i.CourseAssigments)
                .ToListAsync();
            return View(vm);

        }
    }
}
