using System.Collections.Generic;
using System.Linq;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public class Sort
    {
        public static List<Hotel> DataToSort =  new List<Hotel>();
        public static List<Hotel> OrderByName()
        {
            return DataToSort.OrderBy(x => x.HotelInfo.Name).ToList();
        }
        public static List<Hotel> OrderByAddress()
        {
            return DataToSort.OrderBy(x => x.HotelInfo.Address).ToList();
        }
        public static List<Hotel> OrderByAverageOverall()
        {
            return DataToSort.OrderByDescending(x => x.AverageRates.Overall).ToList();
        }
        public static List<Hotel> OrderByPrice()
        {
            return DataToSort.OrderBy(x => x.HotelInfo.Price).ToList();
        }
        public static void DataOrder(List<Hotel> DataOrder)
        {
            Sort.DataToSort.Clear();
            Sort.DataToSort.AddRange(DataOrder);
        }
    }
}
