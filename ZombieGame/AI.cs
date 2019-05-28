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
                        MoveAgentsAi(j);
                    }
                    if (j is Zombie)
                    {
                        MoveAgentsAi(j);
                    }
                }
            }
        }
    }
}
