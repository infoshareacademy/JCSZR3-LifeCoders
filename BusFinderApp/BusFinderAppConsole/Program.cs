using BusFinderAppCore.Control;
using BusFinderAppCore.Models;


namespace BusFinderAppConsole
{
    class Program
    {
        
        static void Main(string[] args)
        { 
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
            foreach (var item in JSON.ShceduleList)
            {
                System.Console.WriteLine(item.station.address + " " + item.station.full_address);
                System.Console.WriteLine();
            }
            System.Console.WriteLine("**************************************************");
            var jakas = Sort.SortbyAddress("Z");
            foreach (var item in jakas)
            {
                System.Console.WriteLine(item.station.address + " " + item.station.full_address);

            }
            System.Console.WriteLine("**************************************************");
            var jakas1 = Sort.SortByDate();
            foreach (var item in jakas1)
            {
                System.Console.WriteLine(item.datetime.timestamp + " " + item.direction);
            }
        }
    }
}
