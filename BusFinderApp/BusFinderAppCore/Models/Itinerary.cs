using System;
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
        public string timestamp { get; set; }
        public string GetTime()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(datetime.timestamp).ToLocalTime().ToString("HH:mm");
        }

        public string GetDay()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(datetime.timestamp).ToLocalTime().ToString("dd.MM.yyyy");
        }
    }

    
}
