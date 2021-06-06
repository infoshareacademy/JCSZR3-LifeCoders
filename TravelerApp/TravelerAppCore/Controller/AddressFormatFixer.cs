using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public class AddressFormatFixer
    {
        public static List<Root> FixAddress (List<Root> baseData)
        {
            foreach (Root hotel in baseData)
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
    }
}
