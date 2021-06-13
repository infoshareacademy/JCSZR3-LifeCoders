using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Controller
{
   public class Sort
    {
        public static List<Hotel> sortByRatings()
        {
          
            var SORT = HotelService.Data.OrderByDescending(x => x.AverageRates.Overall);
           var sort1= SORT.ToList();
           return sort1;

        }
        public static void display()
        {
            DrawTable.PrintLine();
            DrawTable.PrintRow(true, "hotelId", "Name", "Price", "Ratings");
            List<Hotel> hotelRatings = Sort.sortByRatings();
            foreach (var hotel in hotelRatings)
            {
                DrawTable.PrintLine();
                DrawTable.PrintRow(true, hotel.HotelInfo.HotelID, hotel.HotelInfo.Name, hotel.HotelInfo.Price, hotel.AverageRates.Overall.ToString("0.00"));

            }
            DrawTable.PrintLine();


        }


    }
}
