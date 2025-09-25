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
           /* vm.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssigments)
                .Include(i => i.CourseAssigments)
                .ToListAsync();*/
            return View(vm);

        }
        [HttpPost]
        public IActionResult Create() 
        { 
            var instructor=new Instructor();
            instructor.CourseAssigments=new List<CourseAssigment>();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor, string selectedCourses)
        {
            if (selectedCourses != null)
            {
                instructor.CourseAssigments = new List<CourseAssigment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new CourseAssigment
                    {
                        InstructorID=instructor.ID,
                        CourseID=course
                    };
                    instructor.CourseAssigments.Add(courseToAdd);



                }
            }
            ModelState.Remove("selectedCourses");
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //PopulateAssignedCourseData(instructor);
            return View(instructor);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deletableInstructor = await _context.Instructors
                .FirstOrDefaultAsync(s => s.ID == id);
            if (deletableInstructor == null)
            {
                return NotFound();
            }
            return View(deletableInstructor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Instructor deletableinstructor= await _context.Instructors
                .SingleAsync(I => I.ID == id);
            _context.Instructors.Remove(deletableinstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses=_context.Courses;

            var instructorCourses=new HashSet<int>(instructor.CourseAssigments.Select(c => c.CourseID));
            //valime kursused kus courseid on õpetajal olemas
            var vm= new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                vm.Add(new AssignedCourseData
                {
                    CourseID = course.CourseId,
                    Title=course.Title,
                    Assigned= instructorCourses.Contains(course.CourseId)
                });
            }
            ViewData["Courses"]=vm;
        }
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructors.FirstOrDefaultAsync(x => x.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructor = await _context.Students.FirstOrDefaultAsync(x => x.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    } 
     

}
