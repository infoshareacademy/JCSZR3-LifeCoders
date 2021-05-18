using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.View
{
    public class DrawTable
    {
        public static int tableWidth;
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(bool newline, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            if (newline) { Console.WriteLine(row); }
            else Console.Write(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        public static void Hotelinfo(List<Root> dataReaded, int numRecords)
        {
            //Przykład wypisywania informacji w tabeli - użytek dowolny i własnowolny
            DrawTable.tableWidth = 165;
            DrawTable.PrintLine();
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(false, "Id");
            DrawTable.tableWidth = 80;
            DrawTable.PrintRow(false, "Name", "HotelUrl");
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(false, "Price");
            DrawTable.tableWidth = 40;
            DrawTable.PrintRow(false, "Address");
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(true, "HotelID");
            DrawTable.tableWidth = 165;
            DrawTable.PrintLine();
            int count = 1;
            for (int i = 0; i < numRecords; i++)
            {
                DrawTable.tableWidth = 15;
                DrawTable.PrintRow(false, (i + 1).ToString());
                DrawTable.tableWidth = 80;
                DrawTable.PrintRow(false, dataReaded[i].HotelInfo.Name, dataReaded[i].HotelInfo.HotelURL);
                DrawTable.tableWidth = 15;
                DrawTable.PrintRow(false, dataReaded[i].HotelInfo.Price);
                DrawTable.tableWidth = 40;
                DrawTable.PrintRow(false, dataReaded[i].HotelInfo.Address);
                DrawTable.tableWidth = 15;
                DrawTable.PrintRow(true, dataReaded[i].HotelInfo.HotelID);
                //count++;
            }
            DrawTable.tableWidth = 165;
            DrawTable.PrintLine();
        }
    }
}
