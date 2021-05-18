using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Models
{
    public static class Searching
    { 
        public static List<Root> byLocalisation(List<Root> targetData, string localisation)
        {
            List<Root> hotelLocalisation = new List<Root>();

            foreach(Root hotel in targetData)
            {
                if(hotel.HotelInfo.Address == localisation)
                {
                    hotelLocalisation.Add(hotel);
                }
            }

            return hotelLocalisation;
        }
    }
}
