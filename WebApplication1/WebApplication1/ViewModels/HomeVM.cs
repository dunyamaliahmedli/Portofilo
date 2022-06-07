using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeVM
    {
        public List<About> Abouts { get; set; }
        public List<Experince> Experinces { get; set; }
        public List<Education> Educations { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Icon> Icons { get; set; }
        public List<Interest> Interests { get; set; }
        public List<Certifkat> Certifkats { get; set; }
    }
}
