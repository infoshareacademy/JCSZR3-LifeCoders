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
            //Console.SetWindowSize(200, 30);

            Option[] options = new Option[] {
                new Option("Wczytaj bazę hoteli", HotelService.ReadAndDisplay),
                new Option("Zapisz hotel", new Hotel().CreateNew),
                new Option("Wyszukaj po lokalizacji", ConsolePrint.SearchAddressConsole),
                new Option("Wyszukaj po nazwie", ConsolePrint.SearchByNameConsole),
                new Option("Sortuj po ocenie",ConsolePrint.DisplaySort),
                new Option("Zamknij program", ConsolePrint.Exit),
                //new Option("Wyszukaj po ocenie", Search.ByRate),
            };
            new Menu(options).Interface();
        }
    }
}
