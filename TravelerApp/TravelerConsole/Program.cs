using System;

using TravelerAppConsole;

using System.IO;
using System.Collections.Generic;
using TravelerAppCore.Models.Hotels;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using TravelerAppCore.Controller;
using TravelerAppCore.View;


namespace TravelerAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {

          

            //Ustawia wysokość i szerokość okna konsoli na określone wartości.
            Console.SetWindowSize(180, 30);

            List<Root> dataReaded = new List<Root>();
            JSON.Read(dataReaded);

            List<Root> dataSaved = new List<Root>();
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

            int numberOfRecords = 10;
            DrawTable.Hotelinfo(dataReaded, numberOfRecords);
            //Zmieniam funkcję wyszukiwanie po lokalizacji na typ delegata ja nazwałam go Del, żebym mogła dodać ją do parametrów funkcji
            Del jakas = TravelerAppCore.Models.Search.byLocalisation;
           
           
            List<Item> lista = new List<Item>();//lista znaków jakie może wpisywać użytkownik, żeby poruszać się po menu
            MenuInterface.MenuAddItem( ConsoleKey.L,"by localisation", jakas,lista);//metoda która dodaje nową funkcjonalność do Menu
            //pierwszy parametr oznacza znak z klawiatury po którym użytkownik włączy funkcjonalność, 2 to tekst jaki się będzie wyświetlał w menu
            //3 parametr to wasza funkcja zmieniona na typ delegata.
            MenuInterface.Menu(lista);//wyświetlenie wszystkich funkcjonalności które są zapisane do menu
            MenuInterface.MenuWork(lista);//uruchomienie wyboru użytkownika, jeśli wybór jest na liście uruchamia funkcjonalność
        }

        
    }
}