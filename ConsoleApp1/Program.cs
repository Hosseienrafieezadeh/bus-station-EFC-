using ConsoleApp1.Entitis;
using ConsoleApp1.EntitsMap;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        //استفاده نشده برای برگشت و کنترل
       // static Stack<Action> Stack = new Stack<Action>();
        static void Main(string[] args)
        {


            while (true)
            {
                try
                {
                    Run();
                }
                catch (Exception exception)
                {
                    ShowError(exception.Message);
                }
            }

            static void Run() {
                Console.ForegroundColor = ConsoleColor.White;
                int menu = GetInt("1: add Bus\n" +
                  "2:show bus \n" +
                  "3:add trips \n" +
                  "4:show trips \n" +
                  "5:add passenger \n" +
                  "6:show passenger \n" +                  
                  "7:add reserv \n" +
                  "8:show reserv \n" +
                  "9:add tikets \n" +
                  "10:Show Tikets\n"+
                  "11:cancel tikets\n"+
                  "12:list of Cancellation");
                switch (menu)
                {
                    case 1:
                        {
                            var busName = GetString("enter Bus name ");
                            var type = GetInt("1: vip - 2: Normal");
                            Console.WriteLine("enter price");
                            decimal price =decimal.Parse(Console.ReadLine());
                            
                            
                            Console.WriteLine(" reserver tiket this :(true/false)");
                            bool canReserve =bool.Parse( Console.ReadLine());
                            Console.WriteLine(" buy tiket this :(true/false)");
                            bool cannBuy = bool.Parse(Console.ReadLine());
                            Console.WriteLine("___________________________________________");
                            BusManagment.ShowTrips();
                            Console.WriteLine("___________________________________________");
                            var tripId = GetInt("which trip:");
                            BusManagment.AddBus(busName,cannBuy,type,canReserve,price,tripId);
                            break;
                        }
                    case 2: 
                        {
                            var type=GetInt("do yoy see 1.Vipbus 2.normalbus");
                            if (type==1)
                            {
                                BusManagment.ShowvipBuses();
                            }
                            else
                            {
                                BusManagment.showNoramlBus();
                            }
                            break;
                           
                        }
            
                    case 3:
                        {
                            var origin = GetString(" write Origin  trips");
                            var destination = GetString(" write Origin  trips");
                            BusManagment.AddTrips(origin,destination);

                            break;
                        }
                    case 4:
                        {
                            
                            BusManagment.ShowTrips();
                            break;
                        }

                    case 5: 
                        {
                            var fullName = GetString(" write Fullname");
                            var nationCode = GetString(" write Nationcode");
                            var phoneNumber = GetString(" write phonenumber");
                            BusManagment.AddPassenger(fullName, nationCode, phoneNumber);
                            break;
                        }
                    case 6: 
                        {
                            BusManagment.ShowPassengers();
                            break;
                        }
                 
                    case 7:
                        {

                            BusManagment.ShowTrips();

                            Console.WriteLine("___________________________________________________");
                            var busname = GetInt("busIdneed:");
                            Console.WriteLine("___________________________________________________");
                            BusManagment.ShowPassengers();
                            var paseengerNationCode = GetInt("chose one:");
                            var busChairNumber = GetInt("write number of chair you want:");

                            BusManagment.AddReserv(paseengerNationCode,busname,busChairNumber);
                            break;
                            
                        }
                    case 8:
                        {
                            BusManagment.ShowReserv();
                            break;
                        }
                    case 9:
                        {
                            BusManagment.ShowTrips();
                            
                            Console.WriteLine("___________________________________________________");
                            var busname = GetInt("busIdneed:");
                            Console.WriteLine("___________________________________________________");
                            BusManagment.ShowPassengers();
                            var paseengerNationCode = GetInt("chose one:");
                            var busChairNumber = GetInt("write number of chair you want:");
                                BusManagment.AddTicket(paseengerNationCode,busname,busChairNumber);
                            break;
                        }
                    case 10:
                        {
                            BusManagment.ShowTickets();
                            break; 
                        }
                    case 11: 
                        {
                            foreach (var item in BusManagment.GetEfDbPassenger())
                            {
                                Console.WriteLine($"passengerName:{item.Id}:{item.FullName}");
                                Console.WriteLine("reserv:");
                                foreach (var reserv in item.Reservation)
                                {
                                    Console.WriteLine($"reserv:{reserv.Id} date:{reserv.ReservationDate}");
                                }
                                Console.WriteLine("buy");
                                foreach (var ticket in item.Tickets)
                                {
                                    Console.WriteLine($"pament:{ticket.payment}");
                                }
                            }
                            Console.WriteLine("_____________________________________________________");
                            var passengerid = GetInt("choose one pasenger:");
                            var reservid = GetInt("choose one reserv:");
                            var cancellationReason = GetString("why you cancel:");
                            
                            BusManagment.Canceltikets(passengerid,reservid,cancellationReason);
                            break;
                        }
                    case 12: 
                        {
                            BusManagment.ShowCancelTickets();
                            break;
                        }

                    default:
                        break;
                }
            }

        }
        public static int GetInt(string messege)
        {
            int getIntegerValue;
            bool result;
            do
            {
                Console.WriteLine(messege);
                result = int.TryParse(Console.ReadLine(), out getIntegerValue);
            } while (!result);
            return getIntegerValue;
        }
        static void ShowError(string error)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(error);
            Console.WriteLine("-------------------");
        }
        public static string GetString(string messege)
        {
            string? result;
            do
            {
                Console.WriteLine(messege);
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result));
            return result;
        }

    }
}
