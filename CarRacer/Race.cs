using System;
using System.Diagnostics;
using System.Threading;

namespace CarRacer
{
    class Race
    {
        static readonly object _object = new object();

        Thread racer1;
        Thread racer2;

        Driver driver2;
        Driver driver1;

        Stopwatch stopwatch;


        /// <summary>
        /// Create Obejects
        /// </summary>
        public Race()
        {
            driver1 = new Driver("steve");
            driver2 = new Driver("george");

            racer1 = new Thread(RaceStart);
            racer2 = new Thread(RaceStart);

            stopwatch = new Stopwatch();

            racer1.Name = driver1.Name;
            racer2.Name = driver2.Name;

            racer1.Start();
            racer2.Start();

            stopwatch.Start();
        }

        /// <summary>
        /// After finishing for loop 
        /// driver finished a lap
        /// </summary>
        public void RaceStart()
        {
            int laps = 0;
            //   Console.WriteLine(Thread.CurrentThread.Name + " started race");
            while (laps <= 5)
            {
                for (int i = 0; i < 500; i++)
                {
                    Accident();
                }
                laps++;
                Console.WriteLine(Thread.CurrentThread.Name + " finished lap " + laps + " with time: " + stopwatch.Elapsed);
            }
            RaceEnd(Thread.CurrentThread.Name, stopwatch.Elapsed);
        }

        /// <summary>
        /// Less then 1% for accident to happen
        /// </summary>
        void Accident()
        {
            int chanceOfAcc = new Random().Next(0, 1500);
            if (chanceOfAcc < 5)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " with number " + chanceOfAcc);
                Thread.Sleep(TimeSpan.FromMilliseconds(5));
                Debug.WriteLine(Thread.CurrentThread.Name + " had accident");
            }
        }

        /// <summary>
        /// Print winner of the race
        /// </summary>
        /// <returns></returns>
        int number = 0;
        string RaceEnd(string name, TimeSpan timer)
        {
            if (number == 0)
            {
                number++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(name + " finished with time: " + timer);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return name + " finished with time: " + timer;
        }
    }
}
