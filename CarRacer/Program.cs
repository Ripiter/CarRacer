using System;

namespace CarRacer
{
    class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race("steve", "george");
            race.StartTreads();
            Console.ReadKey(true);
        }
        public void PrintF(string text)
        {
            Console.WriteLine(text);
        }

    }
}
