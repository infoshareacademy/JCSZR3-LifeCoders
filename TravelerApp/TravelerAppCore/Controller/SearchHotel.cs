using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelerAppCore.Controller;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Models
{
    public class SearchHotel
    {
        private IOutput[] _output;
        public List<Root> record = new List<Root>();
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
            
            foreach (var searchType in _searches)
            {
                int type = (int)searchType;
                if (searchType == Type.Name)
                {
                    Console.WriteLine("Podaj nazwe: ");
                    record = FindIt(i, dataReaded, record, (int)searchType);
                }
                if (searchType == Type.Localization)
                {
                    Console.WriteLine("Podaj adres: ");
                    record = FindIt(i, dataReaded, record, (int)searchType);
                }
                if (searchType == Type.Rate)
                {
                    Console.WriteLine("Wyszukaj od oceny: ");
                    record = FindIt(i, dataReaded, record, (int)searchType);
                }
                i++;
            }
            //if (_searches.Contains(Type.Rate)) { DrawTable.Hotelinfo(record, record.Count(), true);}
            //else { DrawTable.Hotelinfo(record, record.Count(), false); }

            record = GetAverage.Rates(record);
            DrawTable.Hotelinfo(record, record.Count(), true);
            
        }
        public List<Root> FindIt(int i, List<Root> dataReaded, List<Root> record, int search)
        {
            string find = Console.ReadLine();
            if (i == 0) { record = _output[search].Search(find, dataReaded); }
            else { record = _output[search].Search(find, record); }
            return record;
        }
    }
}

public interface IOutput
{
    List<Root> Search(string find, List<Root> record);
}

public class ByName : IOutput
{
    //@AG: Wyszukiwanie po nazwach - analogicznie do @ŁB
    public List<Root> Search(string find, List<Root> record)
    {
        List<Root> hotelName = new List<Root>();
        find = @$">{find}<";
        Regex regEx = new Regex(find, RegexOptions.IgnoreCase);
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
    public List<Root> Search(string find, List<Root> record)
    {
        List<Root> hotelLocalization = new List<Root>();
        find = @$">{find}<";
        Regex regEx = new Regex(find, RegexOptions.IgnoreCase);
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
    public List<Root> Search(string find, List<Root> record)
    {
        //@GK: Wyszukiwanie po ocenach
        return default;
    }
}



