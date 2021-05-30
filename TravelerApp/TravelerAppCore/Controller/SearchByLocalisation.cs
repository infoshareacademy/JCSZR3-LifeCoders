using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Models
{
    public static class SearchByLocalisation
    {
        public static List<Root> byLocalisation(List<Root> targetData, string address)
        {
            List<Root> hotelLocalisation = new List<Root>();
            string regPattern = $@"{address}";
            Regex regEx = new Regex(regPattern, RegexOptions.IgnoreCase);

            foreach (Root hotel in targetData)
            {
                if (hotel.HotelInfo.Address == null)
                {
                    continue;
                }

                if (regEx.IsMatch(hotel.HotelInfo.Address))
                {
                    hotelLocalisation.Add(hotel);
                }
            }

            if (hotelLocalisation.Count == 0)
            {
               
            }

            return hotelLocalisation;
        }
    }

    public class consoleAddress
    {
        public void searchAddressConsole(List<Root> hotelData) 
        {
            var hotelList = SearchByLocalisation.byLocalisation(hotelData, getAddress());
            if(hotelList.Count == 0)
            {
                Console.WriteLine("Podana fraza nie została odnaleziona");
            }
            drawTable(hotelList);
        }

        public string getAddress()
        {
            Console.WriteLine("Podaj adress do wyszukiwania:");
            string adress = Console.ReadLine();
            if (adress.Length < 3)
            {
                Console.WriteLine($"Wyszukiwana fraza powinna mieć co najmniej trzy znaki!");
                getAddress();
            }
            return adress;
        }

        public void drawTable(List<Root> dataToDraw)
        {
            int count = dataToDraw.Count;
            Console.Clear();
            DrawTable.Hotelinfo(dataToDraw, count);
        }
    }
}
