using System;
using System.Collections.Generic;
using TravelerAppCore.Models;
using TravelerAppCore.Models.Hotels;


namespace TravelerAppCore.View
{
    class SearchByLocalisationDraw
    {
        public void SearchAddressConsole(List<Root> hotelData)
        {
            var hotelList = SearchByLocalisation.ByLocalisation(hotelData, GetAddress());
            if (hotelList.Count == 0)
            {
                Console.WriteLine("Podana fraza nie została odnaleziona");
            }

            DrawLocalistanionTable(hotelList);
        }

        public string GetAddress()
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

        public void DrawLocalistanionTable(List<Root> dataToDraw)
        {
            int count = dataToDraw.Count;
            Console.Clear();
            DrawTable.Hotelinfo(dataToDraw, count);
        }
    }
}
