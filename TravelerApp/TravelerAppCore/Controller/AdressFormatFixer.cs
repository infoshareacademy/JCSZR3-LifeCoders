using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public class AdressFormatFixer
    {
        public static List<Root> FixAdress (List<Root> baseData)
        {
            foreach (Root hotel in baseData)
            {
                hotel.HotelInfo.Address = Regex.Replace(hotel.HotelInfo.Address, "<.*?>", string.Empty);
                int counter = 0;
                string street = "";
                string city = "";
                string postalCode = "";
                string more = "";

                foreach (var letter in hotel.HotelInfo.Address)
                {
                    if (letter != ',')
                    {
                        switch (counter)
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
                                more += letter;
                                break;

                        }
                    } else
                    {
                        counter++;
                    }
                }

                hotel.HotelInfo.Address = $"Street:{street.Trim()}\nCity:{city.Trim()}\nPostal Code:{postalCode.Trim()}";

            }
            return baseData;
        }
    }
}
