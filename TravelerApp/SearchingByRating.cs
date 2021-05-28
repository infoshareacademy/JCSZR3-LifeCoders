
namespace SearchingByRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel1 = new Hotel("Boston", 4, 5, 5.0, 4, 4, 5, 5);
            Hotel hotel2 = new Hotel("Albany,Oregon", 5, 5, 5.0, 5, 5, 5, 5);
            Hotel hotel3 = new Hotel("Poulsbo, Washington", 5, 4, 5.0, 4, 4, 4, 5);
            Hotel hotel4 = new Hotel("Port Angeles,Wasington", 5, 0, 5.0, 4, 0, 0, 0);
            Hotel hotel5 = new Hotel("San Francisco, California", 3, 3, 3.0, 1, 3, 3, 4);
            Hotel hotel6 = new Hotel("Fort Warth", 4, 5, 3.0, 3, 4, 4, 5);
            Hotel hotel7 = new Hotel("Hersey Pa", 5, 4, 3.0, 4, 4, 3, 3);
            Hotel hotel8 = new Hotel("Breen", 2, 2, 3.0, 4, 3, 3, 4);
            Hotel hotel9 = new Hotel("Israel", 5, 5, 5.0, 5, 5, 5, 5);
            Hotel hotel10 = new Hotel("Cranbrok, Canada", 5, 4, 3.0, 3, 4, 4, 4);
            Hotel hotel11 = new Hotel("Kirkland,WA", 0, 0, 5.0, 0, 0, 0, 0);
            Hotel hotel12 = new Hotel("Phoenix, Arizona", 3, 4, 3.0, 5, 0, 4, 3);

            List<Hotel> list = new List<Hotel>();

            list.Add(hotel1);
            list.Add(hotel2);
            list.Add(hotel3);
            list.Add(hotel4);
            list.Add(hotel5);
            list.Add(hotel6);
            list.Add(hotel7);
            list.Add(hotel8);
            list.Add(hotel9);
            list.Add(hotel10);
            list.Add(hotel11);
            list.Add(hotel12);


            foreach (var item in list)
            {

                Console.WriteLine(item.Overall + " - " + item.Autholocation);

            }

            Console.ReadKey();
        }

        class Hotel
        {
            public string Autholocation { get; set; }
            public int Service { get; set; }
            public int Cleanlines { get; set; }
            public double Overall { get; set; }
            public int Value { get; set; }
            public int SleepQuality { get; set; }
            public int Rooms { get; set; }
            public int Location { get; set; }

            public Hotel(string Autholocation, int Service, int Cleanlines, double Overall, int Value, int SleepQuality, int Rooms, int Location)

            {
                this.Autholocation = Autholocation;
                this.Service = Service;
                this.Cleanlines = Cleanlines;
                this.Overall = Overall;
                this.Value = Value;
                this.SleepQuality = SleepQuality;
                this.Rooms = Rooms;
                this.Location = Location;


            }

        }
    }
}
