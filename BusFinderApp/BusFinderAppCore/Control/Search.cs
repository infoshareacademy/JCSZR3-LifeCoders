using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusFinderAppCore.Models;

namespace BusFinderAppCore.Control
{
    public class Search
    {
        //czy w wyszukiwaniu ma byc exact match na poczatku i wyroznione?
        //czy wypisujemy wyniki w jednej liscie
        public static  List<ScheduleForStation> ByTown(string town)
        {
          return  JSON.ShceduleList.Where(x => x.station.default_address.Town.Contains(town)).ToList();            
        }

        public static List<ScheduleForStation> ByCountry(string country)
        {
            return JSON.ShceduleList.Where(x => x.station.default_address.Country.Contains(country)).ToList();
        }

        public static List<ScheduleForStation> ByName(string name)
        {
            return JSON.ShceduleList.Where(x => x.station.Name.Contains(name)).ToList();
        }

    }
}
