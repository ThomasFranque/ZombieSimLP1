using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Human : Agents
    {
        // Human constructor
        public Human ()
        {
            nHumans++;
            Infected = false;
        }
    }
}
