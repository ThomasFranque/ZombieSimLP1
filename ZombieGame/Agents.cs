﻿using System;
using System.Collections.Generic;

namespace ZombieGame
{
    // All derived class' contain these methods!
    abstract class Agents
    {
        // Class variables
        /// <summary>
        /// Bool to check if agent is AI controlled or not, read-only property
        /// </summary>
        public bool Ai { get; }

        // Agents' Properties
        /// <summary>
        /// Is infected?
        /// </summary>
        public bool Infected { get; protected set; }

        /// <summary>
        /// Readonly property of the position of the agent on the X axis
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Readonly property of the position of the agent on the Y axis
        /// </summary>
        public int Y { get; private set; }


        // Agent constructor
        public Agents(bool ai) 
        {
            Random r = new Random();
            // Default position is x = 1 and y = 1
            // Random is set for debugging
            X = r.Next(1, 8);
            Y = r.Next(1, 8);

            Ai = ai;
        }

        /// <summary>
        /// Agents move, Calls CheckAgents
        /// </summary>
        public virtual void CheckAgents(List<Agents> agents, GameSettings setts, AI artint)
        {
            // Go through list of agents in world
            foreach (Agents k in agents)
            {
                // While nº of agents !AI move
                for (int ap = 0; ap < agents.Count; ap++)
                {
                    // If agents are not AI
                    if (!k.Ai)
                    {
                        Move(k, setts);
                    }
                    else if (k.Ai)
                    {
                        artint.CheckType(k);
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
        public virtual void Move(Agents j, GameSettings setts)
        {
            // Variables
            char dir;
            string conv;

            Render.AskInput();          // Asks for input, converts input           
            conv = Console.ReadLine();  // Stores input
            conv = conv.ToLower();      // Converts to lowercase
            dir = Convert.ToChar(conv); // Converts to char

            switch (dir)
            {
                // Up
                case 'w':
                    if(--Y < 1)
                    {
                        Y = setts.y;
                    }
                    else
                    {
                        Y = 0;
                    }
                    break;

                // Left
                case 'a':
                    if (--X < 1)
                    {
                        X = setts.x;
                    }
                    else
                    {
                        X--;
                    }
                    break;

                // Right
                case 's':
                    if (++X > setts.x)
                    {
                        X = 1;
                    }
                    else
                    {
                        X++;
                    }
                    break;

                // Down
                case 'd':
                    if (++Y > setts.y)
                    {
                        Y = 1;
                    }
                    else
                    {
                        Y++;
                    }
                    break;

                // Diagonals
                // Up Left
                case 'q':
                    if (--Y < 1 && --X < 1) // Corner condition
                    {
                        Y = setts.y;
                        X = setts.x;
                    }
                    else if (--Y < 1) // Up wall condition
                    {
                        Y = setts.y;
                        X--;
                    }
                    else if (--X < 1) // Left wall condition
                    {
                        Y--;
                        X = setts.x;
                    }
                    else // Other place in map
                    {
                        Y--;
                        X--;
                    }
                    break;

                // Up right
                case 'e':
                    if (--Y < 1 && ++X > setts.x) // Corner condition
                    {
                        Y = setts.y;
                        X = 1;
                    }
                    else if (--Y < 1) // Up wall condition
                    {
                        Y = 1;
                        X++;
                    }
                    else if (++X > setts.x) // Right wall condition
                    {
                        Y--;
                        X = 1;
                    }
                    else // Normal
                    {
                        Y--;
                        X++;
                    }
                    break;

                // Down left
                case 'z':
                    if (++Y > setts.y && --X < 1) // Corner
                    {
                        Y = 1;
                        X = setts.x;
                    }
                    else if (++Y > setts.y) // Down
                    {
                        Y = 1;
                        X--;
                    }
                    else if (--X < 1) // Left
                    {
                        Y++;
                        X = setts.x;
                    }
                    else
                    {
                        Y++;
                        X--;
                    }
                    break;

                // Down right
                case 'c':
                    if (++Y > setts.y && ++X > setts.x) // Corner
                    {
                        Y = 1;
                        X = 1;
                    }
                    else if (++Y > setts.y) // Base
                    {
                        Y = 1;
                        X++;
                    }
                    else if (++X > setts.x) // Right
                    {
                        Y++;
                        X = 1;
                    }
                    else
                    {
                        Y++;
                        X++;
                    }
                    break;

                // Case input is invalid
                default:
                    Move(j, setts);
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
