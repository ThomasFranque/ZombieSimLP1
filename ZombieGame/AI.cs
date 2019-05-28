using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    static class AI
    {
        /// <summary>
        /// Checks agents in List
        /// </summary>
        /// <param name="agents"></param>
        static public void CheckAgents(List <Agents> agents)
        {
            while (agents.Count > 0)
            {
                foreach (Agents j in agents)
                {
                    if (j.Ai)
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
        }

        static public void MoveHumansAi(Agents i)
        {
            // Check if there's zombies around, move way from them
        }

        static public void MoveZombiesAi(Agents i)
        {
            // Check if there's humans around, move towards them
        }
    }
}
