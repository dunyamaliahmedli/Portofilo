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
    public class PortofiloController : Controller
    {
        private AppDbContext _context { get; }
        public PortofiloController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var page = _context.Abouts.ToList();
            return View(page);
        }
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About about)
        {


            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }

        public IActionResult Delete(int Id) {
            var deleted = _context.Abouts.Find(Id);
            if (deleted != null) {
                _context.Abouts.Remove(deleted);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id) {
            About abouts = _context.Abouts.FirstOrDefault(x => x.Id == Id);
            if (abouts == null) return NotFound();
            //var Page = _context.Abouts.ToList();
            return View(abouts);
        }
        [HttpPost]
 
        public IActionResult Edit(About about) {
            var existabout = _context.Abouts.FirstOrDefault(x => x.Id == about.Id);
            if (existabout==null) 
            {
                return NotFound();
            }
            existabout.Name = about.Name;
            existabout.Surname = about.Surname;
            existabout.Streat = about.Streat;
            existabout.Number = about.Number;
            existabout.Email = about.Email;
            existabout.Abouts = about.Abouts;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
