using System.Collections.Generic;
using System.Text.RegularExpressions;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    class Search
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

        public static List<int> HotelsByName(string searchedName)
        {
            List<int> foundHotels = new List<int>();
            int exactMatch = 0;
            //check if a search name has at least one character in it
            // search for an exact match first- if found we exit a method after finding one - I assumed hotel names are distinct
            for (int i = 0; i < HotelService.Data.Count; i++)
            {
                if (HotelService.Data[i].HotelInfo.Name.ToUpper().Equals(searchedName.ToUpper()))
                {
                    exactMatch++;
                    foundHotels.Add(i);
                }
            }
            if (exactMatch != 0)
            {
                return foundHotels;
            }
            else
            //if no exact match has been found- we look for partial match and return all the hotels found
            {
                for (int i = 0; i < HotelService.Data.Count; i++)
                {
                    if (HotelService.Data[i].HotelInfo.Name.ToUpper().Contains(searchedName.ToUpper()))
                    {
                        foundHotels.Add(i);
                    }
                }
                return foundHotels;
            }
        }
    }
}
