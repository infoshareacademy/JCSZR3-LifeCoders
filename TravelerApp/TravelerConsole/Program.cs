using System;
using System.IO;
using System.Collections.Generic;
using TravelerAppCore.Models.Hotels;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using TravelerAppCore.Controller;
using TravelerAppCore.View;
using System.Text.RegularExpressions;

namespace TravelerAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ustawia wysokość i szerokość okna konsoli na określone wartości.
            Console.SetWindowSize(200, 30);

            List<Root> dataReaded = new List<Root>();
            JSON.Read(dataReaded);
            AddressFormatFixer.FixAddress(dataReaded);
            List<Root> dataSaved = new List<Root>();
            Console.WriteLine(dataReaded[1].HotelInfo.Address);
            JSON.Write(dataSaved);

            //Dostępne informacje:
            //-Poszczególne kryteria ocen:
            //  float ratingsCleanLiness = dataReaded[0].Reviews[2].Ratings.Cleanliness;
            //  float ratingsOverall = dataReaded[0].Reviews[2].Ratings.Overall;
            //  float ratingsRooms = dataReaded[0].Reviews[2].Ratings.Rooms;
            //  float ratingsService = dataReaded[0].Reviews[2].Ratings.Service;
            //  float ratingsValue = dataReaded[0].Reviews[2].Ratings.Value;
            //  float ratingsSleepQuality = dataReaded[0].Reviews[2].Ratings.SleepQuality;
            //  float ratingsLocation = dataReaded[0].Reviews[2].Ratings.Location;

            //-Użytkownik wystawiajacy opinie:
            //  string reviewAuthorLocation = dataReaded[0].Reviews[2].AuthorLocation;
            //  string reviewTitle = dataReaded[0].Reviews[2].Title;
            //  string reviewAuthor = dataReaded[0].Reviews[2].Author;
            //  string reviewReviewID = dataReaded[0].Reviews[2].ReviewID;
            //  string reviewContent = dataReaded[0].Reviews[2].Content;
            //  string reviewDate = dataReaded[0].Reviews[2].Date;

            //-Informacje o hotelu:
            //  string hotelName = dataReaded[0].HotelInfo.Name;
            //  string hotelURL = dataReaded[0].HotelInfo.HotelURL;
            //  string hotelPrice = dataReaded[0].HotelInfo.Price;
            //  string hotelAddress = dataReaded[0].HotelInfo.Address; //zawiera HTML
            //  string hotelID = dataReaded[0].HotelInfo.HotelID;
            //  string hotelImgURL = dataReaded[0].HotelInfo.ImgURL;

            int numberOfRecords = 12;
            DrawTable.Hotelinfo(dataReaded, numberOfRecords);

            string searchedName = null;// "BEST WESTERN Loyal Inn";// "Christopher's Inn";
            List<int> list = SearchByName.HotelsByName(dataReaded, searchedName);
            //list.Sort();
            List<Root> hotelsReturnedByName = new List<Root>();
            foreach (int item in list)
            {
                hotelsReturnedByName.Add(dataReaded[item]);
            }
            Console.WriteLine($"Hotels having {searchedName} in their names" );
       
            DrawTable.Hotelinfo(hotelsReturnedByName, list.Count);



        }
    }
}