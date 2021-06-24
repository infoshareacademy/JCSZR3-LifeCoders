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

        // Rozpakowywanie wszystkich plików JSON, z dowolnego katalogu i dowolnej klasy
        // Katalog musi znajdować się w BusFinderAppCore
        // Jako T podajemy rodzaj klasy jaką mamy w plikach
        // Directory nazwa katalogu w którym mamy pliki może to też być np. Data\Coś
        // Metoda zwraca listę obiektów, które były w pojedyńczych plikach JSON
        public static List<T> LoadJsonFiles<T>(string directory)
        {
            // Nowa lista zadanych obiektów 
            List<T> Data = new List<T>();
            // Pobranie domyślnej ścieżki
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Stworzenie ścieżki do wybranego katalogu
            string path = Path.Combine(currentDirectory, $@"..\..\..\..\BusFinderAppCore\{directory}");
            string sPath = Path.GetFullPath(path);
            // Stworzenie tablicy stringów z nazwmi plików z które są typu JSON 
            string[] jsonFiles = Directory.GetFiles(sPath, "*.json").Select(Path.GetFileName).ToArray();
            // Iteracja po tablicy i wykorzystanie metody dla jednego pliku 
            foreach (var file in jsonFiles)
            {
                Data.Add(JSON.LoadJsonFile<T>(file));
            }

            return Data;
        }
    }
}
