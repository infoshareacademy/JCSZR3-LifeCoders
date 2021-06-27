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
          return  JSON.ScheduleList.Where(x => x.Station.Default_address.Town.Contains(town)).ToList();            
        }

        public static List<ScheduleForStation> ByCountry(string country)
        {
            return JSON.ScheduleList.Where(x => x.Station.Default_address.Country.Contains(country)).ToList();
        }

        public static List<ScheduleForStation> ByName(string name)
        {
            return JSON.ScheduleList.Where(x => x.Station.Name.Contains(name)).ToList();
        }

    }
}
