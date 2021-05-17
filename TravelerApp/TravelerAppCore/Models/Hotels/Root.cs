using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerAppCore.Models.Hotels
{
    public class Root
    {
        public List<Review> Reviews { get; set; }
        public HotelInfo HotelInfo { get; set; }
    }
}
