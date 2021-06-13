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
            List<Hotel> hotelRatings = new List<Hotel>();
           
            var SORT = hotelRatings.OrderByDescending(x => x.AverageRates.Overall);
           var sort1= SORT.ToList();
           return sort1;

        }


       
    }
}
