using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
   public class Sort
    {
        public static void sort(List<Root> targetData)
        {
            List<Root> hotelPrice = new List<Root>();
            foreach (Root hotel in targetData)
            {
                if (hotel.HotelInfo.Price != null)
                {
                    hotelPrice.Add(hotel);
                }
                
               
            }

           // hotelPrice.Sort();

            foreach (Root hotel1 in hotelPrice)
            {
                Console.WriteLine(hotel1.HotelInfo.Name+" "+hotel1.HotelInfo.Price);


            }
        }



    }
}
