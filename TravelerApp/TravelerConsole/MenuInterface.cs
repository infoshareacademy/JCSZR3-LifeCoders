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
    public class Item
    {


        public string text { get; set; }
        public ConsoleKey Key { get; set; }
        public Del met { get; set; }
        public Item(ConsoleKey k, string n, Del M1)
        {
            Key = k;
            text = n;
            met = M1;
        }

    }

    public class MenuInterface
    {
        public static List<Item> lista { get; set; }

        public static void MenuAddItem(ConsoleKey K, string napis, Del method, List<Item> lista)
        {

            

            var i = new Item(K, napis, method);
            lista.Add(i);


        }
        public static void Menu(List<Item> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.Key.ToString() + " " + item.text);
            }

        }

        public static void MenuWork( List<Item> lista)
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
                MenuWork(lista);
                    


        }


    }
    public delegate void Del(List<Root> targetData);

}
