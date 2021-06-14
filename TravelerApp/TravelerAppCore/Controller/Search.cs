using System.Collections.Generic;
using System.Text.RegularExpressions;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public class Search
    {
        public static List<Hotel> ByLocalisation(string address)
        {
            List<Hotel> hotelLocalisation = new List<Hotel>();
            string regPattern = $@"{address}";
            Regex regEx = new Regex(regPattern, RegexOptions.IgnoreCase);
            foreach (Hotel hotel in HotelService.Data)
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
            return hotelLocalisation;
        }

        public static List<Hotel> ByName(string name)
        {
            List<Hotel> foundHotels = new List<Hotel>();
            int exactMatch = 0;
            //check if a search name has at least one character in it
            // search for an exact match first- if found we exit a method after finding one - I assumed hotel names are distinct
            foreach (Hotel hotel in HotelService.Data)
            {
                if (hotel.HotelInfo.Name.ToUpper().Equals(name.ToUpper()))
                {
                    exactMatch++;
                    foundHotels.Add(hotel);
                }
            }

            if (exactMatch != 0)
            {
                return foundHotels;
            }
            else
            //if no exact match has been found- we look for partial match and return all the hotels found
            {
                foreach (Hotel hotel in HotelService.Data)
                {
                    if (hotel.HotelInfo.Name.ToUpper().Contains(name.ToUpper()))
                    {
                        foundHotels.Add(hotel);
                    }
                }
                return foundHotels;
            }
        }
    }
}
    

