using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public static class RateTheHotel
    {
        public static List<Review> SaveRate()
        {
            Console.WriteLine("Oceń hotel w skali od 0 do 5");
            Root saveInfoHotel = new Root()
            {
                Reviews = new List<Review>() {
                    new Review() {
                    Ratings = new Ratings() {
                        Overall = RateTheHotel.GetOverall()
                        } } }
            };
            return saveInfoHotel.Reviews;
        }


        private static float GetOverall()
        {
            Console.WriteLine("Ocea ogólna (0 - 5): ");
            return GetRate();
        }

        public static float GetRate()
        {
            float fRateHotel = 0;
            while (!float.TryParse(Console.ReadLine(), out fRateHotel) || fRateHotel < 0 || fRateHotel > 5)
            {
                Console.WriteLine("* Ocena tylko w skali 0 do 5!");
            }
            return fRateHotel;
        }
    }
}
