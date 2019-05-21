using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Map
    {

        public void ShowMap(int x, int y, byte h, byte z)
        {
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    Console.WriteLine("map");
        }
    }
}
