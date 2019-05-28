
using System.Collections.Generic;

namespace ZombieGame
{
    class Zombie : Agents
    {
        // Zombie constructor
        public Zombie()
        {
            nZombies++;
            Infected = true;
        }        
    }
}
