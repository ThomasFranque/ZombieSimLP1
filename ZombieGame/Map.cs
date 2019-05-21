using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Map
    {
        // Declare instance vars
        CharEnum agent;
        
        public int X { get; set; }
        public int Y { get; set; }
        public int H { get; set; }
        public int Z { get; set; }
        public int PH { get; set; }
        public int PZ { get; set; }

        public void ShowMap(int x, int y, int h, int z, int pH, int pZ)
        {
            // Save parameter values in class properties
            X = x;
            Y = y;
            H = h;
            Z = z;
            PH = pH;
            PZ = pZ;

            // For cicle to print map
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(" map ");
                }
                Console.WriteLine();
            }
        }
    }
}
