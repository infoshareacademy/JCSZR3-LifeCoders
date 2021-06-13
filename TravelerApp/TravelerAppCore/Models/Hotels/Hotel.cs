using System;
using System.Collections.Generic;
using TravelerAppCore.Controller;
using TravelerAppCore.View;
using System.Linq;

namespace TravelerAppCore.Models.Hotels
{
    public class Hotel
    {
        public List<Review> Reviews { get; set; }
        public HotelInfo HotelInfo { get; set; }
        private Ratings averages;
        public Ratings AverageRates
        {
            get
            {
                averages = new Ratings()
                {
                    Overall = (float)Math.Round(Reviews.Average(a => a.Ratings.Overall), 2),
                    Service = (float)Math.Round(Reviews.Average(a => a.Ratings.Service), 2),
                    Cleanliness = (float)Math.Round(Reviews.Average(a => a.Ratings.Cleanliness), 2),
                    Value = (float)Math.Round(Reviews.Average(a => a.Ratings.Value), 2),
                    SleepQuality = (float)Math.Round(Reviews.Average(a => a.Ratings.SleepQuality), 2),
                    Rooms = (float)Math.Round(Reviews.Average(a => a.Ratings.Rooms), 2),
                    Location = (float)Math.Round(Reviews.Average(a => a.Ratings.Location), 2)
                };
                return averages;
            }
        }
        public static Hotel NewHotel;
        public void CreateNew()
        {
            Hotel NewHotel = new Hotel()
            {
                HotelInfo = new HotelInfo()
                {
                    Name = ConsolePrint.GetNewName(),
                    HotelURL = "default",
                    Price = ConsolePrint.GetNewPrice(),
                    Address = ConsolePrint.GetNewAddress(),
                    HotelID = "default",
                    ImgURL = "default"
                },
                Reviews = new List<Review>() {
                    new Review() {
                    Ratings = new Ratings() {
                        Overall = 0.0f,
                        Service = ConsolePrint.GetRateService(),
                        Cleanliness = ConsolePrint.GetRateCleanliness(),
                        Value = ConsolePrint.GetRateValue(),
                        SleepQuality = ConsolePrint.GetRateSleepQuality(),
                        Rooms = ConsolePrint.GetRateRooms(),
                        Location = ConsolePrint.GetRateLocation()
                        } } }
            };
            SaveToFile();
        }
        private void SaveToFile()
        {
            Console.WriteLine("-\nCzy zapisać informacje do pliku .json? ( T / N )");
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.T && info.Key != ConsoleKey.N)
            {
                info = Console.ReadKey(true);
            }
            if (info.Key == ConsoleKey.T) HotelService.WriteAndDisplay();
        }
    }
}
