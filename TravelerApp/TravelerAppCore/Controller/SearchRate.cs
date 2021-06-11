using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Controller
{
    
    public class SearchRate
    {
        

        public static void ByRating (List<Root> targetData, float Rating)
        {
            List<Root> hotelRaiting = new List<Root>();

            foreach (  Root hotel in targetData)
            {
                float hotelRating = 0;
                int count = 0;


                for (int i = 0; i < hotel.Reviews.Count; i++)
                {
                    hotelRating +=hotel.Reviews[i].Ratings.Overall; 
                   
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

            int hotelcount = hotelRaiting.Count;
            DrawTable.Hotelinfo(hotelRaiting, hotelcount);

        }

        
    }
}
