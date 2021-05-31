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
        public static HotelInfo SaveInfo()
        {
            Console.WriteLine("Podaj informacje o hotelu");
            Root saveInfoHotel = new Root()
            {
                HotelInfo = new HotelInfo()
                {
                    Name = RateTheHotel.GetName(),
                    HotelURL = "default",
                    Price = RateTheHotel.GetPrice(),
                    Address = RateTheHotel.GetAddress(),
                    HotelID = "default",
                    ImgURL = "default"
                }
            };
            return saveInfoHotel.HotelInfo;
        }
        public static List<Review> SaveRate()
        {
            Console.WriteLine("Oceń hotel w skali od 0 do 5");
            Root saveInfoHotel = new Root()
            {
                Reviews = new List<Review>() {
                    new Review() {
                    Ratings = new Ratings() {
                        Overall = 0.0f,
                        //Overall = RateTheHotel.GetOverall(),
                        Service = RateTheHotel.GetService(),
                        Cleanliness = RateTheHotel.GetCleanliness(),
                        Value = RateTheHotel.GetValue(),
                        SleepQuality = RateTheHotel.GetSleepQuality(),
                        Rooms = RateTheHotel.GetRooms(),
                        Location = RateTheHotel.GetLocation()
                        } } }
            };
            return saveInfoHotel.Reviews;
        }


        //private static float GetOverall()
        //{
        //    Console.WriteLine("Ocea ogólna (0 - 5): ");
        //    return GetRate();
        //}
        public static float GetService()
        {
            Console.WriteLine("Jakość usług (0 - 5): ");
            return GetRate();
        }
        public static float GetCleanliness()
        {
            Console.WriteLine("Czystość (0 - 5): ");
            return GetRate();
        }
        public static float GetValue()
        {
            Console.WriteLine("Stosunek jakości do ceny (0 - 5): ");
            return GetRate();
        }
        public static float GetSleepQuality()
        {
            Console.WriteLine("Komfort (0 - 5): ");
            return GetRate();
        }
        public static float GetRooms()
        {
            Console.WriteLine("Wygląd (0 - 5): ");
            return GetRate();
        }
        public static float GetLocation()
        {
            Console.WriteLine("Lokalizacja (0 - 5): ");
            return GetRate();
        }

        public static string GetName()
        {
            Console.WriteLine("Nazwa hotelu: ");
            return Console.ReadLine();
        }
        public static string GetPrice()
        {
            Console.WriteLine("Zakres cenowy: ");
            return Console.ReadLine();
        }
        public static string GetAddress()
        {
            Console.WriteLine("Adres: ");
            return Console.ReadLine();
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
