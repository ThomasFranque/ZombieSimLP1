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
                // Diagonals
                // Up Left
                case 'q':
                    if(--Ypos < 0 && --Xpos < 0)
                    {
                        Ypos = y;
                        Xpos = x;
                    }
                    else
                    {
                        Ypos--;
                        Xpos--;
                    }
                    break;
                // Up right
                case 'e':
                    if(--Ypos < 0 && Xpos > x)
                    {
                        Ypos = y;
                        Xpos = 0;
                    }
                    else
                    {
                        Ypos--;
                        Xpos++;
                    }
                    break;
                // Down left
                case 'z':
                    if(++Ypos > y && --Xpos < 0)
                    {
                        Ypos = 0;
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
                    if(++Ypos > y && ++Xpos > x)
                    {
                        Ypos = 0;
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
        public override string ToString()
        {
            return "Agent: ";
        }
    }
}
