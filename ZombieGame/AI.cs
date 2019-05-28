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

        /// <summary>
        /// Automated agents' movement
        /// </summary>
        /// <param name="i"></param>
        public void MoveAgentsAi(Agents i)
        {
        }

        /// <summary>
        /// Checks agents in List
        /// </summary>
        /// <param name="agents"></param>
        public void CheckAgents(List <Agents> agents)
        {
            while (AiAgents > 0)
            {
                foreach (Agents j in agents)
                {
                    if (j is Human)
                    {
                        MoveHumansAi(j);
                    }
                    if (j is Zombie)
                    {
                        MoveZombiesAi(j);
                    }
                }
            }
        }

        public void MoveHumansAi(Agents i)
        {
            // Check if there's zombies around, move way from them
        }

        public void MoveZombiesAi(Agents i)
        {
            // Check if there's humans around, move towards them
        }
    }
}
