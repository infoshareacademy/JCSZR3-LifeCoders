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
    public static class Search
    { 
        public static List<Root> byLocalisation(List<Root> targetData)
        {
            List<Root> hotelLocalisation = new List<Root>();
            string adress = getAddress();
            string regPattern = $@"{adress}";
            Regex regEx = new Regex(regPattern, RegexOptions.IgnoreCase);

            foreach(Root hotel in targetData)
            {
                if (hotel.HotelInfo.Address == null)
                {

                } else 
                { 
                    if (regEx.IsMatch(hotel.HotelInfo.Address))
                    {
                        hotelLocalisation.Add(hotel);
                    }
                }
            }
            return hotelLocalisation;
        }

        public static void drawTable(List<Root> dataToDraw)
        {
            int count = dataToDraw.Count;
            Console.Clear();
            DrawTable.Hotelinfo(dataToDraw, count);
        }

        private static string getAddress() {
            Console.WriteLine("Podaj adress do wyszukiwania:");
            string adress = Console.ReadLine();
            if(adress.Length < 4)
            {
                Console.WriteLine($"Wyszukiwana fraza powinna mieć co najmniej trzy znaki!");
                getAddress();
            }
            return adress;
        }
    }
}
