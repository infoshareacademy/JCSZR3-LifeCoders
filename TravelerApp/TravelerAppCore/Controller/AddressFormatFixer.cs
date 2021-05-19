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
                hotel.HotelInfo.Address = Regex.Replace(hotel.HotelInfo.Address, "<.*?>", string.Empty);
                int commaCounter = 0;

                string street = "";
                string city = "";
                string postalCode = "";

                foreach (var letter in hotel.HotelInfo.Address)
                {
                    if (letter != ',')
                    {
                        switch (commaCounter)
                        {
                            case 0:
                                street += letter;
                                break;
                            case 1:
                                city += letter;
                                break;
                            case 2:
                                postalCode += letter;
                                break;
                            default:
                                break;

                        }
                    } else
                    {
                        commaCounter++;
                    }
                }

                street = street.Trim();
                city = city.Trim();
                postalCode = postalCode.Trim();

                hotel.HotelInfo.Address = $"{city}, {street}, {postalCode}";

            }
            return baseData;
        }
    }
}
