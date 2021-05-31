using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public class JSON
    {
        public static void Read(List<Root> targetData)
        {
            var stopper = new Stopwatch();
            stopper.Start();
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_CreatedHotels");
            //string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
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
            Console.WriteLine("\n----------------------------------------------------");
            Console.WriteLine($"Czas odczytu wszystkich plików: {stopper.Elapsed}");
            Console.WriteLine($"Ilość odczytanych plików: {targetData.Count()}");
            Console.WriteLine("Koniec deserializacji");
            Console.WriteLine("----------------------------------------------------\n");
        }

        public static void Write()
        {
            string sJsonFile = JsonConvert.SerializeObject(AddHotelInfo.CreateNew());

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_CreatedHotels");
            string sFilePath = Path.GetFullPath(sFile);

            Console.WriteLine("Podaj nazwę pliku do zapisu");
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
    }
}
