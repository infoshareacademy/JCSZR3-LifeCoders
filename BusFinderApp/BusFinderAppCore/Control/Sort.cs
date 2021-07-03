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

        public static List<ScheduleForStation> SortbyTown(string option)
        {
            List<ScheduleForStation> ShceduleList = new List<ScheduleForStation>();
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");

            if (option == "A")
                return JSON.ShceduleList.OrderBy(x => x.station.default_address.Town).ToList();
            else if (option == "Z")
                return JSON.ShceduleList.OrderByDescending(x => x.station.default_address.Town).ToList();
            else return
                    JSON.ShceduleList;
        
          
        }
        public static List<ScheduleForStation> SortbyStreet(string option)
        {
            List<ScheduleForStation> ShceduleList = new List<ScheduleForStation>();
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");

            if (option == "A")
                return JSON.ShceduleList.OrderBy(x => x.station.default_address.Street).ToList();
            else if (option == "Z")
                return JSON.ShceduleList.OrderByDescending(x => x.station.default_address.Street).ToList();
            else return
                    JSON.ShceduleList;


        }
        public static List<Itinerary> SortByDate()
        {

            List<ScheduleForStation> ShceduleList = new List<ScheduleForStation>();
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
            var itinerary= JSON.ShceduleList.SelectMany(x=>x.schedule.departures).ToList();
            return itinerary.OrderBy(x => x.datetime.timestamp).ToList();

        }
  
    }
}
