using System;
using System.Collections.Generic;
using System.Linq;
using TravelerAppConsole;
using TravelerAppCore.Controller;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.View
{
    public static class ConsolePrint
    {
        public static void SearchAddressConsole()
        {
            if (HotelService.Data.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Baza hoteli jest pusta");
                Console.ResetColor();
            }
            else
            {
                List<Hotel> hotelList = Search.ByLocalisation(GetAddress());
                CheckData(hotelList);
            }
        }
        public static void SearchByNameConsole()
        {
            if (HotelService.Data.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Baza hoteli jest pusta");
                Console.ResetColor();
            }
            else
            {
                List<Hotel> hotelList = Search.ByName(GetName());
                CheckData(hotelList);
            }
        }

        public static string GetAddress()
        {
            string log = "Podaj adress do wyszukiwania:  ";
            Console.Write(log);
            Console.CursorVisible = true;
            string adress = Console.ReadLine();
            while (adress.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Wyszukiwana fraza powinna zawierać conajmniej trzy znaki! ");
                Console.ResetColor();
                Console.SetCursorPosition(log.Count(), Console.CursorTop - 1);
                adress = Console.ReadLine();
            }
            Console.CursorVisible = false;
            return adress;
        }

        public static string GetName()
        {
            string log = "Podaj nazwę do wyszukiwania:  ";
            Console.Write(log);
            Console.CursorVisible = true;
            string name = Console.ReadLine();
            while (name.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Wyszukiwana fraza powinna zawierać conajmniej trzy znaki! ");
                Console.ResetColor();
                Console.SetCursorPosition(log.Count(), Console.CursorTop - 1);
                name = Console.ReadLine();
            }
            Console.CursorVisible = false;
            return name;
        }

        public static void DisplayLoadedData()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Czas odczytu wszystkich plików: {HotelService.stopper.Elapsed}");
            Console.WriteLine($"Ilość odczytanych plików: {HotelService.Data.Count()}");
            Console.WriteLine("Koniec deserializacji");
            Console.WriteLine("----------------------------------------------------\n");
            DrawTable.Hotelinfo(HotelService.Data, HotelService.Data.Count,true);
        }
        public static void DisplaySavedData()
        {
            Console.Clear();
            new Menu().DisplayMenu();
            Console.SetCursorPosition(0, Menu.MenuList.Count() + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Plik został zapisany!");
            Console.ResetColor();
            if (!Menu.MultipleOptions && HotelService.Data.Count() != 0) DrawTable.Hotelinfo(new List<Hotel>() { Hotel.NewHotel }, 1, true);
        }
        public static void SaveToFile()
        {
            Console.WriteLine("-\nCzy zapisać informacje do pliku .json? ( T / N )");
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.T && info.Key != ConsoleKey.N)
            {
                info = Console.ReadKey(true);
            }
            if (info.Key == ConsoleKey.T) HotelService.WriteAndDisplay();
        }
        public static void CheckData(List<Hotel> DataFound)
        {
            if (DataFound.Count != 0 && Menu.MultipleOptions)
            {
                HotelService.Data.Clear();
                HotelService.Data.AddRange(DataFound);
            }
            if (DataFound.Count != 0 && !Menu.MultipleOptions)
            {
                DrawTable.Hotelinfo(DataFound, DataFound.Count, true);
            }
            if (DataFound.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak wyników wyszukania" + new string(' ', 40));
                Console.ResetColor();
            }
        }
        public static float GetRateService()
        {
            Console.Write("Jakość usług (1 - 5): ");
            return GetRate();
        }
        public static float GetRateCleanliness()
        {
            Console.Write("Czystość (1 - 5): ");
            return GetRate();
        }
        public static float GetRateValue()
        {
            Console.Write("Stosunek jakości do ceny (1 - 5): ");
            return GetRate();
        }
        public static float GetRateSleepQuality()
        {
            Console.Write("Komfort (1 - 5): ");
            return GetRate();
        }
        public static float GetRateRooms()
        {
            Console.Write("Wygląd (1 - 5): ");
            return GetRate();
        }
        public static float GetRateLocation()
        {
            Console.Write("Lokalizacja (1 - 5): ");
            return GetRate();
        }
        public static string GetNewName()
        {
            Console.Write("Nazwa hotelu: ");
            return Console.ReadLine();
        }
        public static string GetNewPrice()
        {
            Console.Write("Zakres cenowy: ");
            return Console.ReadLine();
        }
        public static string GetNewAddress()
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
            while (!float.TryParse(Console.ReadLine(), out fRateHotel) || fRateHotel < 1 || fRateHotel > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Ocena tylko w skali 1 do 5! ");
                Console.ResetColor();
            }
            return fRateHotel;
        }
    }
}
