using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MecDTO
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public bool tip { get; set; }
        public bool aktivan { get; set; }
        public bool spreman { get; set; }
        public int maxBrojIgraca { get; set; }
        public int PrviTimID { get; set; }
        public int drugiTimID { get; set; }
    }
}
