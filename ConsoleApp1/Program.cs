using System.Diagnostics;
using System.Reflection.Metadata;

namespace Events_PracticWork
{
    public delegate void TraideDelegate(double course);
    class Traider
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private double money;

        public double Money
        {
            get { return money; }
            set { if (value > 0) money = value; }
        }
        public void TraiderAction(double course)
        {
            if (course > 41)
            {
                Console.WriteLine();
                Console.WriteLine("I buy 100 dollar!!!");

                if (money > 100 * course)
                {
                    money -= 100 * course;
                }
            else
            {

                Console.WriteLine("You are not enough your money!!!");

            }
            }
            else if (course < 36)
            {
                Console.WriteLine();
                Console.WriteLine("I sell course!!!");
                money += 100 * course;
                Console.WriteLine();
            }
            for (int i = 0; i < 60; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            Console.WriteLine($"Traider :\n F and L name : {Firstname} {Lastname}\n Count money: {Math.Round(Money,2)}\n Course: {Math.Round( course, 2)}\n");
            for (int i = 0; i < 60; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }
        

    }
    class Exchange
    {
        
        Random rnd = new Random();
        public event Action TestEvent;
        public event TraideDelegate traideDelegate;

        //private

        public double Course { get; set; }

        public double GenerateCource()
        {
            Course = rnd.Next(35,45)+ rnd.NextDouble();
            return Course;
        }
        public void CallAllTraiders() {
            GenerateCource();
            traideDelegate?.Invoke(Course);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Traider> traiders = new List<Traider>
            {
                new Traider
                {
                    Firstname = "Emily",
                    Lastname = "Johnson",
                    Birthday = new DateTime(1995, 7, 15),
                    Money = 2500,
                },
                new Traider
                {
                    Firstname = "Michael",
                    Lastname = "Smith",
                    Birthday = new DateTime(1988, 4, 23),
                    Money = 4200,
                },
                new Traider
                {
                    Firstname = "Sophia",
                    Lastname = "Williams",
                    Birthday = new DateTime(2001, 11, 9),
                    Money = 1700,
                },
                 new Traider
                {
                    Firstname = "Daniel",
                    Lastname = "Brown",
                    Birthday = new DateTime(1993, 9, 5),
                    Money = 3100,
                },
                  new Traider
                {
                    Firstname = "Olivia",
                    Lastname = "Davis",
                    Birthday = new DateTime(1985, 12, 30),
                    Money = 2500,
                },
                   new Traider
                {
                    Firstname = "James",
                    Lastname = "Miller",
                     Birthday = new DateTime(1997, 3, 12),
                    Money = 4800,
                },
            };

            Exchange exchange = new Exchange();

            foreach (var tr in traiders)
            {
                exchange.traideDelegate += new TraideDelegate(tr.TraiderAction);
            }

            exchange.traideDelegate -= traiders[3].TraiderAction;
        


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Day : "+(i+1));
                exchange.CallAllTraiders();
                Console.WriteLine();
            }
        }
    }
}
