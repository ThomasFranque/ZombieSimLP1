using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    static class Checker
    {
        /// <summary>
        /// Checks all agents in world, accepts max x and y of map 
        /// </summary>
        public static void CheckAgents(List<Agents> agents, int x, int y)
        {
            // Go through nº of agents in world
            foreach (Agents k in agents)
            {
                // While nº of agents !AI move
                for (int ap = 0; ap < agents.Count; ap++)
                {
                    // If agents are not AI
                    if (!k.Ai)
                    {
                        k.Move(x, y);
                    }
                    else if (k.Ai)
                    {
                        AI.CheckType(k);
                    }
                }
            }
        }
    }
}
