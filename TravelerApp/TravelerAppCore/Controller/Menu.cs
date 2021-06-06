using System;
using System.Collections.Generic;
using System.Linq;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppConsole
{
    public class Option
    {


        private static int num = 0;
        public int _num { get; set; }
        public string _text { get; set; }
        public Del _met { get; set; }
        public Option(string n, Del M1)
        {
            _text = n;
            _met = M1;
            _num = num;
            num++;
        }
    }

    public class Menu
    {
        public static List<Option> MenuList = new List<Option>();
        private static List<Option> SelectedOptions = new List<Option>();
        public static List<Hotel> dataReaded = new List<Hotel>();

        public Menu() { }
        public Menu(Option[] options)
        {
            foreach (var option in options)
            {
                MenuList.Add(option);
            }
        }

        static int origRow = Console.CursorTop;
        static int origCol = Console.CursorLeft;
        static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        static int i = 0;

        public void DisplayMenu()
        {
            Console.CursorVisible = false;

            Console.WriteLine("Menu:");
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            foreach (var item in MenuList)
            {
                if (i == item._num)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($" {(char)16}  {item._text}");
                    Console.ResetColor();
                }
                else Console.WriteLine($"[ ] {item._text}");
            }
        }

        public void Interface()
        {
            DisplayMenu();
            bool[] selected = new bool[MenuList.Count()];
            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    i--;
                    if (i < 0) i = 0;
                    if (!selected[i + 1])
                    {
                        Console.ResetColor();
                        WriteAt($"[ ] {MenuList[i + 1]._text}   ", 0, i + 1);
                    }
                    if (selected[i + 1] || selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i + 1]._text}   ", 0, i + 1);
                        Console.ResetColor();
                    }
                    if (!selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        WriteAt($" {(char)16}  {MenuList[i]._text}", 0, i);
                        Console.ResetColor();
                    }
                    if (selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i]._text} {(char)17}   ", 0, i);
                        Console.ResetColor();
                    }
                }
                if (info.Key == ConsoleKey.DownArrow)
                {
                    i++;
                    if (i >= MenuList.Count()) i = MenuList.Count() - 1;

                    if (!selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        WriteAt($" {(char)16}  {MenuList[i]._text}", 0, i);
                        Console.ResetColor();
                    }
                    if (!selected[i - 1])
                    {
                        Console.ResetColor();
                        WriteAt($"[ ] {MenuList[i - 1]._text}   ", 0, i - 1);
                    }
                    if (selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i]._text} {(char)17}", 0, i);
                        Console.ResetColor();
                    }
                    if (selected[i - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i - 1]._text}   ", 0, i - 1);
                        Console.ResetColor();
                    }
                }


                if (info.Key == ConsoleKey.Spacebar)
                {
                    selected[i] = selected[i] ? false : true;
                    if (!selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        WriteAt($" {(char)16}  {MenuList[i]._text}  ", 0, i);
                        Console.ResetColor();
                        SelectedOptions.Remove(MenuList[i]);
                    }
                    if (selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i]._text} {(char)17}   ", 0, i);
                        Console.ResetColor();
                        SelectedOptions.Add(MenuList[i]);
                    }
                }

                if (info.Key == ConsoleKey.Enter)
                {
                    if (!selected[i])
                    {
                        SelectedOptions.Add(MenuList[i]);
                    }

                    foreach (var item in SelectedOptions)
                    {
                        selected[item._num] = false;
                        Console.Clear();
                        Console.ResetColor();
                        DisplayMenu();
                        origRow = MenuList.Count() + 2;
                        origCol = 0;
                        Console.SetCursorPosition(origCol, origRow);
                        item._met(dataReaded);
                    }
                    SelectedOptions.Clear();
                    origRow = 1;
                    origCol = 0;
                    Console.SetCursorPosition(origCol, origRow);
                }
            } while (true);

        }
    }
    public delegate void Del(List<Hotel> targetData);


}


