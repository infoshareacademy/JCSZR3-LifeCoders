using System.Collections.Generic;

namespace BusFinderAppCore.Models
{
    public class Itinerary
    {
        public string through_the_stations { get; set; }
        public Datetime datetime { get; set; }
        public string line_direction { get; set; }
        public List<Route> route { get; set; }
        public int ride_id { get; set; }
        public string trip_uid { get; set; }
        public bool has_tracker { get; set; }
        public bool is_cancelled { get; set; }
        public string line_code { get; set; }
        public string direction { get; set; }
    }
}
