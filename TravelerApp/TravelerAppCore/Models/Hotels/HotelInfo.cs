using System.Text.RegularExpressions;

namespace TravelerAppCore.Models.Hotels
{
    public class HotelInfo
    {
        public string Name { get; set; }
        public string HotelURL { get; set; }
        public string Price { get; set; }
        public string Address { get; set; }
        //public string AddressFixed
        //{
        //    get
        //    {
        //        string _addresfixed = Regex.Replace(Address, "<.*?>", string.Empty);
        //            //Regex rg = new Regex(@"(?<street>.+),\s(?<city>.+),\s(?<postalCode>.+)");
        //            //var addressMatch = rg.Match(address);
        //            //string street = addressMatch.Groups["street"].Value;
        //            //string city = addressMatch.Groups["city"].Value;
        //            //string postalCode = addressMatch.Groups["postalCode"].Value;
        //            //street = street.Trim();
        //            //city = city.Trim();
        //            //postalCode = postalCode.Trim();
        //            //hotel.HotelInfo.Address = $"{city}, {street}, {postalCode}";
        //        return _addresfixed;
        //    }
        //}
        public string HotelID { get; set; }
        public string ImgURL { get; set; }
    }
}
