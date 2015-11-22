using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewMecDTO
    {
        public int id { set; get; }
        public string naziv { get; set; }
        public bool tip { get; set; }
        public bool aktivan { get; set; }
        public bool spreman { get; set; }
        public int maxBrojIgraca { get; set; }
        public string tim1 { get; set; }
        public string tim2 { get; set; }

    }
}
