using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TravelerAppConsole;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Models
{
    public class Search
    {
        public static void ByLocalisation(List<Hotel> Data)
        {
            List<Hotel> hotelLocalisation = new List<Hotel>();
            if (Data.Count != 0)
            {
                string adress = GetAdress();
                string regPattern = @$"{adress}";
                Regex regEx = new Regex(regPattern, RegexOptions.IgnoreCase);

                foreach (Hotel hotel in Data)
                {
                    if (hotel.HotelInfo.Address == null)
                    {

                    }
                    else
                    {
                        if (regEx.IsMatch(hotel.HotelInfo.Address))
                        {
                            hotelLocalisation.Add(hotel);
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Baza hoteli jest pusta");
                Console.ResetColor();
            }
            CheckData(Data, hotelLocalisation);
        }
        private static string GetAdress()
        {

            string log = "Podaj adres do wyszukiwania: ";
            Console.WriteLine(log);
            Console.SetCursorPosition(log.Length, Console.CursorTop - 1);
            string adress = Console.ReadLine();
            return adress;
        }
        public static void ByName(List<Hotel> Data)
        {
            List<Hotel> hotelName = new List<Hotel>();
            if (Data.Count != 0)
            {
                string adress = GetName();
                string regPattern = @$"{adress}";
                Regex regEx = new Regex(regPattern, RegexOptions.IgnoreCase);

                foreach (Hotel hotel in Data)
                {
                    if (hotel.HotelInfo.Address == null)
                    {

                    }
                    else
                    {
                        if (regEx.IsMatch(hotel.HotelInfo.Name))
                        {
                            hotelName.Add(hotel);
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Baza hoteli jest pusta");
                Console.ResetColor();
            }
            CheckData(Data, hotelName);
        }
        private static string GetName()
        {
            Console.Write("Podaj nazwę do wyszukiwania: ");
            return Console.ReadLine();
        }
        private static float GetRate()
        {
            Console.Write("Wyszukaj od oceny: ");
            return Hotel.GetRate();
        }
        public static void ByRate(List<Hotel> Data)
        {
            List<Hotel> findRate = new List<Hotel>();
            if (Data.Count != 0)
            {
                float searchByRate = GetRate();
                foreach (Hotel hotel in Data)
                {
                    if (hotel.AverageRates.Overall >= searchByRate)
                    {
                        findRate.Add(hotel);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Baza hoteli jest pusta");
                Console.ResetColor();
            }
            CheckData(Data, findRate);
        }
        private static void CheckData(List<Hotel> Data, List<Hotel> DataFound)
        {
            if (DataFound.Count != 0 && Menu.MultipleOptions)
            {
                Data.Clear();
                Data.AddRange(DataFound);
            }
            if (DataFound.Count != 0 && !Menu.MultipleOptions)
            {
                DrawTable.Hotelinfo(DataFound, DataFound.Count, true);
            }
            if (DataFound.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak wyników wyszukania");
                Console.ResetColor();
            }
        }
    }
}

