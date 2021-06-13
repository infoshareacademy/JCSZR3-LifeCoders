using System;
using System.Collections.Generic;
using System.Linq;
using TravelerAppCore.Controller;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.View
{
    public static class ConsoleDraw
    {
        public static void SearchAddressConsole(List<Hotel> hotelData)
        {
            var hotelList = Search.ByLocalisation(GetAddress());
            if (hotelList.Count == 0)
            {
                Console.WriteLine("Podana fraza nie została odnaleziona");
            }
            DrawLocalisationTable(hotelList);
        }

        public static string GetAddress()
        {
            Console.WriteLine("Podaj adress do wyszukiwania:");
            string adress = Console.ReadLine();
            if (adress.Length < 3)
            {
                Console.WriteLine($"Wyszukiwana fraza powinna mieć co najmniej trzy znaki!");
                GetAddress();
            }
            return adress;
        }

        public static void DrawLocalisationTable(List<Hotel> dataToDraw)
        {
            int count = dataToDraw.Count;
            Console.Clear();
            DrawTable.Hotelinfo(dataToDraw, count);
        }

        public static void DisplayLoadedData(List<Hotel> Data)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Czas odczytu wszystkich plików: {HotelService.stopper.Elapsed}");
            Console.WriteLine($"Ilość odczytanych plików: {Data.Count()}");
            Console.WriteLine("Koniec deserializacji");
            Console.WriteLine("----------------------------------------------------\n");
            DrawTable.Hotelinfo(Data, Data.Count);
        }
    }
}
