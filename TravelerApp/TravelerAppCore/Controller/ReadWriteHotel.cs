using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TravelerAppConsole;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Controller
{
    public class ReadWriteHotel
    {
        public static void ReadAndDisplay(List<Hotel> dataReaded)
        {
            Read(dataReaded);
            DisplayLoadedData(dataReaded);
        }
        public static Stopwatch stopper = new Stopwatch();
        public static void Read(List<Hotel> dataReaded)
        {
            stopper.Start();
            dataReaded.Clear();
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
                        dataReaded.Add(JsonConvert.DeserializeObject<Hotel>(jsonFromFiles));
                    }
                }
                catch (Exception ex)
                {
                }
            }
            stopper.Stop();

        }
        public static void DisplayLoadedData(List<Hotel> dataReaded)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Czas odczytu wszystkich plików: {stopper.Elapsed}");
            Console.WriteLine($"Ilość odczytanych plików: {dataReaded.Count()}");
            Console.WriteLine("Koniec deserializacji");
            Console.WriteLine("----------------------------------------------------\n");
            DrawTable.Hotelinfo(dataReaded, dataReaded.Count(), true);
        }

        public static void WriteAndDisplay(List<Hotel> dataReaded)
        {
            Write(dataReaded);
            DisplaySavedData(dataReaded);
        }

        public static void Write(List<Hotel> targetData)
        {
            string sJsonFile = JsonConvert.SerializeObject(targetData.Last());
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
        public static void DisplaySavedData(List<Hotel> targetData)
        {
            Console.Clear();
            new Menu().DisplayMenu();
            Console.SetCursorPosition(0, Menu.MenuList.Count() + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Plik został zapisany!");
            Console.ResetColor();
            DrawTable.Hotelinfo(new List<Hotel>() { targetData.Last() }, 1, true);
        }
    }
}
