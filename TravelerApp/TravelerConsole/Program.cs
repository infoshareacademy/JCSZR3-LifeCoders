using System;
using System.Collections.Generic;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.Models;

namespace TravelerFacebookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelInfo hotelOne = new HotelInfo();
            HotelInfo hotelTwo = new HotelInfo();
            HotelInfo hotelThree = new HotelInfo();
            hotelOne.Address = "Warszawa";
            hotelTwo.Address = "Wrocław";
            hotelThree.Address = "Wołomin";
            Root rootOne = new Root();
            Root rootTwo = new Root();
            Root rootThree = new Root();
            rootOne.HotelInfo = hotelOne;
            rootTwo.HotelInfo = hotelTwo;
            rootThree.HotelInfo = hotelThree;

            List<Root> rooteList = new List<Root>();
            rooteList.Add(rootOne);
            rooteList.Add(rootTwo);
            rooteList.Add(rootThree);

            List<Root> rooteListAdrees = Searching.byLocalisation(rooteList, "W");

            Console.WriteLine(rooteListAdrees[0].HotelInfo.Address);
            Console.WriteLine(rooteListAdrees[1].HotelInfo.Address);
            Console.WriteLine(rooteListAdrees[2].HotelInfo.Address);



        }
    }
}
