using System;
using System.Collections.Generic;

namespace ZombieGame
{
    // All derived class' contain these methods
    abstract class Agents
    {
        // Agents' Properties
        /// <summary>
        /// Is infected?
        /// </summary>
        public bool Infected { get; protected set; }

        /// <summary>
        /// Agents' X position
        /// </summary>
        public int Xpos { get; protected set; }

        /// <summary>
        /// Y position
        /// </summary>
        public int Ypos { get; protected set; }

        /// <summary>
        /// Checks if agent is AI
        /// </summary>
        public bool Ai { get; protected set; }

        /// <summary>
        /// Agents controlled by AI
        /// </summary>
        public int AiAgents { get; protected set; }

        /// <summary>
        /// Number of zombies in board
        /// </summary>
        public int nZombies { get; protected set; }

        /// <summary>
        /// Number of Humans in board
        /// </summary>
        public int nHumans { get; protected set; }

        /// <summary>
        /// Agents move, Calls CheckAgents
        /// </summary>
        public virtual void CheckAgents(List<Agents> agents, int x, int y)
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
                        MoveAgents(k, x, y);
                    }
                    else if (k.Ai)
                    {
                        AI.CheckType(k);
                    }
                }
            }
        }

        public virtual void Turn()
        {
            // if zombie pos adjacente ou == a human pos
            // Remove/Insert(new.Zombie in human pos)
            // nHumans--; Remove from list
        }

        public virtual void MoveAgents(Agents k, int x, int y)
        {
            char dir;
            // Asks for input, converts input
            Console.WriteLine("Use 'WASD' keys to move!");
            dir = Convert.ToChar(Console.ReadLine());

            switch (dir)
            {
                // Up
                case 'w':

                    k.Ypos--; 
                    
                    if(k.Ypos < y) // Pick this way of condition or
                    {
                        k.Ypos = 0;
                    }
                    break;

                // Left
                case 'a':

                    if(--k.Xpos < 0) // This one
                    {
                        k.Xpos = x;
                    }
                    else
                    {
                        k.Xpos--;
                    }
                    break;

                // Right
                case 's':

                    if (++k.Xpos > x)
                    {
                        k.Xpos = 0;
                    }
                    else
                    {
                        k.Xpos++;
                    }

                    break;

                // Down
                case 'd':

                    if (++k.Ypos > y)
                    {
                        k.Ypos = 0;
                    }
                    else
                    {
                        k.Ypos++;
                    }

                    break;
            }
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
