using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakendusLikKolledz.Data;
using TallinnaRakendusLikKolledz.Models;

namespace TallinnaRakendusLikKolledz.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;
        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Delinquents.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();


            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(x => x.Id == id);
            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delinquent= await _context.Delinquents.FindAsync(id);
            _context.Delinquents.Remove(delinquent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquents = await _context.Delinquents.FirstOrDefaultAsync(x => x.Id == id);
            if (delinquents == null)
            {
                return NotFound();
            }
            return View(delinquents);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Update(delinquent);
                await _context.SaveChangesAsync();


            }
            return RedirectToAction("Index");

        }

    }
       
}
