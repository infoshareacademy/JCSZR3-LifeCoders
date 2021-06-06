using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TravelerAppConsole;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Controller
{
    public class ReadWriteHotel
    {
        public static void ReadAndDisplay(List<Hotel> Data)
        {
            Read(Data);
            DisplayLoadedData(Data);
        }
        public static Stopwatch stopper = new Stopwatch();
        public static void Read(List<Hotel> Data)
        {
            stopper.Start();
            Data.Clear();
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
                        Data.Add(JsonConvert.DeserializeObject<Hotel>(jsonFromFiles));
                    }
                }
                catch (Exception ex)
                {
                }
            }
            Data = FixAddress(Data);
            stopper.Stop();
        }
        public static List<Hotel> FixAddress(List<Hotel> baseData)
        {
            foreach (Hotel hotel in baseData)
            {
                var address = Regex.Replace(hotel.HotelInfo.Address, "<.*?>", string.Empty);

                Regex rg = new Regex(@"(?<street>.+),\s(?<city>.+),\s(?<postalCode>.+)");
                var addressMatch = rg.Match(address);
                string street = addressMatch.Groups["street"].Value;
                string city = addressMatch.Groups["city"].Value;
                string postalCode = addressMatch.Groups["postalCode"].Value;

                street = street.Trim();
                city = city.Trim();
                postalCode = postalCode.Trim();

                hotel.HotelInfo.Address = $"{city}, {street}, {postalCode}";

            }
            return baseData;
        }

        public static void DisplayLoadedData(List<Hotel> Data)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Czas odczytu wszystkich plików: {stopper.Elapsed}");
            Console.WriteLine($"Ilość odczytanych plików: {Data.Count()}");
            Console.WriteLine("Koniec deserializacji");
            Console.WriteLine("----------------------------------------------------\n");
            DrawTable.Hotelinfo(Data, Data.Count, true);

        }

        public static void WriteAndDisplay(List<Hotel> Data)
        {
            Write(Data);
            DisplaySavedData(Data);
        }

        public static void Write(List<Hotel> Data)
        {
            string sJsonFile = JsonConvert.SerializeObject(Data.Last());
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
            string sFilePath = Path.GetFullPath(sFile);

            Console.WriteLine("\nPodaj nazwę pliku do zapisu");
            string sName = Console.ReadLine();

            string sFileJson = Path.Combine(sFilePath, $"{sName}.json");
            try
            {

                using (StreamWriter sw = new StreamWriter(sFileJson))
                {
                    sw.WriteLine(sJsonFile);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static void DisplaySavedData(List<Hotel> Data)
        {
            Console.Clear();
            new Menu().DisplayMenu();
            Console.SetCursorPosition(0, Menu.MenuList.Count() + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Plik został zapisany!");
            Console.ResetColor();
            if (!Menu.MultipleOptions && Data.Count() != 0) DrawTable.Hotelinfo(new List<Hotel>() { Data.Last() }, 1, true);
        }

    }
}
