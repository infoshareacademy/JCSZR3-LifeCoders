using System;
using System.IO;
using System.Collections.Generic;
using TravelerAppCore.Models.Hotels;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;

namespace TravelerFacebookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DeserializeJson();
        }

        static void DeserializeJson()
        {
            var stopper = new Stopwatch();
            stopper.Start();
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
            string sFilePath = Path.GetFullPath(sFile);
            string[] jsonFiles = Directory.GetFiles(sFilePath, "*.json").Select(Path.GetFileName).ToArray();
            List<Root> targetData = new List<Root>();

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
            Console.WriteLine("[POINTER] Koniec deserializacji");
        }
    }
}
