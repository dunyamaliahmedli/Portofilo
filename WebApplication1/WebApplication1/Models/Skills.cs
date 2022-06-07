using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string WORKFLOWs { get; set; }
        public List<Icon> icons { get; set; }
    }
}
