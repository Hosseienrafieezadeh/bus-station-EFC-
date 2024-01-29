using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entitis
{
  public  class BusChair
    {
        public BusChair(int number)
        {
            Number = number;
            Status = number.ToString("D2");
        }

        public int Id { get; set; }
        public int BusId { get; set; }
        public virtual Bus Bus { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        
        
        public int ReservId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
