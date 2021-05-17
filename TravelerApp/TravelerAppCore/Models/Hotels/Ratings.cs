using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerAppCore.Models.Hotels
{
    public class Ratings
    {
        public string Overall { get; set; }
        public string Service { get; set; }
        public string Cleanliness { get; set; }
        public string Value { get; set; }
        public string SleepQuality { get; set; }
        public string Rooms { get; set; }
        public string Location { get; set; }

        [JsonProperty("Checkin/frontdesk")]
        public string CheckinFrontdesk { get; set; }

        [JsonProperty("Businessservice(e.g.,internetaccess)")]
        public string BusinessserviceEGInternetaccess { get; set; }
    }
}
