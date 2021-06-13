using System;
using TravelerAppCore.Controller;
using TravelerAppCore.View;

namespace TravelerAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ustawia wysokość i szerokość okna konsoli na określone wartości.
            Console.SetWindowSize(200, 30);

            HotelService.Read();
            int numberOfRecords = 12;
            DrawTable.Hotelinfo(HotelService.Data, numberOfRecords);

            //string searchedName = "BEST WESTERN Loyal Inn";// "Christopher's Inn";
            //List<int> list = SearchByName.HotelsByName(dataRead, searchedName);
            ////list.Sort();
            //List<Hotel> hotelsReturnedByName = new List<Hotel>();
            //foreach (int item in list)
            //{
            //   // Console.WriteLine(dataRead[item].HotelInfo.Name);
            //    hotelsReturnedByName.Add(dataRead[item]);
            //}
            //Console.WriteLine($"Hotels having {searchedName} in their names" );
        }
    }
}