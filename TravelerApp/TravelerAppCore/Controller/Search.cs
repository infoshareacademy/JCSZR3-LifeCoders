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

        public class SearchRate
        {
            public static void ByRating(List<Hotel> targetData, float Rating)
            {
                List<Hotel> hotelRaiting = new List<Hotel>();

                foreach (Hotel hotel in targetData)
                {
                    float hotelRating = 0;
                    int count = 0;


                    for (int i = 0; i < hotel.Reviews.Count; i++)
                    {
                        hotelRating += hotel.Reviews[i].Ratings.Overall;

                        count++;
                    }

                    float AverageHotelRating = hotelRating / count;
                    if (AverageHotelRating == 0)
                    {
                        continue;
                    }

                    if (AverageHotelRating >= Rating)
                    {
                        hotelRaiting.Add(hotel);

                    }
                }
            }
        }
    }
}

