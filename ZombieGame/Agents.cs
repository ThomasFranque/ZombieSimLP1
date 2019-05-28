using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Agents
    {
        // Agents' Properties
        /// <summary>
        /// Is infected?
        /// </summary>
        protected bool Infected { get; set; }

        /// <summary>
        /// Agents' X position
        /// </summary>
        protected int Xpos { get; set; }

        /// <summary>
        /// Y position
        /// </summary>
        protected int Ypos { get; set; }

        /// <summary>
        /// Checks if agent is AI
        /// </summary>
        protected bool Ai { get; set; }

        /// <summary>
        /// Returns and sets total agents in map
        /// </summary>
        protected int AgentsInB { get; set; }

        /// <summary>
        /// Agents controlled by AI
        /// </summary>
        protected int AiAgents { get; set; }

        /// <summary>
        /// Number of zombies in board
        /// </summary>
        protected int nZombies { get; set; }

        /// <summary>
        /// Number of Humans in board
        /// </summary>
        protected int nHumans { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Agents()
        {
        }

        /// <summary>
        /// Gets all agents in board
        /// </summary>
        /// <param name="gs"></param>
        public Agents(GameSettings gs)
        {            
            AgentsInB = gs.z + gs.h + gs.H + gs.Z;
        }

        /// <summary>
        /// Agents move, Calls CheckAgents
        /// </summary>
        protected void MovePlayer(Agents i)
        {
            if (i is AI )
            
            {
                char dir;

                // Go through nº of agents in world
                // Check if controled

                // While nº of agents > 0 move 

                // Humans

                // Zombies

                // Asks for input, converts input
                Console.WriteLine("Use 'WASD' keys to move!");
                dir = Convert.ToChar(Console.ReadLine());

                switch (dir)
                {
                    case 'w':

                        break;

                    case 'a':

                        break;

                    case 's':

                        break;

                    case 'd':

                        break;

                }
            }

        }

        public void Turn()
        {
            // if zombie pos adjacente ou == a human pos
            // Add(new.Zombie in human pos)
            // nHumans--; Remove from list
        }

        /// <summary>
        /// Returns Agent to string, 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Agent: ";
        }
    }
}
