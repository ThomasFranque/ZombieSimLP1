using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Map
    {
        GameSettings gmSet;

        public void ShowMap()
        {
            for (int i = 0; i < gmSet.x; i++)
                for (int j = 0; j < gmSet.y; j++)
                    Console.WriteLine("map");
        }
    }
}
