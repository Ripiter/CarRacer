using System;
using System.Diagnostics;
using System.Threading;

namespace CarRacer
{
    class Race
    {
        Program prog = new Program();

        Thread racer1;
        Thread racer2;

        Driver driver2;
        Driver driver1;

        Stopwatch stopwatch;

        private bool racing = false;

        public bool Racing
        {
            get { return racing; }
            set { racing = value; }
        }


        /// <summary>
        /// Initialize obejects
        /// </summary>
        public Race(string d1Name, string d2Name)
        {
            driver1 = new Driver(d1Name);
            driver2 = new Driver(d2Name);

            racer1 = new Thread(NowThisIsPodRacing);
            racer2 = new Thread(NowThisIsPodRacing);

            stopwatch = new Stopwatch();

            racer1.Name = driver1.Name;
            racer2.Name = driver2.Name;

        }

        /// <summary>
        /// Starts threads and stopwatch
        /// </summary>
        public void StartTreads()
        {
            racer1.Start();
            racer2.Start();

            stopwatch.Start();
            racer1.Join();
        }

        /// <summary>
        /// Driving takes place here
        /// </summary>
        void NowThisIsPodRacing()
        {
            int laps = 0;
            Racing = true;
            while (Racing)
            {
                Accident();
                Thread.Sleep(1000);

                laps++;

                prog.PrintF(Thread.CurrentThread.Name + " finished lap " + laps + " with time: " + stopwatch.Elapsed);

                if (laps == 5)
                    RaceEnd(Thread.CurrentThread.Name, stopwatch.Elapsed);
            }

            /// <summary>
            /// There is 30% for accident to happen
            /// </summary>
            void Accident()
            {
                if (new Random(DateTime.Now.Millisecond).Next(0, 10) < 3)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(5));
                    prog.PrintF(Thread.CurrentThread.Name + " had accident");
                }
            }

            /// <summary>
            /// Print winner of the race
            /// </summary>
            /// <returns></returns>
            string RaceEnd(string name, TimeSpan timer)
            {
                Racing = false;
                Console.ForegroundColor = ConsoleColor.Green;
                prog.PrintF(name + " finished with time: " + timer);
                Console.ForegroundColor = ConsoleColor.White;

                return name + " finished with time: " + timer;
            }
        }
    }
}
