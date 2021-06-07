using System;
using System.Collections.Generic;
using TravelerAppCore.Controller;

namespace TravelerAppCore.Models.Hotels
{
    public class Hotel
    {
        public List<Review> Reviews { get; set; }
        public HotelInfo HotelInfo { get; set; }

        private string log;
        private Ratings averages;
        public Ratings AverageRates
        {
            get
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

                foreach (Review item in Reviews)
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
                averages = new Ratings()
                {
                    Overall = (averageOverall + averageService + averageCleanliness + averageValue + averageSleepQuality + averageRooms + averageLocation)
                                    / (float)(overall + service + cleanliness + value + sleepQuality + rooms + location),
                    Service = averageService / (float)service,
                    Cleanliness = averageCleanliness / (float)cleanliness,
                    Value = averageValue / (float)value,
                    SleepQuality = averageSleepQuality / (float)sleepQuality,
                    Rooms = averageRooms / (float)rooms,
                    Location = averageLocation / (float)location
                };
                return averages;
            }
        }

        public void CreateNew(List<Hotel> NewHotel)
        {
            NewHotel.Add(new Hotel()
            {
                HotelInfo = new HotelInfo()
                {
                    Name = GetName(),
                    HotelURL = "default",
                    Price = GetPrice(),
                    Address = GetAddress(),
                    HotelID = "default",
                    ImgURL = "default"
                },
                Reviews = new List<Review>() {
                    new Review() {
                    Ratings = new Ratings() {
                        Overall = 0.0f,
                        Service = GetService(),
                        Cleanliness = GetCleanliness(),
                        Value = GetValue(),
                        SleepQuality = GetSleepQuality(),
                        Rooms = GetRooms(),
                        Location = GetLocation()
                        } } }
            });
            SaveToFile(NewHotel);
        }
        private void SaveToFile(List<Hotel> NewHotel)
        {
            Console.WriteLine("-\nCzy zapisać informacje do pliku .json? ( T / N )");
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.T && info.Key != ConsoleKey.N)
            {
                info = Console.ReadKey(true);
            }
            if (info.Key == ConsoleKey.T) ReadWriteHotel.WriteAndDisplay(NewHotel);
        }

        private float GetService()
        {
            Console.Write("Jakość usług (0 - 5): ");
            return GetRate();
        }
        private float GetCleanliness()
        {
            Console.Write("Czystość (0 - 5): ");
            return GetRate();
        }
        private float GetValue()
        {
            Console.Write("Stosunek jakości do ceny (0 - 5): ");
            return GetRate();
        }
        private float GetSleepQuality()
        {
            Console.Write("Komfort (0 - 5): ");
            return GetRate();
        }
        private float GetRooms()
        {
            Console.Write("Wygląd (0 - 5): ");
            return GetRate();
        }
        private float GetLocation()
        {
            Console.Write("Lokalizacja (0 - 5): ");
            return GetRate();
        }

        private string GetName()
        {
            Console.Write("Nazwa hotelu: ");
            return Console.ReadLine();
        }
        private string GetPrice()
        {
            Console.Write("Zakres cenowy: ");
            return Console.ReadLine();
        }
        private string GetAddress()
        {
            Console.WriteLine("-\nPodaj adres");

            Console.Write("Nazwa ulicy: ");
            string street = Console.ReadLine();

            Console.Write("Nazwa miasta: ");
            string city = Console.ReadLine();

            Console.Write("Kod pocztowy: ");
            string postalcode = Console.ReadLine();
            Console.WriteLine("-");
            return city + ", " + street + ", " + postalcode;
        }
        public static float GetRate()
        {
            float fRateHotel = 0;
            while (!float.TryParse(Console.ReadLine(), out fRateHotel) || fRateHotel < 0 || fRateHotel > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Ocena tylko w skali 0 do 5! ");
                Console.ResetColor();
            }
            return fRateHotel;
        }

    }
}