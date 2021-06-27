using BusFinderAppCore.Control;
using BusFinderAppCore.Models;
using System;
using System.Collections.Generic;

namespace BusFinderAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            JSON.ScheduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
            Console.WriteLine(JSON.ScheduleList[0].Station.Default_address.Full_address);
            Console.WriteLine(JSON.ScheduleList[1].Station.Default_address.Full_address);
            Console.WriteLine(JSON.ScheduleList[2].Station.Default_address.Full_address);
            Console.WriteLine(JSON.ScheduleList[3].Station.Default_address.Full_address);
            Console.WriteLine(JSON.ScheduleList[4].Station.Default_address.Full_address);
            Console.WriteLine(JSON.ScheduleList[5].Station.Default_address.Full_address);
                                                                           
            AddressDivider.divider();
            Console.WriteLine("**************Adres po uzyciu AddressDivider******************");
            Console.WriteLine(JSON.ScheduleList[0].Station.Default_address.Street);
            Console.WriteLine(JSON.ScheduleList[0].Station.Default_address.Town);
            Console.WriteLine(JSON.ScheduleList[0].Station.Default_address.Country);
            Console.WriteLine(JSON.ScheduleList[1].Station.Default_address.Street);
            Console.WriteLine(JSON.ScheduleList[1].Station.Default_address.Town);
            Console.WriteLine(JSON.ScheduleList[1].Station.Default_address.Country);
            Console.WriteLine("*****ch***********SearchByTown************************");
            JSON.ScheduleList[0].Station.Default_address.Town = "Krakow";
            Console.WriteLine("******************************************");
            List<ScheduleForStation> lista = Search.ByTown("Krakow");
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.Station.Name}");
            }
            Console.WriteLine("**************SearchByCountry****************************");
            Console.WriteLine(JSON.ScheduleList[0].Station.Default_address.Country);
            Console.WriteLine(JSON.ScheduleList[1].Station.Default_address.Country);
            Console.WriteLine(JSON.ScheduleList[2].Station.Default_address.Country);
            Console.WriteLine(JSON.ScheduleList[3].Station.Default_address.Country);
            Console.WriteLine(JSON.ScheduleList[4].Station.Default_address.Country);
            Console.WriteLine(JSON.ScheduleList[5].Station.Default_address.Country);
            Console.WriteLine("******************SearchByCountry: Polska************************");

            List<ScheduleForStation> lista1 = Search.ByCountry("Polska");
            foreach (var item in lista1)
            {
                Console.WriteLine($"{item.Station.Name}");
            }

            Console.WriteLine("**************SearchByStationName****************************");
            Console.WriteLine(JSON.ScheduleList[0].Station.Name);
            Console.WriteLine(JSON.ScheduleList[1].Station.Name);
            Console.WriteLine(JSON.ScheduleList[2].Station.Name);
            Console.WriteLine(JSON.ScheduleList[3].Station.Name);
            Console.WriteLine(JSON.ScheduleList[4].Station.Name);
            Console.WriteLine(JSON.ScheduleList[5].Station.Name);
            Console.WriteLine("******************SeSrchByName: Warsaw************************");
            List<ScheduleForStation> lista2 = Search.ByName("Warsaw");
            foreach (var item in lista2)
            {
                Console.WriteLine($"{item.Station.Name}");
            }
           
            Console.ReadLine();
        }
    }
}
