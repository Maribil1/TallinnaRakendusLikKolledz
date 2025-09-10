using Microsoft.AspNetCore.Mvc;

namespace TallinnaRakendusLikKolledz.Models
{
    public class Course : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
