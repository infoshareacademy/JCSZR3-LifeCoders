﻿using System;
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
        public static void byLocalisation(List<Root> targetData)
        {
            List<Root> hotelLocalisation = new List<Root>();
            string adress = getAdress();
            string regPattern = @$">{adress}<";
            Regex regEx = new Regex(regPattern, RegexOptions.IgnoreCase);

            foreach(Root hotel in targetData)
            {
                if (hotel.HotelInfo.Address == null)
                {

                } else { 
                    if (regEx.IsMatch(hotel.HotelInfo.Address))
                    {
                        hotelLocalisation.Add(hotel);
                    }
                }
            }
            int count = hotelLocalisation.Count;
            Console.Clear();
            DrawTable.Hotelinfo(hotelLocalisation, count);

        }

        private static string getAdress() {
            Console.WriteLine("Podaj adress do wyszukiwania:");
            string adress = Console.ReadLine();
            return adress;
        }
    }
}