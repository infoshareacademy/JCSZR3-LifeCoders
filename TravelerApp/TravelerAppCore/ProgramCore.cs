using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore
{
    public class ProgramCore
    {

        // Initialization.  
        Hotels jsonHotel = new Hotels();

        // Prepare sample Data.  
        // Serialize Data.  
        //string data = JsonConvert.SerializeObject(jsonObj);  

        private string[] jsonFiles = Directory.GetFiles("C:\\Documents", "*.json").Select(Path.GetFileName).ToArray(); //Troszku Linku nie zaszkodzi "Select"

        // Deserialize Data.  

        //Hotels targetData = JsonConvert.DeserializeObject<Hotels>(data);
    }
}
