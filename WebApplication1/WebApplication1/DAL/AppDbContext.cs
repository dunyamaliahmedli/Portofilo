using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }
      public DbSet<About>Abouts { get; set; }
        public DbSet<Experince> Experinces { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Interest>Interests { get; set; }
        public DbSet<Certifkat> Certifkats { get; set; }
    }
}
