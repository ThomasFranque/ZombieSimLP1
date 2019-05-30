using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Map
    {
        // Declare instance variables   
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int z { get; set; }
        public int H { get; set; }
        public int Z { get; set; }

        public void ShowMap(int x, int y, int h, int z, int pH, int pZ)
        {
            // Save parameter values in class properties
            this.x = x;
            this.y = y;
            this.h = h;
            this.z = z;
            H = pH;
            Z = pZ;

            // For cicle to print map
            for (int k = 0; k < x * 4 + 1; k++)
                Console.Write("-");

            Console.WriteLine();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                    Console.Write("| O ");

                Console.WriteLine('|');

                for (int k = 0; k < x * 4 + 1; k++)
                    Console.Write("-");

                Console.WriteLine();

            }
        }
    }
}
