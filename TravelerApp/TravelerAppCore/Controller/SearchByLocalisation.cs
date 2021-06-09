using System.Collections.Generic;
using System.Text.RegularExpressions;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Models
{
    public static class SearchByLocalisation
    {
        public static List<Root> ByLocalisation(List<Root> targetData, string address)
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
            return hotelLocalisation;
        }
    }
}
