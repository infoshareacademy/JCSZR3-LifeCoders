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
            hotelOne.Address = ">Warszawa<";
            hotelTwo.Address = "<address class=\"addressReset\"><span rel=\"v:address\"><span dir=\"ltr\"><span class=\"street-address\" property=\"v:street-address\">1025 de Bleury Street</span>, <span class=\"locality\"><span property=\"v:locality\">Warszawa</span>, <span property=\"v:region\">Quebec</span> <span property=\"v:postal-code\">H2Z 1M7</span></span>, <span class=\"country-name\" property=\"v:country-name\">Canada</span> </span></span></address>";
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

            List<Root> rooteListAdrees = Search.byLocalisation(rooteList);

            Console.WriteLine(rooteListAdrees[0].HotelInfo.Address);
            Console.WriteLine(rooteListAdrees[1].HotelInfo.Address);
            //Console.WriteLine(rooteListAdrees[2].HotelInfo.Address);



        }
    }
}
