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

namespace TravelerAppConsole
{
  

    public class MenuInterface: TravelerAppCore.Controller.JSON
    {
        public void chooseLanguage()
        {
            Console.Title = "Interface menu";

            Console.WriteLine("Choose language: E - English, P-Polish");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E) Elanguage();
            else if (key.Key == ConsoleKey.P)
            {
                PLlanguage();
            }
            else
            {
                Console.WriteLine("Wrong option"); 
                chooseLanguage();
            }

           
        



    }

        private  void Elanguage()
        {


        }
        private void PLlanguage()
        {
             
                

                Console.Clear();
                Console.WriteLine(">>>Menu<<<");
                Console.WriteLine("1. - Search");
                Console.WriteLine("2. - Sort ");
                Console.WriteLine("Choose one option");
               ConsoleKeyInfo key = Console.ReadKey();
               chooseOption(key);
          
        }

        public void chooseOption(ConsoleKeyInfo key)
        {

            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("Po czym chcesz wyszukiwać");
                Console.WriteLine(
                    "N - po nazwie hotelu, \n \t R-po ocenie hotelu,\n \t -po nazwie miasta \n \tEsc-wróć poziom wyżej");
                while (true)
                {


                    ConsoleKeyInfo key2 = Console.ReadKey();
                    if (key2.Key != ConsoleKey.L && key2.Key != ConsoleKey.N && key2.Key != ConsoleKey.R)
                    {
                        
                        chooseOption(key);
                       
                    }
                    else if (key2.Key == ConsoleKey.Escape)
                    {
                        
                        chooseOption(key);
                       
                    }
                    else
                        Choice(key2,key);
                }
   
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Po czym chcesz sortować");
                Console.WriteLine(
                    "         R-sortowanie po ocenie Esc-wróć poziom wyżej");
                while (true)
                {
                    ConsoleKeyInfo key2 = Console.ReadKey();
                    if ( key2.Key != ConsoleKey.R)
                    {

                        chooseOption(key);

                    }
                    else if (key2.Key == ConsoleKey.Escape)
                    {

                        chooseOption(key);

                    }
                    else
                        Choice(key2,key);



                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
               
            }
           
            
        }

        public void Choice(ConsoleKeyInfo key2,ConsoleKeyInfo key)
        {
          
        }

        public void  SearchOption(ConsoleKeyInfo key)
        {
            List<Root> dataReaded = new List<Root>();
            JSON.Read(dataReaded);
            if (key.Key == ConsoleKey.M)
                 TravelerAppCore.Models.Search.byLocalisation(dataReaded);
                
            else if (key.Key == ConsoleKey.R)
                //Search by rating
                ;
            else
                //search by name
                ;
        }
        public  void SortOption(ConsoleKeyInfo key)
        {
            List<Root> dataReaded = new List<Root>();
            JSON.Read(dataReaded);
            Console.WriteLine("Uruchomiono SortOption");
           // TravelerAppCore.Controller.Sort.sort(dataReaded);
        }

    }
}
