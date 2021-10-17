using Newtonsoft.Json;

namespace BusFinderAppCore.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("default_address")]
        public DefaultAddress DefaultAddress { get; set; }
        public string Address { get; set; }

        [JsonProperty("full_address")]
        public string FullAddress { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
