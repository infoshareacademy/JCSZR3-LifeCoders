using System.Collections.Generic;

namespace TravelerAppCore.Models.Hotels
{
    public class Hotel
    {
        public List<Review> Reviews { get; set; }
        public HotelInfo HotelInfo { get; set; }
    }
}
