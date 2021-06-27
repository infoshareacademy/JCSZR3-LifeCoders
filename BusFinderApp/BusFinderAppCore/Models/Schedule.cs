using System.Collections.Generic;

namespace BusFinderAppCore.Models
{
    public class Schedule
    {
        public List<Itinerary> Arrivals { get; set; }
        public List<Itinerary> Departures { get; set; }
        public string Message { get; set; }
    }
}
