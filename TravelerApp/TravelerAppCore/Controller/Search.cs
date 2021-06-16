using System.Collections.Generic;
using System.Linq;
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

            string nameChanged = name.Replace(" ", string.Empty).ToUpper();

            //check if a search name has at least one character in it
            // search for an exact match first- if found we exit a method after finding one - I assumed hotel names are distinct
            foreach (Hotel hotel in HotelService.Data)
            {
                if (hotel.HotelInfo.Name.Replace(" ", string.Empty).ToUpper().Equals(nameChanged))
                {
                    foundHotels.Add(hotel);
                }
            }
            //if no exact match has been found- we look for partial match and return all the hotels found
            if (foundHotels.Count == 0)
            {
                foreach (Hotel hotel in HotelService.Data)
                {
                    if (hotel.HotelInfo.Name.Replace(" ", string.Empty).ToUpper().Contains(nameChanged))
                    {
                        foundHotels.Add(hotel);
                    }
                }
            }
            return foundHotels;
        }
        public static List<Hotel> ByRate(float Rating)
        {
            return HotelService.Data.Where(x => x.AverageRates.Overall >= Rating).ToList();
        }

    }
}

