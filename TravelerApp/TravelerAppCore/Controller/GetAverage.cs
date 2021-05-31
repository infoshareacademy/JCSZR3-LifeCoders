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
                float averageService = 0;
                int service = 0;
                float averageCleanliness = 0;
                int cleanliness = 0;
                float averageValue = 0;
                int value = 0;
                float averageSleepQuality = 0;
                int sleepQuality = 0;
                float averageRooms = 0;
                int rooms = 0;
                float averageLocation = 0;
                int location = 0;
                foreach (Review item in hotel.Reviews)
                {

                    if (item.Ratings.Overall != 0)
                    {
                        averageOverall += item.Ratings.Overall;
                        overall++;
                    }
                    if (item.Ratings.Service != 0)
                    {
                        averageService += item.Ratings.Service;
                        service++;
                    }
                    if (item.Ratings.Cleanliness != 0)
                    {
                        averageCleanliness += item.Ratings.Cleanliness;
                        cleanliness++;
                    }
                    if (item.Ratings.Value != 0)
                    {
                        averageValue += item.Ratings.Value;
                        value++;
                    }
                    if (item.Ratings.SleepQuality != 0)
                    {
                        averageSleepQuality += item.Ratings.SleepQuality;
                        sleepQuality++;
                    }
                    if (item.Ratings.Rooms != 0)
                    {
                        averageRooms += item.Ratings.Rooms;
                        rooms++;
                    }
                    if (item.Ratings.Location != 0)
                    {
                        averageLocation += item.Ratings.Location;
                        location++;
                    }

                }
                averages.Add(new Root()
                {
                    Reviews = new List<Review>() { new Review() { Ratings = new Ratings() {
                    Overall = (averageOverall + averageService + averageCleanliness + averageValue + averageSleepQuality + averageRooms + averageLocation)
                                / (float)(overall + service + cleanliness + value + sleepQuality + rooms + location),
                    Service = averageService / (float)service,
                    Cleanliness = averageCleanliness / (float)cleanliness,
                    Value = averageValue / (float)value,
                    SleepQuality = averageSleepQuality / (float)sleepQuality,
                    Rooms = averageRooms / (float)rooms,
                    Location = averageLocation / (float)location
                    } } }
                });
            }
            for (int i = 0; i < record.Count(); i++)
            {
                record[i].Reviews = averages[i].Reviews;
            }
            return record;
        }
    }
}
