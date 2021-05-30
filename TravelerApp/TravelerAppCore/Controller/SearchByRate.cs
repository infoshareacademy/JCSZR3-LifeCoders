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
  foreach (Review item in hotel.Reviews)
{
	if(item.Ratings.Overall != null)
	{
		averageOverall += item.Ratings.Overall;
		overall++;
	}
	if(item.Ratings.Service != null)
	{
		averageService += item.Ratings.Service;
		service++;
	}
	if(item.Ratings.Cleanliness != null)
	{
		averageCleanliness += item.Ratings.Cleanliness;
		cleanliness++;
	}
	if(item.Ratings.Value != null)
	{
		averageValue += item.Ratings.Value;
		value++;
	}
	if(item.Ratings.SleepQuality != null)
	{
		averageSleepQuality += item.Ratings.SleepQuality;
		sleepQuality++;
	}
	if(item.Ratings.Rooms != null)
	{
		averageRooms += item.Ratings.Rooms;
		rooms++;
	}
	if(item.Ratings.Location != null)
	{
		averageLocation += item.Ratings.Location;
		location++;
	}
}
        {
            Console.WriteLine("Podaj ocene do wyszukania:");
            float rate = float.Parse(Console.ReadLine());
            return default;
        }
    }
}
}
