using BusFinderAppCore.Control;
using BusFinderAppCore.Models;
using System;

namespace BusFinderAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            JSON.ShceduleList = JSON.LoadJsonFiles<ScheduleForStation>("Data");
            Converter.TimestampToDate();

            Console.ReadLine();
        }
    }
}
