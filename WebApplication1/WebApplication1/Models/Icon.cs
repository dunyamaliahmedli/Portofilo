using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Icon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SkillsId { get; set; }

        public Skills skills { get; set; }
    }
}
