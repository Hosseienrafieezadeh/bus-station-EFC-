using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entitis
{
   public class Ticket
    {
        public int Id { get; set; }
        //lasy loading

        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public int BusId { get; set; }
        public virtual Bus Bus { get; set; }
        public int BusChirId { get; set; }
        public virtual BusChair BusChair { get; set; }
        public decimal payment { get; set; }




    }
}
