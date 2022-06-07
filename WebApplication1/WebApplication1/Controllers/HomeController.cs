using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homevm = new HomeVM {

                Abouts = _context.Abouts.Where(p=>p.Name!=null).Take(1).ToList(),
                Experinces = _context.Experinces.Take(5).ToList(),
                Educations = _context.Educations.ToList(),
                Skills = _context.Skills.Include(p => p.icons).ToList(),
                Icons = _context.Icons.ToList(),
                Interests = _context.Interests.ToList(),
                Certifkats = _context.Certifkats.ToList(),
        };
            return View(homevm);
        }
    }
}
