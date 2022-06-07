using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ExperienceController : Controller
    {
        private AppDbContext _context { get; }
        public ExperienceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var experiences = _context.Experinces.ToList();
            return View(experiences);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Experince experince) {
            await _context.Experinces.AddAsync(experince);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            var deleted = _context.Experinces.Find(Id);
            if (deleted == null) return NotFound();
            _context.Experinces.Remove(deleted);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id) {
            Experince experince = _context.Experinces.FirstOrDefault(x => x.Id == Id);
            if (experince==null)
            {
                return NotFound();
            }

            return View(experince);
        }
        [HttpPost]
        public IActionResult Edit(Experince experince) {
            var oldexperince = _context.Experinces.FirstOrDefault(x => x.Id == experince.Id);
            if (oldexperince==null)
            {
                return NotFound();
            }
            oldexperince.ExperinceName = experince.ExperinceName;
            oldexperince.Title = experince.Title;
            oldexperince.ExperinceAbout = experince.Title;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
