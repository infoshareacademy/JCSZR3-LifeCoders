using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Models
{
    public static class Search
    { 
        public static List<Root> byLocalisation(List<Root> targetData)
        {
            List<Root> hotelLocalisation = new List<Root>();
            string adress = getAdress();
            string regPattern = @$">{adress}<";
            Regex rx = new Regex(regPattern, RegexOptions.IgnoreCase);

            foreach(Root hotel in targetData)
            {
                if(rx.Matches(hotel.HotelInfo.Address).Count != 0)
                {
                    hotelLocalisation.Add(hotel);
                }
            }

            return hotelLocalisation;
        }

        private static string getAdress() {
            Console.WriteLine("Podaj adress do wyszukiwania:");
            string adress = Console.ReadLine();
            if(adress.Length < 4)
            {
                Console.WriteLine("Wyszukiwana fraza powinna mieć conajmniej 3 znaki");
                return getAdress();
            } else
            {
                return adress;
            }
        }
    }
}
