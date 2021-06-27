using System.Collections.Generic;

namespace BusFinderAppCore.Models
{
    public class Itinerary
    {
        public string Through_the_stations { get; set; }
        public Datetime Datetime { get; set; }
        public string Line_direction { get; set; }
        public List<Route> Route { get; set; }
        public int Ride_id { get; set; }
        public string Trip_uid { get; set; }
        public bool Has_tracker { get; set; }
        public bool Is_cancelled { get; set; }
        public string Line_code { get; set; }
        public string Direction { get; set; }
    }
}
