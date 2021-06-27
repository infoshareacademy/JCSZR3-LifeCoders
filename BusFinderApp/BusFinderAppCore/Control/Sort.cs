using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusFinderAppCore.Models;

namespace BusFinderAppCore.Control
{
   public class Sort
    {

        public static List<ScheduleForStation> SortbyAddress(string option)
        {
            List<ScheduleForStation> ShceduleList = new List<ScheduleForStation>();
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");

            if (option == "A")
                return JSON.ShceduleList.OrderBy(x => x.station.address).ToList();
            else if (option == "Z")
                return JSON.ShceduleList.OrderByDescending(x => x.station.address).ToList();
            else if (option == "fa")
                return JSON.ShceduleList.OrderBy(x => x.station.full_address).ToList();
            else if (option == "fz")
                return JSON.ShceduleList.OrderByDescending(x => x.station.full_address).ToList();
            else
                return JSON.ShceduleList;
        }

        public static List<Itinerary> SortByDate()
        {

            List<ScheduleForStation> ShceduleList = new List<ScheduleForStation>();
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
            var itinerary= JSON.ShceduleList.SelectMany(x=>x.schedule.arrivals).ToList();
            return itinerary.OrderBy(x => x.datetime.timestamp).ToList();

        }
  
    }
}
