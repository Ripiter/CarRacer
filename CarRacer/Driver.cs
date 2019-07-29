using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacer
{
    class Driver
    {
        public Driver(string name)
        {
            this.Name = name;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int laps = 0;

        /// <summary>
        /// Laps starts with 0
        /// </summary>
        public int Laps
        {
            get
            {
                return laps;
            }
            set
            {
                laps = value;
            }
        }




    }
}
