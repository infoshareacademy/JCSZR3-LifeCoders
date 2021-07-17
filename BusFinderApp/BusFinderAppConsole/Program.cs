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
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
            Console.WriteLine(JSON.ShceduleList[0].station.default_address.full_address);
            Console.WriteLine(JSON.ShceduleList[1].station.default_address.full_address);
            Console.WriteLine(JSON.ShceduleList[2].station.default_address.full_address);
            Console.WriteLine(JSON.ShceduleList[3].station.default_address.full_address);
            Console.WriteLine(JSON.ShceduleList[4].station.default_address.full_address);
            Console.WriteLine(JSON.ShceduleList[5].station.default_address.full_address);

            AddressDivider.Divider(JSON.ShceduleList);
            Console.WriteLine("**************Adres po uzyciu AddressDivider******************");
            Console.WriteLine(JSON.ShceduleList[0].station.default_address.Street);
            Console.WriteLine(JSON.ShceduleList[0].station.default_address.Town);
            Console.WriteLine(JSON.ShceduleList[0].station.default_address.Country);
            Console.WriteLine(JSON.ShceduleList[1].station.default_address.Street);
            Console.WriteLine(JSON.ShceduleList[1].station.default_address.Town);
            Console.WriteLine(JSON.ShceduleList[1].station.default_address.Country);
            Console.WriteLine("******************SearchByTown************************");
            JSON.ShceduleList[0].station.default_address.Town = "Krakow";
            Console.WriteLine("******************************************");
            List<ScheduleForStation> lista = Search.ByTown("Krakow");
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.station.name}");
            }
            Console.WriteLine("**************SearchByCountry****************************");
            Console.WriteLine(JSON.ShceduleList[0].station.default_address.Country);
            Console.WriteLine(JSON.ShceduleList[1].station.default_address.Country);
            Console.WriteLine(JSON.ShceduleList[2].station.default_address.Country);
            Console.WriteLine(JSON.ShceduleList[3].station.default_address.Country);
            Console.WriteLine(JSON.ShceduleList[4].station.default_address.Country);
            Console.WriteLine(JSON.ShceduleList[5].station.default_address.Country);
            Console.WriteLine("******************SearchByCountry: Polska************************");

            List<ScheduleForStation> lista1 = Search.ByCountry("Polska");
            foreach (var item in lista1)
            {
                Console.WriteLine($"{item.station.name}");
            }

            Console.WriteLine("**************SearchByStationName****************************");
            Console.WriteLine(JSON.ShceduleList[0].station.name);
            Console.WriteLine(JSON.ShceduleList[1].station.name);
            Console.WriteLine(JSON.ShceduleList[2].station.name);
            Console.WriteLine(JSON.ShceduleList[3].station.name);
            Console.WriteLine(JSON.ShceduleList[4].station.name);
            Console.WriteLine(JSON.ShceduleList[5].station.name);
            Console.WriteLine("******************SearchByName: Warsaw************************");
            List<ScheduleForStation> lista2 = Search.ByName("Warsaw");
            foreach (var item in lista2)
            {
                Console.WriteLine($"{item.station.name}");
            }
           
            Console.ReadLine();
        }
    }
}
