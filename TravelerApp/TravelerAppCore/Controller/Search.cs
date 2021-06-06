using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Models
{
    public static class Search
    {
        public static void ByLocalisation(List<Hotel> targetData)
        {
            if (targetData.Count != 0)
            {
                List<Hotel> hotelLocalisation = new List<Hotel>();
                string adress = getAdress();
                string regPattern = @$">{adress}<";
                Regex regEx = new Regex(regPattern, RegexOptions.IgnoreCase);

                foreach (Hotel hotel in targetData)
                {
                    if (hotel.HotelInfo.Address == null)
                    {

                    }
                    else
                    {
                        if (regEx.IsMatch(hotel.HotelInfo.Address))
                        {
                            hotelLocalisation.Add(hotel);
                        }
                    }
                }
                int count = hotelLocalisation.Count;

                DrawTable.Hotelinfo(hotelLocalisation, count, true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Baza hoteli jest pusta");
                Console.ResetColor();
            }
        }

        private static string getAdress()
        {
            Console.WriteLine("Podaj adress do wyszukiwania:");
            string adress = Console.ReadLine();
            return adress;
        }
    }
}