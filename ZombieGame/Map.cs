using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Map
    {

        public void ShowMap(int x, int y, int h, int z, int pH, int pZ)
        {
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    Console.WriteLine("map");
        }
    }
}
