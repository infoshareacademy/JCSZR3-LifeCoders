using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Models
{
    public class SearchHotel
    {
        private IOutput[] _output;

        public enum Type
        {
            Name,
            Localization,
            Rate
        }
        private List<Type> _searches = new List<Type>();

        public SearchHotel(params IOutput[] output)
        {
            _output = output;
        }
        public void SearchByName()
        {
            _searches.Add(Type.Name);
        }

        public void SearchByLocalization()
        {
            _searches.Add(Type.Localization);
        }
        public void SearchByRate()
        {
            _searches.Add(Type.Rate);
        }
        public void GetSearch(List<Root> dataReaded)
        {
            int i = 0;
            List<Root> record = new List<Root>();
            foreach (var searchType in _searches)
            {
                if (searchType == Type.Name)
                {
                    Console.WriteLine("Podaj nazwe: ");
                    FindIt(i, dataReaded, record, (int)searchType);
                }
                else if (searchType == Type.Localization)
                {
                    Console.WriteLine("Podaj adres: ");
                    FindIt(i, dataReaded, record, (int)searchType);
                }
                else if (searchType == Type.Rate)
                {
                    Console.WriteLine("Wyszukaj po ocenie: ");
                    FindIt(i, dataReaded, record, (int)searchType);
                }
                i++;
            }
            foreach (var searchType in _searches)
            {
                if (searchType == Type.Name || searchType == Type.Localization)
                {
                    int numberOfRecords = record.Count();
                    DrawTable.Hotelinfo(record, numberOfRecords);
                }
                else if (searchType == Type.Rate)
                {
                    //@DP: Osobna metoda DrawTable pod oceny (?)
                }
            }
            
        }
        private void FindIt(int i, List<Root> dataReaded, List<Root> record, int search)
        {
            string find = Console.ReadLine();
            find = @$">{find}<";
            Regex regEx = new Regex(find, RegexOptions.IgnoreCase);
            if (i == 0) { record = _output[search].Search(regEx, dataReaded); }
            else { record = _output[search].Search(regEx, record); }
        }
    }

    public interface IOutput
    {
        List<Root> Search(Regex regEx, List<Root> record);
    }

    public class ByName : IOutput
    {
        //@AG: Wyszukiwanie po nazwach - analogicznie do @ŁB
        public List<Root> Search(Regex regEx, List<Root> record)
        {
            List<Root> hotelName = new List<Root>();

            foreach (Root hotel in record)
            {
                if (regEx.IsMatch(hotel.HotelInfo.Name))
                {
                    hotelName.Add(hotel);
                }
            }
            return hotelName;
        }
    }

    public class ByLocalization : IOutput
    {
        //@ŁB: Wyszukiwanie po lokalizacji
        public List<Root> Search(Regex regEx, List<Root> record)
        {
            List<Root> hotelLocalization = new List<Root>();

            foreach (Root hotel in record)
            {
                if (regEx.IsMatch(hotel.HotelInfo.Address))
                {
                    //@ŁB: AddressFormatFixer.FixAddress(hotel); 
                    hotelLocalization.Add(hotel);
                }
            }
            return hotelLocalization;
        }
    }

    public class ByRate : IOutput
    {
        //@GK: Wyszukiwanie po ocenach
        public List<Root> Search(Regex regEx, List<Root> record)
        {
            return default;
        }
    }
}
