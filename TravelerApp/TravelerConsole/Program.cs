using TravelerAppCore.Models.Hotels;
using TravelerAppCore.Controller;
using System;
using TravelerAppCore.Models;

namespace TravelerAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(180, 30);

            Option[] options = new Option[] {
                new Option("Wczytaj bazę hoteli", ReadWriteHotel.ReadAndDisplay),
                new Option("Zapisz hotel", new Hotel().CreateNew),
                new Option("Wyszukaj po lokalizacji", Search.ByLocalisation),
                new Option("Wyszukaj po nazwie", Search.ByName),
                new Option("Wyszukaj po ocenie", Search.ByRate),
            };
            new Menu(options).Interface();
        }
    }
}