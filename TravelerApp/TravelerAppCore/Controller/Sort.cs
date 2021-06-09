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
        public static void sortByRatings(List<Root> targetData)
        {
            List<Root> hotelRatings = targetData;


           

            hotelRatings.Sort(IComparer);

            show(hotelRatings);

           
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
        public static void show(List<Root> targetdata)
        {
            DrawTable.PrintLine();
            DrawTable.PrintRow(true, "hotelId", "Name", "Price", "Ratings");

            foreach (var hotel in targetdata)
            {
                DrawTable.PrintLine();
                DrawTable.PrintRow(true, hotel.HotelInfo.HotelID, hotel.HotelInfo.Name, hotel.HotelInfo.Price, hotel.Reviews[2].Ratings.Overall.ToString());

            }
            DrawTable.PrintLine();


        }
    }
}
