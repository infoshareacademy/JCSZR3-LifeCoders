namespace BusFinderAppCore.Models
{
    public class Station
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public DefaultAddress default_address { get; set; }
        public string address { get; set; }
        public string full_address { get; set; }
        public Coordinates coordinates { get; set; }
    }
}
