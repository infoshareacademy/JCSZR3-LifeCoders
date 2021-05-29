using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Models
{
    public static class SearchByRate
    {
        public static void byRating(List<Root> targetData)
        {
            List<Root> hotelLocalisation = new List<Root>();
            float rate = getRate();
            List<Ratings> averages = new List<Ratings>();
            int i = 0;
            foreach (Root hotel in targetData)
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
                    averageOverall += item.Ratings.Overall;
                    overall++;
                    averageService += item.Ratings.Service;
                    service++;
                    averageCleanliness += item.Ratings.Cleanliness;
                    cleanliness++;
                    averageValue += item.Ratings.Value;
                    value++;
                    averageSleepQuality += item.Ratings.SleepQuality;
                    sleepQuality++;
                    averageRooms += item.Ratings.Rooms;
                    rooms++;
                    averageLocation += item.Ratings.Location;
                    location++;
                }
                averages.Add(new Ratings
                {
                    Overall = averageOverall / (float)overall,
                    Service = averageService / (float)service,
                    Cleanliness = averageCleanliness / (float)cleanliness,
                    Value = averageValue / (float)value,
                    SleepQuality = averageSleepQuality / (float)sleepQuality,
                    Rooms = averageRooms / (float)rooms,
                    Location = averageLocation / (float)location
                });
            }
            Console.Clear();
            //DrawTable.Hotelinfo(hotelLocalisation, count);​
        }private static float getRate()
        {
            Console.WriteLine("Podaj ocene do wyszukania:");
            float rate = float.Parse(Console.ReadLine());
            return default;
        }
    }
}
}
