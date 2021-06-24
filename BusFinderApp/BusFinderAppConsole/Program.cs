using BusFinderAppCore.Control;
using BusFinderAppCore.Models;

namespace BusFinderAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rozpakowanie plików JSON do listy elementów
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
        }
    }
}
