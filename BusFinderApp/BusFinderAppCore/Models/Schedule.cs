using System.Collections.Generic;

namespace BusFinderAppCore.Models
{
    public class Schedule
    {
        public List<Itinerary> arrivals { get; set; }
        public List<Itinerary> departures { get; set; }
        public string message { get; set; }
    }
}
