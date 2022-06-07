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
    public class EducationController : Controller
    {
        private AppDbContext _context { get; }
        public EducationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var edc = _context.Educations.ToList();
            return View(edc);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create(Education education) {
            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id) {
            var page = _context.Educations.FirstOrDefault(x=>x.Id==Id);
            if (page==null)
            {
                return NotFound();
            }
            return View(page);
        }
        [HttpPost]

        public IActionResult Edit(Education education) {
            var oldeducation = _context.Educations.FirstOrDefault(x =>x.Id == education.Id);
            if (oldeducation==null)
            {
                return NotFound();
            }
            oldeducation.Name = education.Name;
            oldeducation.specialty = education.specialty;
            oldeducation.OrtalamaBal = education.OrtalamaBal;
            oldeducation.Bitirmevaxti = education.Bitirmevaxti;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
