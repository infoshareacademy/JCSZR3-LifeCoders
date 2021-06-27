namespace BusFinderAppCore.Models
{
    public class DefaultAddress
    {
        public string address { get; set; }
        public string full_address { get; set; }
        public Coordinates coordinates { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
    }
}
