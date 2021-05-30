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
                int commaCounter = 0;

                Regex rg = new Regex(@"(?<street>.+),\s(?<city>.+),\s(?<postalCode>.+)");
                var addressMatch = rg.Match(address);
                string street = addressMatch.Groups["street"].Value;
                string city = addressMatch.Groups["city"].Value;
                string postalCode = addressMatch.Groups["postalCode"].Value;

                //foreach (var letter in hotel.HotelInfo.Address)
                //{
                //    if (letter != ',')
                //    {
                //        switch (commaCounter)
                //        {
                //            case 0:
                //                street += letter;
                //                break;
                //            case 1:
                //                city += letter;
                //                break;
                //            case 2:
                //                postalCode += letter;
                //                break;
                //            default:
                //                break;

                //        }
                //    } else
                //    {
                //        commaCounter++;
                //    }
                // }

                street = street.Trim();
                city = city.Trim();
                postalCode = postalCode.Trim();

                hotel.HotelInfo.Address = $"{city}, {street}, {postalCode}";

            }
            return baseData;
        }
    }
}
