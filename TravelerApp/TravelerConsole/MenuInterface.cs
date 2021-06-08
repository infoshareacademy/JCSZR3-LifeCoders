using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.Controller;
using TravelerAppCore.Models;

namespace TravelerAppConsole
{


    public class MenuInterface
    {
        private static List<Item> lista = new List<Item>();

        public static void MenuAddItem(ConsoleKey K, string napis, Del method)
        {
            var i = new Item(K, napis, method);
            lista.Add(i);
        }
        public static void Menu()
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.Key.ToString() + " " + item.text);
            }

        }

        public static void MenuWork()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            List<Root> dataReaded = new List<Root>();
            JSON.Read(dataReaded);
            int tmp = 0;
            foreach (var item in lista)
            {
                if (key.Key == item.Key)
                {
                    item.met(dataReaded);
                    tmp = 1;
                }
            }
            if (tmp == 0)
                MenuWork();
                    


        }


    }
    public delegate void Del(List<Root> targetData);

}
