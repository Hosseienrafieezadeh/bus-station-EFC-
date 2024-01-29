using ConsoleApp1.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EntitsMap
{
   public class EfDbContext :DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<CancelTicket> cancelTickets { get; set; }
        public DbSet<VipBus> vipBuses { get; set; }
        public DbSet<NormalBus> normalBuses { get; set; }
        
        public DbSet<BusChair>  busChairs { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=tavvBus4;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDbContext).Assembly);

            modelBuilder.Entity<Bus>().HasDiscriminator<BusType>(name: "Type").HasValue<NormalBus>(BusType.normal).HasValue<VipBus>(BusType.Vip);
        }
    }
}
