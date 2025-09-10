using Microsoft.AspNetCore.Mvc;

namespace TallinnaRakendusLikKolledz.Models
{
    public class Enrollment : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
