using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public class GetAverage
    {
        public static List<Root> Rates(List<Root> record)
        {
            List<Root> averages = new List<Root>();
            foreach (Root hotel in record)
            {
                float averageOverall = 0;
                int overall = 0;
                
                foreach (Review item in hotel.Reviews)
                {
                        if (item.Ratings.Overall != 0)
                        {
                            averageOverall += item.Ratings.Overall;
                            overall++;
                        }
                }
                averages.Add(new Root() { Reviews = new List<Review>() { new Review() { Ratings = new Ratings() {Overall = (averageOverall) / (float)(overall),} } }});
            }
            return averages;
        }
    }
}
