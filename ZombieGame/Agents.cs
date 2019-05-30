using System;
using System.Collections.Generic;

namespace ZombieGame
{
    // All derived class' contain these methods!
    abstract class Agents : Node
    {
        // Agents' Properties
        /// <summary>
        /// Is infected?
        /// </summary>
        public bool Infected { get; protected set; }


        // Agent constructor
        public Agents(bool ai) : base(ai)
        {
            ai = Ai;
        }

        /// <summary>
        /// Agents move, Calls CheckAgents
        /// </summary>
        public virtual void CheckAgents(List<Node> agents)
        {
            // Go through list of agents in world
            foreach (Node k in agents)
            {
                // While nº of agents !AI move
                for (int ap = 0; ap < agents.Count; ap++)
                {
                    // If agents are not AI
                    if (!k.Ai)
                    {
                        Move(k);
                    }
                    else if (k.Ai)
                    {
                        AI.CheckType(k);
                    }
                }
            }
        }

        // Method to infect humans and turn them to zombies
        public virtual void Turn()
        {
            // if zombie pos adjacente ou == a human pos
            // Remove/Insert(new.Zombie in human pos)
            // nHumans--; Remove from list
        }

        /// <summary>
        /// Player moves agents with keys
        /// </summary>
        /// <param name="j"></param>
        public virtual void Move(TestMap map, int x, int y)
        {
            // Variables
            char dir;
            string conv;

            Render.AskInput(); // Asks for input, converts input           
            conv = Console.ReadLine(); // Stores input
            conv = conv.ToLower(); // Converts to lowercase
            dir = Convert.ToChar(conv);// Converts to char

            switch (dir)
            {
                // Up
                case 'w':
                    if (--j. < 0)
                    {
                        j.BoardY = map.BoardY;
                    }                    
                    else
                    {
                        Ypos = 0;
                    }
                    break;

                // Left
                case 'a':
                    if(--Xpos < 0) // This one
                    {
                        Xpos = x;
                    }
                    else
                    {
                        Xpos--;
                    }
                    break;

                // Right
                case 's':
                    if (++Xpos > x)
                    {
                        Xpos = 0;
                    }
                    else
                    {
                        Xpos++;
                    }
                    break;

                // Down
                case 'd':
                    if (++Ypos > y)
                    {
                        Ypos = 0;
                    }
                    else
                    {
                        Ypos++;
                    }
                    break;
                // Diagonals
                // Up Left
                case 'q':
                    if(--Ypos < 0 && --Xpos < 0) // Corner condition
                    {
                        Ypos = y;
                        Xpos = x;
                    }
                    else if(--Ypos < 0) // Up wall condition
                    {
                        Ypos = y;
                        Xpos--;
                    }
                    else if(--Xpos < 0) // Left wall condition
                    {
                        Ypos--;
                        Xpos = x;
                    }
                    else // Other place in map
                    {
                        Ypos--;
                        Xpos--;
                    }
                    break;
                // Up right
                case 'e':
                    if(--Ypos < 0 && Xpos > x) // Corner condition
                    {
                        Ypos = y;
                        Xpos = 0;
                    }
                    else if(--Ypos < 0) // Up wall condition
                    {
                        Ypos = 0;
                        Xpos--;
                    }
                    else if(--Xpos > x) // Right wall condition
                    {
                        Ypos--;
                        Xpos = 0;
                    }
                    else // Normal
                    {
                        Ypos--;
                        Xpos++;
                    }
                    break;
                // Down left
                case 'z':
                    if(++Ypos > y && --Xpos < 0) // Corner
                    {
                        Ypos = 0;
                        Xpos = x;
                    }
                    else if (++Ypos > y) // Down
                    {
                        Ypos = 0;
                        Xpos--;
                    }
                    else if(--Xpos < 0) // Left
                    {
                        Ypos++;
                        Xpos = x;
                    }
                    else
                    {
                        Ypos++;
                        Xpos--;
                    }
                    break;
                // Down right
                case 'c':
                    if(++Ypos > y && ++Xpos > x) // Corner
                    {
                        Ypos = 0;
                        Xpos = 0;
                    }
                    else if(++Ypos > y) // Base
                    {
                        Ypos = 0;
                        Xpos++;
                    }
                    else if (++Xpos > x) // Right
                    {
                        Ypos++;
                        Xpos = 0;
                    }
                    else
                    {
                        Ypos++;
                        Xpos++;
                    }
                    break;
                default:
                    Move(x, y);
                    break;
            }
        }

        /// <summary>
        /// Returns Agent to string, 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Ai: {Ai}; Agent: ";
    }
}
