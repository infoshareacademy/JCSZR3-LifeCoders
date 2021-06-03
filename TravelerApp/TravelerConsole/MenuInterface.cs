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
      

        public void Menu()
        {


            Console.Title = "Interface menu";
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
                Console.WriteLine("Which option do you want to search?");
                Console.WriteLine(
                    "\n\tN - by hotel name, \n \tR - by hotel rate,\n \tL - by hotel localisation  \n \tEsc-level up");
                while (true)
                {


                    ConsoleKeyInfo key2 = Console.ReadKey();
                    if (key2.Key == ConsoleKey.L || key2.Key == ConsoleKey.N || key2.Key == ConsoleKey.R)
                    {
                        
                        Choice(key2,key);
                       
                    }
                    else if (key2.Key == ConsoleKey.Escape)
                    {

                        Menu();

                    }
                    else
                        chooseOption(key);
                }
   
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Choose one option");
                Console.WriteLine(
                    "\n\tR-Sort by rate \n\tEsc-level up");
                while (true)
                {
                    ConsoleKeyInfo key2 = Console.ReadKey();
                    if (key2.Key == ConsoleKey.R)
                    {

                        Choice(key2, key);

                    }
                    else if (key2.Key == ConsoleKey.Escape)
                    {

                        Menu();

                    }
                    else
                        chooseOption(key);



                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
               
            }
           
            
        }

        public void Choice(ConsoleKeyInfo key2,ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.D1)
            {
                if (key2.Key == ConsoleKey.L)
                    Console.WriteLine("SearchByLocalisation");
                    // hotels.SearchByLocalization();;
                    
                else if (key2.Key == ConsoleKey.N)
                    Console.WriteLine("searchByName");
                    //hotels.SearchByName();
                    
                else if (key2.Key == ConsoleKey.R)
                    Console.WriteLine("searchByRate");
                    //hotels.SearchByRate();
                    ;
            }
            else 
            {

                if (key2.Key == ConsoleKey.R)
                    Console.WriteLine("Sort");
                    // hotels.Sort();
                    ;
              
                    


            }

        }



    }
}
