using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class AI : Agents
    {
        public AI ()
        {

        }

        public void MoveAgents(Agents i)
        {
            if(i is Human)
            {
                // Checks map
                // Moves away from zombie
            }
            if (i is Zombie)
            {
                // Checks map
                // Moves toward human
            }
            else
            {

            }
        }

        // Move to checker
        protected void CheckAgents(Agents agents)
        {
            while (AgentsInB > 0)
            {
                //Agents j;
                //foreach ()
                //{

                //}

            }
        }
    }
}
