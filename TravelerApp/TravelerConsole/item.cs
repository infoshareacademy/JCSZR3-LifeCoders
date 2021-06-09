using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
