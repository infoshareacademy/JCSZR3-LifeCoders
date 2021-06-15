using System;
using TravelerAppCore.Controller;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ustawia wysokość i szerokość okna konsoli na określone wartości.
            Console.SetWindowSize(200, 30);

            Option[] options = new Option[] {
                new Option("Wczytaj bazę hoteli", HotelService.ReadAndDisplay),
                new Option("Zapisz hotel", new Hotel().CreateNew),
                new Option("Wyszukaj po lokalizacji", ConsolePrint.SearchAddressConsole),
                new Option("Zamknij program", ConsolePrint.Exit),
                //new Option("Wyszukaj po nazwie", Search.ByName),
                //new Option("Wyszukaj po ocenie", Search.ByRate),
            };
            new Menu(options).Interface();

            //string searchedName = "BEST WESTERN Loyal Inn";// "Christopher's Inn";
            //List<int> list = SearchByName.HotelsByName(dataRead, searchedName);
            ////list.Sort();
            //List<Hotel> hotelsReturnedByName = new List<Hotel>();
            //foreach (int item in list)
            //{
            //   // Console.WriteLine(dataRead[item].HotelInfo.Name);
            //    hotelsReturnedByName.Add(dataRead[item]);
            //}
            //Console.WriteLine($"Hotels having {searchedName} in their names" );
        }
    }
}