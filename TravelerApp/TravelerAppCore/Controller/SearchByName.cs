using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.Controller;
using TravelerAppCore.View;
using System.Text.RegularExpressions;

namespace TravelerAppCore.Controller
{
    public class SearchByName
    {
        public static List<int> HotelsByName(List<Root> dataRead, string searchedName)
        {
            List<int> foundHotels = new List<int>();
            int exactMatch = 0;
            //check if a search name has at least one character in it
            if (string.IsNullOrWhiteSpace(searchedName) != true)
            {
                // search for an exact match first- if found we exit a method after finding one - I assumed hotel names are distinct
                for (int i = 0; i < dataRead.Count; i++)
                {
                    if (dataRead[i].HotelInfo.Name.ToUpper().Equals(searchedName.ToUpper()))
                    {
                        exactMatch++;
                        foundHotels.Add(i);

                    }
                }
                if (exactMatch != 0)
                {
                    return foundHotels;
                }
                else
                //if no exact match has been found- we look for partial match and return all the hotels found
                {
                    for (int i = 0; i < dataRead.Count; i++)
                    {
                        if (dataRead[i].HotelInfo.Name.ToUpper().Contains(searchedName.ToUpper()))
                        {
                            foundHotels.Add(i);
                        }
                    }
                    return foundHotels;
                }
            }
            else
            {
                return foundHotels;
            }
        }
    }
}

