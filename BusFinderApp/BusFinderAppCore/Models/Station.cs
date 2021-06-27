namespace BusFinderAppCore.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public DefaultAddress Default_address { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
