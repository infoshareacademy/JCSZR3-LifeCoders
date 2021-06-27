namespace BusFinderAppCore.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public DefaultAddress Default_address { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
