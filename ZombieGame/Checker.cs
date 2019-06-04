using System.Collections.Generic;
using System.Threading;

namespace ZombieGame
{
    static class Checker
    {
        /// <summary>
        /// Checks all agents in world, accepts max x and y of map 
        /// </summary>
        public static void CheckAgents(List<Agents> nodes, GameSettings setts, AI artint)
        {
            // Go through nº of agents in world
            foreach (Agents k in nodes)
            {
                // While nº of agents !AI move
                for (int ap = 0; ap < nodes.Count; ap++)
                {
                    // If agents are not AI
                    if (!k.Ai)
                    {
                        k.Move(k, setts);
                    }
                    else if (k.Ai)
                    {
                        artint.CheckType(k);
                    }
                }
            }
        }

        ///// <summary>
        ///// Checks Ai agents in List, calls correct movement based
        ///// On agents' state (human or zombie)
        ///// </summary>
        ///// <param name="agents"></param>
        //static public void CheckType(Agents j)
        //{
        //    // Human, runs from zombie
        //    if (j is Human)
        //    {
        //        AI.MoveHumansAi(j);
        //    }
        //    // Zombie, runs towards human
        //    if (j is Zombie)
        //    {
        //        AI.MoveZombiesAi(j);
        //        Thread.Sleep(2000);
        //    }
        //}
    }
}
