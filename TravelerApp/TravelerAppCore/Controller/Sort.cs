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
        public static void sortByRatings(List<Hotel> targetData)
        {
            List<Hotel> hotelRatings = new List<Hotel>();
            hotelRatings = targetData;
            var SORT = hotelRatings.OrderByDescending(x => x.AverageRates.Overall);
           var sort1= SORT.ToList();
            display(sort1);
 
        }

  
        public static void display(List<Hotel> targetdata)
        {
            DrawTable.PrintLine();
            DrawTable.PrintRow(true, "hotelId", "Name", "Price", "Ratings");

            foreach (var hotel in targetdata)
            {
                DrawTable.PrintLine();
                DrawTable.PrintRow(true, hotel.HotelInfo.HotelID, hotel.HotelInfo.Name, hotel.HotelInfo.Price, hotel.AverageRates.Overall.ToString("0.00"));

            }
            DrawTable.PrintLine();


        }
    }
}
