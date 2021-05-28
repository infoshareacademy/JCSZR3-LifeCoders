using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Controller
{
   public class Sort
    {
        public static void sort(List<Root> targetData)
        {
            List<Root> hotelRatings = targetData;


            // hotelPrice.Sort();

            hotelRatings.Sort(IComparer);


            DrawTable.PrintLine();
            DrawTable.PrintRow(true,"hotelId", "Name", "Price", "Ratings");

            foreach (var hotel in hotelRatings)
            {
                DrawTable.PrintLine();
                DrawTable.PrintRow(true, hotel.HotelInfo.HotelID, hotel.HotelInfo.Name, hotel.HotelInfo.Price, hotel.Reviews[2].Ratings.Overall.ToString());
                
            }
            DrawTable.PrintLine();
            
        }

        private static int IComparer(Root x, Root y)
        {
            if (x.Reviews[2].Ratings.Overall < y.Reviews[2].Ratings.Overall)
                return 1;
            else if (x.Reviews[2].Ratings.Overall > y.Reviews[2].Ratings.Overall)
                return -1;
            else
                return 0;
        }
    }
}
