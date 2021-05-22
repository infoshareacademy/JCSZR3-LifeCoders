using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace TravelerAppConsole
{
  

    public class MenuIntarface 
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
                Console.WriteLine("1. - Wyszukiwanie");
                Console.WriteLine("2. - Sortowanie ");
                Console.WriteLine("Wybierz jedną z powyższych opcji");
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
                    "         N - po nazwie hotelu, \n \t R-po ocenie hotelu,\n \t M-po nazwie miasta \n \tEsc-wróć poziom wyżej");
                while (true)
                {
                

                ConsoleKeyInfo key2 = Console.ReadKey();
                switch (key2.Key)
                {
                    case ConsoleKey.N:
                        SearchOption(key2);
                        break;
                    case ConsoleKey.R:
                        SearchOption(key2);
                        break;
                    case ConsoleKey.M:
                        SearchOption(key2);
                        break;
                    case ConsoleKey.Escape:
                        PLlanguage();
                        break;
                    default:
                        Console.WriteLine("Wrong Option");
                        chooseOption(key);
                        break;


                }
            }
        }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Po czym chcesz sortować");
                Console.WriteLine(
                    "         N - po nazwie hotelu, \n R-po ocenie hotelu,\n M-po nazwie miasta \n Esc-wróć poziom wyżej");
                while (true)
                {
                    ConsoleKeyInfo key2 = Console.ReadKey();
                    switch (key2.Key)
                    {
                        case ConsoleKey.N:
                            SortOption(key2);
                            break;
                        case ConsoleKey.R:
                            SortOption(key2);
                            break;
                        case ConsoleKey.M:
                            SortOption(key2);
                            break;
                        case ConsoleKey.Escape:
                            PLlanguage();
                            break;
                        default:
                            Console.WriteLine("Wrong Option");
                            chooseOption(key);
                            break;


                    }
                }
            }
            else if(key.Key==ConsoleKey.Escape)
                Environment.Exit(0);

           
            
        }

        public virtual void  SearchOption(ConsoleKeyInfo key)
        {
            Console.WriteLine("Uruchomiono SearchOption");
            
        }
        public virtual void SortOption(ConsoleKeyInfo key)
        {
            Console.WriteLine("Uruchomiono SortOption");
            
        }

    }
}
