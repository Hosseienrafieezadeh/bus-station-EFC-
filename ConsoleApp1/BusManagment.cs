using ConsoleApp1.Entitis;
using ConsoleApp1.EntitsMap;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
 public static  class BusManagment
    {

        private static EfDbContext _efDbContext = new EfDbContext();

        public static void AddBus(string busName, bool canBuy, int type, bool CanReserv, decimal price, int tripid)
        {
            int casepity;
            var trip = _efDbContext.Trips.Find(tripid);

            if (trip != null)
            {
                switch (type)
                {
                    case 1:
                        {
                            var busuniq = _efDbContext.Buses.Any(_=> _.BusName == busName);
                            if (busuniq) 
                            {
                                
                                    Console.ForegroundColor = ConsoleColor.Red;
                                
                                    throw new Exception("busname should be unique");
                            }
                            casepity = 30;
                            var NewBus = new VipBus(busName, casepity);
                            NewBus.busType = BusType.Vip;
                            NewBus.CasepityChair = casepity;
                            NewBus.CanBuy = canBuy;
                            NewBus.CanReserve = CanReserv;
                            NewBus.Price = price;
                            NewBus.TripId = tripid;
                            NewBus.TicketsMoney = 0;
                            _efDbContext.Buses.Add(NewBus);
                            _efDbContext.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Green;                
                            Console.WriteLine("add VIPbus  successful");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    case 2:
                        {
                            var busuniq = _efDbContext.Buses.Any(_ => _.BusName == busName);
                            if (busuniq)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new Exception("busname should be unique");
                            }
                            casepity = 44;
                            var NewBus = new NormalBus(busName, casepity);
                            NewBus.busType = BusType.normal;
                            NewBus.CasepityChair = casepity;
                            NewBus.CanBuy = canBuy;
                            NewBus.CanReserve = CanReserv;
                            NewBus.Price = price;
                            NewBus.TicketsMoney = 0;
                            NewBus.TripId = tripid;
                            
                            _efDbContext.Buses.Add(NewBus);
                            _efDbContext.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("add normalbus  successful");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new Exception("no type of this bus");
         
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("not found this trip");
         
            }
        }

        public static void showNoramlBus() 
        {
            var Buses = _efDbContext.Buses.Where(_=> _ is NormalBus);
            Console.WriteLine(" Normal Bus List ");
            foreach (var bus in Buses)
            {
                var buy = bus.CanBuy == true ? "Yes" : "No";
                var reserv = bus.CanReserve == true ? "Yes" : "No";

                Console.WriteLine("*******************************************************");
                Console.WriteLine($"id:{bus.Id} -name:{bus.BusName}\n  bus type:{bus.busType} - price:{bus.Price}\n -" +
                    $" buy:{buy} reserv:{reserv} \n travel profit:{bus.TicketsMoney}\n" +
                    $"\n Trip Origin:{bus.Trip?.Origin} - Trip Destination:{bus.Trip?.Destination}");
                Console.WriteLine("*******************************************************");

                int numberRow = 4;
                int ThingsOnTheTable = 0;
                int row = 1;
                foreach (var chair in bus.BusChairs)
                {
                    var tik = (chair.Ticket != null ? "bb" : (chair.Reservation != null ? "rr" : chair.Status));

                    Console.Write($"{tik} ");
                    ThingsOnTheTable++;


                    if (ThingsOnTheTable % numberRow == 0)
                    {
                        Console.WriteLine();
                        row++;
                    }
                    if (row == 6 || row == 7)
                    {
                        numberRow = 2;
                    }
                    if (row == 8)
                    {
                        numberRow = 4;
                    }
                }
            }
        }
        public static void ShowvipBuses() 
        {
            var Buses = _efDbContext.Buses.Where(_ => _ is VipBus);
            
            Console.WriteLine(" vip Bus List");
            foreach (var bus in Buses)
            {
                var buy = bus.CanBuy == true ? "Yes" : "No";
                var reserv = bus.CanReserve == true ? "Yes" : "No";

                Console.WriteLine("*******************************************************");
                Console.WriteLine($"id:{bus.Id} -name:{bus.BusName}\n  bus type:{bus.busType} - price:{bus.Price}\n -" +
                    $" buy:{buy} reserv:{reserv} \n travel profit:{bus.TicketsMoney}\n" +
                    $"\n Trip Origin:{bus.Trip?.Origin} - Trip Destination:{bus.Trip?.Destination}");
                Console.WriteLine("*******************************************************");
                
                    int numberRow = 3;
                    int ThingsOnTheTable = 0;
                    int row = 1;
                    foreach (var chair in bus.BusChairs)
                    {
                        var tik = (chair.Ticket != null ? "bb" : (chair.Reservation != null ? "rr" : chair.Status));



                        Console.Write($"{tik} ");
                        ThingsOnTheTable++;

                        if (ThingsOnTheTable % numberRow == 0)
                        {
                            Console.WriteLine();
                            row++;
                        }
                        if (row == 6 || row == 7 || row == 8)
                        {
                            numberRow = 1;
                        }
                        if (row == 9)
                        {
                            numberRow = 3;
                        }

                    }
                    Console.WriteLine("_________________________________");

                
            }
        }
        
        //public static void ShowBus()
        //{
        //    foreach (var bus in GetEfDbBuses())
        //    {
        //        var buy = bus.CanBuy==true? "Yes" : "No";
        //        var reserv = bus.CanReserve==true ? "Yes" : "No";
              
        //        Console.WriteLine("*******************************************************");
        //        Console.WriteLine($"id:{bus.Id} -name:{bus.BusName} - bus type:{bus.busType} - price:{bus.Price} -" +
        //            $" buy:{buy} reserv:{reserv} bustype:{bus.busType} travel profit:{bus.TicketsMoney}" +
        //            $"- Trip Origin:{bus.Trip?.Origin} - Trip Destination:{bus.Trip?.Destination}");
        //        Console.WriteLine("*******************************************************");

        //        if (bus.busType == BusType.Vip)
        //        {
        //            int numberRow = 3;
        //            int ThingsOnTheTable = 0;
        //            int row = 1;
        //            foreach (var chair in bus.BusChairs)
        //            {
        //                var tik = (chair.Ticket != null ? "bb" : (chair.Reservation != null ? "rr" : chair.Status));



        //                Console.Write($"{tik} ");
        //                    ThingsOnTheTable++;

        //                    if (ThingsOnTheTable % numberRow == 0)
        //                    {
        //                        Console.WriteLine();
        //                        row++;
        //                    }
        //                    if (row == 6 || row == 7 || row == 8)
        //                    {
        //                        numberRow = 1;
        //                    }
        //                    if (row == 9)
        //                    {
        //                        numberRow = 3;
        //                    }
                        
        //            }
        //            Console.WriteLine("_________________________________"); 
                   
        //        }


        //        else 
        //        {
        //            int numberRow = 4;
        //            int ThingsOnTheTable = 0;
        //            int row = 1;
        //            foreach (var chair in bus.BusChairs)
        //            {
        //                var tik = (chair.Ticket != null ? "bb" : (chair.Reservation != null ? "rr" : chair.Status));

        //                Console.Write($"{tik} ");
        //                ThingsOnTheTable++;


        //                if (ThingsOnTheTable % numberRow == 0)
        //                {
        //                    Console.WriteLine();
        //                    row++;
        //                }
        //                if (row == 6 || row == 7)
        //                {
        //                    numberRow = 2;
        //                }
        //                if (row == 8)
        //                {
        //                    numberRow = 4;
        //                }
        //            }
        //        }
        //    }
        //}

        public static void AddTrips(string origin, string destination) 
        {

            var trips = new Trip();
            trips.Destination = destination;
            trips.Origin = origin;
            _efDbContext.Add(trips);
            _efDbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("add trip  successful");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void ShowTrips()
        {
            Console.WriteLine("*******************************************************");
            foreach (var trip in GetEfDbTrip())
            {
                Console.WriteLine($"tripid:{trip.Id} - Origin:{trip.Origin} -Destination:{trip.Destination}");
                Console.WriteLine("------------------------------------------------------------");
                foreach (var bus in trip.Buses)
                {
                    Console.WriteLine($"buses id-{bus.Id} - busname:{bus.BusName}");
                }
            }
            Console.WriteLine("*******************************************************");
        }
        public static void AddPassenger(string fullName, string nationalCode, string phoneNumber)
        {
            var isPassenger = _efDbContext.Passengers.Any(_=> _.NationalCode == nationalCode);

            if (!isPassenger)
            {
                var newPassenger = new Passenger
                {
                    FullName = fullName,
                    NationalCode = nationalCode,
                    PhoneNumber = phoneNumber
                };

                _efDbContext.Add(newPassenger);
                _efDbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("add passenger  successful");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("This user with this national code already exists");
            }
        }

        public static void ShowPassengers()
        {
            Console.WriteLine("*******************************************************");
            foreach (var passenger in GetEfDbPassenger())
            {

                Console.WriteLine($"ID:{passenger.Id} - name{passenger.FullName} - NationalCode:{passenger.NationalCode}" +
                    $" -PhoneNumber: {passenger.PhoneNumber} ");
                foreach (var reserv in passenger.Reservation )
                {
                    Console.WriteLine($"{reserv.ReservationDate}");
                }
            }
            Console.WriteLine("*******************************************************");
        }


        public static void AddReserv(int passengerId, int busId, int busChairNumber)
        {
            var bus = _efDbContext.Buses.FirstOrDefault(_ => _.Id == busId);
            var passenger = _efDbContext.Passengers.Find(passengerId);

            if (bus != null)//&&  bus.CanReserve == true
            {
                var busChair = bus.BusChairs.FirstOrDefault(_ => _.Number == busChairNumber);
                        
                var reserv = new Reservation();


                reserv.BusId = busId;
                reserv.PassengerId = passengerId;
                reserv.BusChirId = busChairNumber;
                reserv.ReservationDate = DateTime.Now;

                var chairsToUpdate = bus.BusChairs.Find(_ => _.Number == busChairNumber);
                if (chairsToUpdate.TicketId !=0 &&chairsToUpdate.ReservId!=0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("Buschair has ticket or  reserv");
                }
                    chairsToUpdate.Status = "rr";
                chairsToUpdate.ReservId = reserv.Id;
                _efDbContext.SaveChanges();
                    
                    
                _efDbContext.Reservations.Add(reserv);
                bus.TicketsMoney += 0.3m * bus.Price;

                _efDbContext.SaveChanges();


                Console.ForegroundColor = ConsoleColor.Green;
                
                Console.WriteLine("reserv  successful");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Bus not found");
               
            }
        }


        public static void ShowReserv()
        {
            Console.WriteLine("*******************************************************");
            foreach (var purchase in GetEfDbReserv())
            {
                Console.WriteLine($"Purchase ID:{purchase.Id} - Purchase Date:{purchase.ReservationDate}");

                if (purchase.Passenger != null)
                {
                    Console.WriteLine($"Passenger ID:{purchase.Passenger.Id} - Passenger Name:{purchase.Passenger.FullName}");
                }

                
            }
            Console.WriteLine("*******************************************************");
        }

            //var passenger = _efDbContext.Passengers.FirstOrDefault(_ => _.NationalCode == natioCode);

              //  var busChair = bus.BusChairs.FirstOrDefault(_ => _.Number == busChairNumber);
               //var busChair = bus.BusChairs.FirstOrDefault(_ => _.Id == busChairNumber);

                //if (busChair != null)
                //{
            //var bus = _efDbContext.Buses.FirstOrDefault(_ => _.BusName == busId);
        public static void AddTicket(int passengerid, int  busId, int busChairNumber)
        {

            var bus = _efDbContext.Buses.FirstOrDefault(_ => _.Id == busId);
            var passenger = _efDbContext.Passengers.FirstOrDefault(_ => _.Id == passengerid);

            if ( bus != null)//&& bus.CanBuy == true
            {
                var busChair = bus.BusChairs.FirstOrDefault(_ => _.Number == busChairNumber);

                var ticket = new Ticket();


                       ticket.BusId = busId;
                    ticket.PassengerId = passengerid;
                    ticket.BusChirId = busChairNumber;
                      ticket.payment = bus.Price;
                var chairsToUpdate = bus.BusChairs.Find(_ => _.Number == busChairNumber);
                if (chairsToUpdate.TicketId != 0 && chairsToUpdate.ReservId != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("Buschair has ticket or  reserv");
                }
                chairsToUpdate.Status = "bb";
                    chairsToUpdate.TicketId=ticket.Id;
                
                

                bus.TicketsMoney += ticket.payment;
                    _efDbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("buy  successful");
                Console.ForegroundColor = ConsoleColor.White;
                //}

                //else
                //{
                //    throw new Exception("Bus chair not found");
                //}
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                throw new Exception("Bus not found");
              
            }
        }




        public static void ShowTickets()
        {

            Console.WriteLine("*******************************************************");
            foreach (var ticket in GetEfDbTickets())
            {
                
                Console.WriteLine($"Ticket ID: {ticket.Id}");
                Console.WriteLine($"Ticket Price: {ticket.payment}");

                if (ticket.Bus != null)
                {
                    Console.WriteLine($"Bus ID: {ticket.Bus.Id}");
                    Console.WriteLine($"Bus Name: {ticket.Bus.BusName}");
                }

                

                Console.WriteLine("-------------------------------------------------------");
            }
            Console.WriteLine("*******************************************************");
        }
        public static void Canceltikets(int passengerId,int reservId, string cancellationReason)
        {
            //var passenger = _efDbContext.Passengers.FirstOrDefault(p => p.NationalCode == nationalCode);
            var passenger = _efDbContext.Passengers.FirstOrDefault(_ => _.Id == passengerId);
            
            if (passenger != null )
            {
            var removeReserv = passenger.Reservation.Find(_=>_.Id==reservId);
                if (removeReserv is not null)
                {
                    var cancelTicket = new CancelTicket
                    {
                        ReservId = passengerId,
                        CancellationReason = cancellationReason,
                        CancellationDate = DateTime.Now
                    };
                    var chairsToUpdate=removeReserv.Bus.BusChairs.Find(_ => _.Number == removeReserv.BusChirId);

                    _efDbContext.cancelTickets.Add(cancelTicket);
                    removeReserv.Bus.TicketsMoney -= 0.3m * removeReserv.Bus.Price;
                    decimal aa = .3m * removeReserv.Bus.Price;
                   removeReserv.Bus.TicketsMoney += 0.1m * aa;


                    chairsToUpdate.TicketId = 0;

                    _efDbContext.Remove(removeReserv);

                    _efDbContext.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("remove  successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            var removeTiket = passenger.Tickets.Find(_ => _.Id == reservId);
                if (removeTiket is not null)
                { 
                    var cancel = new CancelTicket
                    {
                        ticketId = passengerId,
                        CancellationReason = cancellationReason,
                        CancellationDate = DateTime.Now
                    };
                    var chairsToUpdate = removeReserv.Bus.BusChairs.Find(_ => _.Number == removeReserv.BusChirId);
                    _efDbContext.cancelTickets.Add(cancel);
                    removeTiket.Bus.TicketsMoney -= removeTiket.Bus.Price;
                    decimal aa = .3m * removeTiket.Bus.Price;
                    removeTiket.Bus.TicketsMoney += 0.2m * aa;
                    chairsToUpdate.TicketId = 0;
                    _efDbContext.Remove(removeTiket);

                    _efDbContext.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("remove  successful");
                    Console.ForegroundColor = ConsoleColor.White;
                } 
            }
            else
            {
                throw new Exception("Passenger not found");
            }
        }


        public static void ShowCancelTickets()
        {
            int canceledTicketsCount = 0;
            int canceledReservationsCount = 0;

            Console.WriteLine("*******************************************************");
            foreach (var cancelTicket in GetEfDbCancelTikets())
            {
                if (cancelTicket.Ticket is not null)
                {
                    canceledTicketsCount++;
                    Console.WriteLine("cancel tickets:");
                    Console.WriteLine($"ID:{cancelTicket.Id} - Cancellation Date: {cancelTicket.CancellationDate}");
                    Console.WriteLine($"Reason:{cancelTicket.CancellationReason}");
                    Console.WriteLine($"Ticket Information - ID:{cancelTicket.Ticket.Id} name:{cancelTicket.Ticket.Passenger.FullName}  ");
                    Console.WriteLine("*******************************************************");
                }
                if (cancelTicket.Reservation is not null)
                {
                    canceledReservationsCount++;
                    Console.WriteLine("reserv  tickets:");
                    Console.WriteLine($"ID:{cancelTicket.Id} - Cancellation Date: {cancelTicket.CancellationDate}");
                    Console.WriteLine($"Reason:{cancelTicket.CancellationReason}");
                    Console.WriteLine($"Ticket Information - ID:{cancelTicket.Reservation.Id} name:{cancelTicket.Reservation.Passenger.FullName}  ");
                    Console.WriteLine("*******************************************************");
                }
            }

            Console.WriteLine($"Total Canceled Tickets: {canceledTicketsCount}");
            Console.WriteLine($"Total Canceled Reservations: {canceledReservationsCount}");
        }




        public static List<Bus>  GetEfDbBuses()
        {
            return _efDbContext.Buses.Include(_ => _.Trip).Include(_=>_.BusChairs).Include(_=>_.Tickets).ToList();
        }
        public static List<Trip> GetEfDbTrip()
        {
            return _efDbContext.Trips.Include(_=> _.Buses).ToList();
        }
        public static List<Passenger> GetEfDbPassenger()
        {
                return _efDbContext.Passengers.Include(_ => _.Reservation).Include(_=>_.Tickets).ToList();
        }
        
        public static List<Reservation> GetEfDbReserv()
        {
            return _efDbContext.Reservations.Include(_ => _.Passenger).ToList();
        }
        public static List<Ticket> GetEfDbTickets()
        {
            return _efDbContext.Tickets.Include(_ =>_.Bus).Include(_=>_.BusChair).ToList();
        }
        public static List<CancelTicket> GetEfDbCancelTikets()
        {
            return _efDbContext.cancelTickets.Include(_ => _.Reservation).Include(_=>_.Ticket).ToList();
        }
    }
}
