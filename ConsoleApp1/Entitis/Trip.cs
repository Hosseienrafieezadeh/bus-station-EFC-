using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entitis
{
 public  class Trip
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

        public virtual List<Bus> Buses { get; set; } = new List<Bus>();
        //public int BusId { get; set; }
        //public virtual Bus buss { get; set; }
    }
}
