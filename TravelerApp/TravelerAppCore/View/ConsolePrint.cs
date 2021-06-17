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
        public static string buf = String.Empty;
        public static void DisplaySort()
        {
            Console.SetCursorPosition(0, Menu.MenuList.Count() + 2 + Menu.nextline);
            Console.Write("Sortuj po:  ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("[N]"); Console.ResetColor(); Console.Write("azwie,  ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("[A]"); Console.ResetColor(); Console.Write("dresie,  ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("[O]"); Console.ResetColor(); Console.Write("cenie,  ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("[C]"); Console.ResetColor(); Console.Write("enie,  " + new string(' ', 40) + "\n");
            DrawTable.Hotelinfo(Sort.DataToSort, Sort.DataToSort.Count(), true);
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
            Console.Write(new String(' ', 50));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(log);
            Console.CursorVisible = true;
            string findIt = ReadLine();
            while (findIt.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Fraza powinna zawierać conajmniej trzy znaki! ");
                Console.ResetColor();
                Console.SetCursorPosition(log.Count(), Console.CursorTop - 1);
                Console.Write(new String(' ', buf.Length + 40));
                Console.SetCursorPosition(log.Count(), Console.CursorTop);
                Console.CursorVisible = true;
                buf = String.Empty;
                findIt = ReadLine();
            }
            Console.CursorVisible = false;
            return findIt;
        }
        public static float GetRate(string log)
        {
            Console.Write(new String(' ', 50));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(log);
            Console.CursorVisible = true;
            float fRateHotel = 0;
            while (!float.TryParse(ReadLine(), out fRateHotel) || fRateHotel < 1 || fRateHotel > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("* Ocena tylko w skali 1 do 5! ");
                Console.ResetColor();
                Console.SetCursorPosition(log.Count(), Console.CursorTop - 1);
                Console.Write(new String(' ', 20));
                Console.SetCursorPosition(log.Count(), Console.CursorTop);
                Console.CursorVisible = true;
                buf = String.Empty;
            }
            return fRateHotel;
        }
        public static string GetCurrency(string log)
        {
            Console.Write(log);
            Console.CursorVisible = false;
            string[] curency = { "$", "zł", "EUR", "GBP", "CHF", "AED", "AUD", "CAD", "UAH", "JPY", "HRK", "CZK", "DKK", "NOK", "SEK", "RON",
            "BGN", "TRY", "XDR", "ZAR", "RUB", "CNY"};
            string getCurrency = "";
            ConsoleKeyInfo key;
            int i = 0;
            Console.Write(curency[0]);
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    i++;
                    if (i > curency.Count() - 1) i = (curency.Count() - 1);
                    getCurrency = curency[i];
                    Console.SetCursorPosition(log.Count(), Console.CursorTop);
                    Console.Write(new String(' ', getCurrency.Length + 1));
                    Console.SetCursorPosition(log.Count(), Console.CursorTop);
                    Console.Write(getCurrency);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    i--;
                    if (i < 0) i = 0;
                    getCurrency = curency[i];
                    Console.SetCursorPosition(log.Count(), Console.CursorTop);
                    Console.Write(new String(' ', getCurrency.Length + 1));
                    Console.SetCursorPosition(log.Count(), Console.CursorTop);
                    Console.Write(getCurrency);
                }
            } while (key.Key != ConsoleKey.Enter);
            return getCurrency;
        }
        public static void DisplayLoadedData()
        {
            Console.WriteLine("----------------------------------------------------"); ++Menu.nextline;
            Console.WriteLine($"Czas odczytu wszystkich plików: {HotelService.stopper.Elapsed}"); ++Menu.nextline;
            Console.WriteLine($"Ilość odczytanych plików: {HotelService.Data.Count()}"); ++Menu.nextline;
            Console.WriteLine("Koniec deserializacji"); ++Menu.nextline;
            Console.Write("----------------------------------------------------"); ++Menu.nextline;
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
            DrawTable.Hotelinfo(new List<Hotel>{Hotel.NewHotel}, 1, true);
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
                Sort.DataOrder(DataFound);
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
            return GetText("Nazwa hotelu: ");
        }

        public static float GetPrice(string log)
        {
            Console.Write(log);
            Console.CursorVisible = true;
            string message = "Kwota może zawierać tylko cyfry!";
            float fPrice = 0;
            while (!float.TryParse(ReadLine(), out fPrice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message);
                Console.ResetColor();
                Console.CursorVisible = true;
                Console.SetCursorPosition(log.Count(), Console.CursorTop - 1);
                Console.Write(new String(' ', buf.Length));
                Console.SetCursorPosition(log.Count(), Console.CursorTop);
                buf = String.Empty;
            }
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new String(' ', message.Length));
            Console.SetCursorPosition(0, Console.CursorTop);
            return fPrice;
        }
        public static string GetNewPrice()
        {
            Console.WriteLine("Zakres cenowy: " + new String(' ', 40));
            float minValue = GetPrice("Od: ");
            float maxValue = GetPrice("Do: ");
            string message = "Podana kwota nie może być mniejsza od wartości minimalnej!";
            while (maxValue < minValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message);
                Console.ResetColor();
                Console.CursorVisible = true;
                Console.SetCursorPosition(4, Console.CursorTop - 1);
                Console.Write(new String(' ', buf.Length));
                Console.SetCursorPosition(4, Console.CursorTop);
                buf = String.Empty;
                maxValue = GetPrice("");
            }
            Console.Write(new String(' ', 80));
            Console.SetCursorPosition(0, Console.CursorTop);
            string curreny = GetCurrency("Podaj walutę ↑↓: ");
            return $"{minValue} - {maxValue} {curreny}";
        }
        public static string GetNewAddress()
        {
            Console.WriteLine("\n-\nPodaj adres:");
            string street = GetText("Nazwa ulicy: ");
            string city = GetText("Nazwa miasta: ");
            string postalcode = GetText("Kod pocztowy: ");
            Console.WriteLine("-" + new String(' ', 50));
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
            buf = String.Empty;
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
                //if ((key.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                //    continue;
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
                    Console.CursorVisible = false;
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
