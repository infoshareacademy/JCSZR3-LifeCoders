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
        public static List<Hotel> SortByRatings()
        {
            var SORT = HotelService.Data.OrderByDescending(x => x.AverageRates.Overall).ToList();
           return SORT;
        }
    }
}
