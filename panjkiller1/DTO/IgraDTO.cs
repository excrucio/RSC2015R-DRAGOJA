using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class IgraDTO
    {
        public int id { get; set; }
        public int mecID { get; set; }
        public int killScore { get; set; }
        public int captureScore { get; set; }
        public int trajanje {get;set;}
        public bool aktivna { get; set; }
    }
}
