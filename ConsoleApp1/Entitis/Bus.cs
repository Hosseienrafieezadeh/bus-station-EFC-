using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entitis
{
    public abstract class Bus
    {
        protected Bus(string busName, int casepityChair)
        {
            BusName = busName;
            CasepityChair = casepityChair;
            BusChairs = new List<BusChair>();
            for (int i = 1; i <= casepityChair; i++)
            {
                BusChairs.Add(new BusChair(i));
            }
        }

        public int Id { get; set; }
        public string BusName { get; set; }
        public BusType busType { get; set; }
        public List<BusChair> BusChairs { get; set; }
        public int CasepityChair { get; set; }
        public virtual List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public decimal Price { get; set; }
        public bool CanBuy { get; set; }
        public bool CanReserve { get; set; }
        public int TripId { get; set; }
        public decimal TicketsMoney { get; set; }
        public virtual Trip Trip { get; set; }
    }

}
