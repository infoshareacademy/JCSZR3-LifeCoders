namespace BusFinderAppCore.Models
{
    public class ScheduleForStation 
    {
        public Schedule schedule { get; set; }
        public Station station { get; set; }
        public object Date { get; internal set; }
        public object Clock { get; internal set; }
        public object DateTime { get; internal set; }
    }
}
