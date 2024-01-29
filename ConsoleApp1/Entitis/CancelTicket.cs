using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entitis
{
 public  class CancelTicket
    {
        public int Id { get; set; }
        public int ReservId { get; set; }
        public virtual Reservation Reservation { get; set; }
        public int ticketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public DateTime CancellationDate { get; set; }
        public string CancellationReason { get; set; }
    }
}
