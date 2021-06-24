using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusFinderAppCore.Models;
using Newtonsoft.Json;

namespace BusFinderAppCore.Control
{
    public class JSON
    {
        public static List<ScheduleForStation> ShceduleList = new List<ScheduleForStation>();
        public static T LoadJsonFile<T>(string fileName)
        {
            T Data;

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(currentDirectory, $@"..\..\..\..\BusFinderAppCore\Data\{fileName}");

            using (StreamReader reader = new StreamReader(path))
            {
                path = reader.ReadToEnd();
                Data = JsonConvert.DeserializeObject<T>(path);
            }
            return Data;
        }

        public static List<T> LoadJsonFiles<T>(string directory)
        {
            List<T> Data = new List<T>();

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(currentDirectory, $@"..\..\..\..\BusFinderAppCore\{directory}");
            string sPath = Path.GetFullPath(path);
            string[] jsonFiles = Directory.GetFiles(sPath, "*.json").Select(Path.GetFileName).ToArray();

            foreach (var file in jsonFiles)
            {
                Data.Add(JSON.LoadJsonFile<T>(file));
            }

            return Data;
        }
    }
}
