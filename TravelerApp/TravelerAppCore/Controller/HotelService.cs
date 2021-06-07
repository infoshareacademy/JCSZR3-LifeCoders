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
    public class HotelService
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
            string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string File = Path.Combine(CurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
            string FilePath = Path.GetFullPath(File);
            string[] jsonFiles = Directory.GetFiles(FilePath, "*.json").Select(Path.GetFileName).ToArray();

            foreach (var item in jsonFiles)
            {
                string sFileJson = Path.Combine(FilePath, item);
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
            string JsonFile = JsonConvert.SerializeObject(Data.Last());
            string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string File = Path.Combine(CurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
            string FilePath = Path.GetFullPath(File);
            Console.WriteLine("\nPodaj nazwę pliku do zapisu");
            string Name = Console.ReadLine();
            string FileJson = Path.Combine(FilePath, $"{Name}.json");
            try
            {
                using (StreamWriter sw = new StreamWriter(FileJson))
                {
                    sw.WriteLine(JsonFile);
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
