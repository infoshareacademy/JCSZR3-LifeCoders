using System;
using System.Collections.Generic;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.Models;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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
            hotelThree.Address = ">Warszawa<";
            hotelOne.HotelID = "4567";
            hotelTwo.HotelID = "5632";
            hotelThree.HotelID = "12345";
            hotelOne.Name = "Hotel 1";
            hotelTwo.Name = "Hotel 2";
            hotelThree.Name = "Hotel 3";
            hotelOne.HotelURL = "www.Coscos.com";
            hotelTwo.HotelURL = "www.RLo.com";
            hotelThree.HotelURL = "www.opos.com";
            hotelOne.Price = "120-245";
            hotelTwo.Price = "150-222";
            hotelThree.Price = "111-123";


            Root rootOne = new Root();
            Root rootTwo = new Root();
            Root rootThree = new Root();
            rootOne.HotelInfo = hotelOne;
            rootTwo.HotelInfo = hotelTwo;
            rootThree.HotelInfo = hotelThree;

            List<Root> rooteList = new List<Root>();
            rooteList = JSON.Read(rooteList);
            rooteList.Add(rootOne);
            rooteList.Add(rootTwo);
            rooteList.Add(rootThree);
            Console.WriteLine(rooteList[1].HotelInfo.Address);
            Search.byLocalisation(rooteList);

        }
    }

    public static class JSON
    {
        public static List<Root> Read(List<Root> targetData)
        {
            var stopper = new Stopwatch();
            stopper.Start();
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
            string sFilePath = Path.GetFullPath(sFile);
            string[] jsonFiles = Directory.GetFiles(sFilePath, "*.json").Select(Path.GetFileName).ToArray();

            foreach (var item in jsonFiles)
            {
                string sFileJson = Path.Combine(sFilePath, item);
                try
                {
                    string jsonFromFiles;
                    using (StreamReader reader = new StreamReader(sFileJson))
                    {
                        jsonFromFiles = reader.ReadToEnd();
                        targetData.Add(JsonConvert.DeserializeObject<Root>(jsonFromFiles));
                    }
                }
                catch (Exception ex)
                {
                }
            }
            stopper.Stop();
            Console.WriteLine($"Czas odczytu wszystkich plików: {stopper.Elapsed}");
            Console.WriteLine($"Ilość odczytanych plików: {targetData.Count()}");
            Console.WriteLine("Koniec deserializacji");
            return targetData;
        }
        public static void Write(List<Root> targetData)
        {

        }
    }
}
