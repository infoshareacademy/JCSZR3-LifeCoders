using System;
using BusFinderAppCore.Models;

namespace BusFinderAppCore.Control
{
    public class Converter
    {
        public static void TimestampToDate()
        {
            DateTime beginDate = new DateTime(1970, 1, 1, 0, 0, 0);
            foreach (ScheduleForStation schedule in JSON.ShceduleList)
            {
                foreach (Itinerary arrival in schedule.schedule.arrivals)
                {
                    double ArivalTimestamp = (double)arrival.datetime.timestamp;
                    arrival.datetime.Date = beginDate.AddSeconds(ArivalTimestamp).ToLocalTime();
                }

                foreach (Itinerary departure in schedule.schedule.departures)
                {
                    double DeparturesTimestamp = (double) departure.datetime.timestamp;
                    departure.datetime.Date = beginDate.AddSeconds(DeparturesTimestamp).ToLocalTime();
                }
            }

        }
    }
}
