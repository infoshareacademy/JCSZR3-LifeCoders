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
            }
            return baseData;
        }
    }
}
