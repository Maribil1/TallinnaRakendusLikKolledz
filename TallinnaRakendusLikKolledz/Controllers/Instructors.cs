using Microsoft.AspNetCore.Mvc;

namespace TallinnaRakendusLikKolledz.Controllers
{
    public class Instructors : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
