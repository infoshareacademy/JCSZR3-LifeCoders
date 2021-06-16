using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelerAppConsole;
using TravelerAppCore.Controller;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.View
{
    public static class ConsolePrint
    {
        public static List<Hotel> DataToSort = new List<Hotel>();
        public static void DisplaySort()
        {
            Console.SetCursorPosition(0, Menu.MenuList.Count() + 3 + Menu.nextline);
            Console.Write("Sortuj po: [N]azwie, [A]dresie, [O]cenie, [C]enie\n");
            DrawTable.Hotelinfo(DataToSort, DataToSort.Count(), true);
        }
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
                List<Hotel> hotelList = Search.ByLocalisation(GetText("Podaj adress do wyszukiwania:  "));
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
                List<Hotel> hotelList = Search.ByName(GetText("Podaj nazwę do wyszukiwania:  "));
                CheckData(hotelList);
            }
        }
        public static void SearchByRate()
        {
            if (HotelService.Data.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Baza hoteli jest pusta");
                Console.ResetColor();
            }
            else
            {
                List<Hotel> hotelList = Search.ByRate(GetRate("Wyszukaj od oceny:  "));
                CheckData(hotelList);
            }
        }

        public static string GetText(string log)
        {
            Console.Write(log);
            Console.CursorVisible = true;
            string findIt = ReadLine();
            while (findIt.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Wyszukiwana fraza powinna zawierać conajmniej trzy znaki! ");
                Console.ResetColor();
                Console.SetCursorPosition(log.Count(), Console.CursorTop - 1);
                findIt = ReadLine();
            }
            Console.CursorVisible = false;
            return findIt;
        }
        public static float GetRate(string log)
        {
            Console.Write(log);
            
            Console.CursorVisible = true;
            float fRateHotel = 0;
            while (!float.TryParse(ReadLine(), out fRateHotel) || fRateHotel < 1 || fRateHotel > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Ocena tylko w skali 1 do 5! ");
                Console.ResetColor();
            }
            return fRateHotel;
        }
        public static void DisplayLoadedData()
        {
            Console.WriteLine("----------------------------------------------------"); ++Menu.nextline;
            Console.WriteLine($"Czas odczytu wszystkich plików: {HotelService.stopper.Elapsed}"); ++Menu.nextline;
            Console.WriteLine($"Ilość odczytanych plików: {HotelService.Data.Count()}"); ++Menu.nextline;
            Console.WriteLine("Koniec deserializacji"); ++Menu.nextline;
            Console.WriteLine("----------------------------------------------------"); ++Menu.nextline;
            DisplaySort();
        }
        public static void DisplaySavedData()
        {
            Console.Clear();
            Menu.DisplayMenu();
            Console.SetCursorPosition(0, Menu.MenuList.Count() + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Plik został zapisany!");
            Console.ResetColor();
            if (!Menu.MultipleOptions && HotelService.Data.Count() != 0) DrawTable.Hotelinfo(new List<Hotel>() { Hotel.NewHotel }, 1, true);
        }
        public static void SaveToFile()
        {
            Console.WriteLine("-\nCzy zapisać informacje do pliku .json? ( T / N )");
            ConsoleKeyInfo info = Console.ReadKey(false);
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
                DataToSort.Clear();
                DataToSort.AddRange(DataFound);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop+1);
                DisplaySort();
            }
            if (DataFound.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, Menu.MenuList.Count() + 3 + Menu.nextline);
                Console.WriteLine("Brak wyników wyszukania" + new string(' ', 40));
                Console.ResetColor();
                Menu.SelectedOptions.Clear();
                Console.SetCursorPosition(0, 0);
                new Menu().Interface();
                Menu.SelectedOptions.Clear();
                Console.CursorVisible = false;
            }
        }
        public static float GetRateService()
        {
            return GetRate("Jakość usług (1 - 5): ");
        }
        public static float GetRateCleanliness()
        {
            return GetRate("Czystość (1 - 5): ");
        }
        public static float GetRateValue()
        {
            return GetRate("Stosunek jakości do ceny (1 - 5): ");
        }
        public static float GetRateSleepQuality()
        {
            return GetRate("Komfort (1 - 5): ");
        }
        public static float GetRateRooms()
        {
            return GetRate("Wygląd (1 - 5): ");
        }
        public static float GetRateLocation()
        {
            return GetRate("Lokalizacja (1 - 5): ");
        }
        public static string GetNewName()
        {
            Console.Write("Nazwa hotelu: ");
            return ReadLine();
        }
        public static string GetNewPrice()
        {
            Console.Write("Zakres cenowy: ");
            return ReadLine();
        }
        public static string GetNewAddress()
        {
            Console.WriteLine("-\nPodaj adres");
            Console.Write("Nazwa ulicy: ");
            string street = ReadLine();
            Console.Write("Nazwa miasta: ");
            string city = ReadLine();
            Console.Write("Kod pocztowy: ");
            string postalcode = ReadLine();
            Console.WriteLine("-");
            return city + ", " + street + ", " + postalcode;
        }

        public static void Exit()
        {
            Console.WriteLine("Czy na pewno chcesz wyjść z aplikacji? ( T / N )");
            ConsoleKeyInfo info = Console.ReadKey(false);
            while (info.Key != ConsoleKey.T && info.Key != ConsoleKey.N)
            {
                info = Console.ReadKey(false);
            }
            if (info.Key == ConsoleKey.T) {
                Console.Clear();
                Menu.DisplayMenu();
                Environment.Exit(0); }
            if (info.Key == ConsoleKey.N)
            {
                Console.Clear();
                Menu.DisplayMenu();
            }
        }
        public static string ReadLine()
        {
            string buf = String.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Menu.SelectedOptions.Clear();
                    Console.SetCursorPosition(0, 1);
                    Console.Clear();
                    new Menu().Interface();
                    return default;
                }
                // Ignore if Alt or Ctrl is pressed.
                if ((key.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                    continue;
                if ((key.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                    continue;
                // Ignore if KeyChar value is \u0000.
                if (key.KeyChar == '\u0000') continue;
                // Ignore tab key.
                if (key.Key == ConsoleKey.Tab) continue;
                // Handle backspace.
                if (key.Key == ConsoleKey.Backspace)
                {
                    // Are there any characters to erase?
                    if (buf.Length >= 1)
                    {
                        // Determine where we are in the console buffer.
                        int cursorCol = Console.CursorLeft - 1;
                        int oldLength = buf.Length;
                        int extraRows = oldLength / 80;

                        buf = buf.Substring(0,oldLength-1);
                        Console.CursorLeft = Console.CursorLeft -1;
                        Console.CursorTop = Console.CursorTop - extraRows;
                        Console.Write(new String(' ', oldLength - buf.Length));
                        Console.CursorLeft = cursorCol;
                    }
                    continue;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("");
                    return buf;
                }
                // Handle key by adding it to input string.
                Console.Write(key.KeyChar);
                buf += key.KeyChar;
            } while (key.Key != ConsoleKey.Enter) ;
            return default;
        }
    }
}
