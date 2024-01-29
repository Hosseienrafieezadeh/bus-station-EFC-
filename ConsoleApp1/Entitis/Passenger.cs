using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entitis
{
   public class Passenger
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Reservation> Reservation { get; set; }
       
        public virtual List <Ticket>  Tickets { get; set; }
    }
}
