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

        public virtual void Turn()
        {
            // if zombie pos adjacente ou == a human pos
            // Remove/Insert(new.Zombie in human pos)
            // nHumans--; Remove from list
        }

        /// <summary>
        /// Player moves agents with keys
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void Move(int x, int y)
        {
            char dir;
            // Asks for input, converts input
            Render.InstMove();
            dir = Convert.ToChar(Console.ReadLine());

            switch (dir)
            {
                // Up
                case 'w':

                    Ypos--; 
                    
                    if(Ypos < y) // Pick this way of condition or
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
