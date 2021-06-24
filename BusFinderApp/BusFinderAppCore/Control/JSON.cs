using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BusFinderAppCore.Models;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace BusFinderAppCore.Control
{
    public class JSON
    {
        // Lista obiektów

        public static List<ScheduleForStation> ShceduleList = new List<ScheduleForStation>();

        // Rozpakowywanie pojedyńczego pliku JSON, może to być dowolna instatncja klasy
        // Jako T trzeba podać rodzaj klasy jaką mamy w pliku u nas jest to ScheduleForStation
        // File name to nazwa pojedyńczego pliku np. 10118.json
        // Metoda zwraca obiekt, który był w pliku JSON.
        public static T LoadJsonFile<T>(string fileName)
        {
            T Data;
            // Pobranie domyślnej ścieżki projketu
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Stowrzenie ścieżki do katalogu Data i wybranie pliku fileName --> "..\..\..\..\" ten kawłek cofa do katalogu głownego aplikacji
            string path = Path.Combine(currentDirectory, $@"..\..\..\..\BusFinderAppCore\Data\{fileName}");
            // Odczyt i deserializacja pliku na dany typ obiektu 
            using (StreamReader reader = new StreamReader(path))
            {
                path = reader.ReadToEnd();
                Data = JsonConvert.DeserializeObject<T>(path);
            }


            return Data;
        }

        // Rozpakowywanie wszystkich plików JSON, z katalogu Data, tak samo może dotyczyć dowolnego katalogu 
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
