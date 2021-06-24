using BusFinderAppCore.Control;
using BusFinderAppCore.Models;

namespace BusFinderAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
        }
    }
}
