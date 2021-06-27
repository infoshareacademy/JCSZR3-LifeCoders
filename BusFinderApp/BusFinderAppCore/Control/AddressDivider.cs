using BusFinderAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BusFinderAppCore.Control
{
    public class AddressDivider
    {
        //Aleje Jerozolimskie 144, 02-303 Warszawa, Polska
        //ul.Marszalkowska 104/122, 00-017 Warszawa, Polen
       //ul.Grochowska / Al.Stanów Zjednoczonych, 04-357 Warszawa, Polska
       //kod pocztowy- czy rozdzielamy teraz za pomoca regex czy na pozniejszym etapie, gdy
       // bedziemy zapisywac dane wejsciowe do sql servera i kod bedzie w osobnej kolumnie
       public static void divider()
        {
            foreach (var station in JSON.ShceduleList)
            {
                var address = station.station.default_address.full_address;
                Regex rg = new Regex(@"(?<street>.+),\s(?<town>.+),\s(?<country>.+)");
                var addressMatch = rg.Match(address);
                station.station.default_address.Street = addressMatch.Groups["street"].Value;
                station.station.default_address.Town = addressMatch.Groups["town"].Value;
                station.station.default_address.Country = addressMatch.Groups["country"].Value;
            }
        }

    }
}
