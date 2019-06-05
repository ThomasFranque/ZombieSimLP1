using System;
using System.Collections.Generic;

namespace ZombieGame
{
    // All derived class' contain these methods!
    abstract class Agents : IEquatable<Agents>
    {
        // Class variables
        private const int offSett = 1;

        // Agents' Properties
        /// <summary>
        /// Bool to check if agent is AI controlled or not, read-only property
        /// </summary>
        public bool Ai { get; }

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
        public void CheckAgents(List<Agents> agents, int[] size)
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
                        Move(k, size, agents);
                    }
                    else if (k.Ai)
                    {
                        AI artInt = new AI(k.Ai);
                        artInt.CheckType(k);
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
        public void Move(Agents j, int[] size, List<Agents> agents)
        {
            // Variables
            char dir;
            string conv;

            Render.AskInput();          // Asks for input, converts input           
            conv = Console.ReadLine();  // Stores input
            conv = conv.ToLower();      // Converts to lowercase
            dir = Convert.ToChar(conv); // Converts to char

            //// Goes through list and verifies if exist an agent with said coordinates

            switch (dir)
            {
                // Up
                case 'w':
                    if (Y <= 1)
                    {
                        if (Occupied(new int[] { X , size[1] }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("North position is occupied");
                        }
                        else
                            Y = size[1];
                    }
                    else
                    {
                        if (Occupied(new int[] { X , Y - offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("North position is occupied");
                        }
                        else
                            Y--;
                    }
                    break;

                // Left
                case 'a':
                    if (X <= 1)
                    {
                        if (Occupied(new int[] { size[0] , Y }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("West position is occupied");
                        }

                        else
                            X = size[0];
                    }
                    else
                    {
                        if (Occupied(new int[] { X - offSett , Y }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("West position is occupied");
                        }

                        else
                            X--;
                    }
                    break;

                // Right
                case 'd':
                    if (X >= size[0])
                    {
                        if (Occupied(new int[] { offSett , Y }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("East position is occupied");
                        }

                        else
                            X = 1;
                    }
                    else
                    {
                        if (Occupied(new int[] { X + offSett , Y }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("East position is occupied");
                        }

                        else
                            X++;
                    }
                    break;

                // Down
                case 's':
                    if (Y >= size[1])
                    {
                        if (Occupied(new int[] { X , offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("South position is occupied");
                        }

                        else
                            Y = 1;
                    }
                    else
                    {
                        if (Occupied(new int[] { X , Y + offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("South position is occupied");
                        }

                        else
                            Y++;
                    }
                    break;

                // Diagonals
                // Up Left
                case 'q':
                    if (Y <= 1 && X <= 1) // Corner condition
                    {
                        if (Occupied(new int[] { size[0] , size[1] }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northwest position is occupied");
                        }

                        else
                        {
                            Y = size[1];
                            X = size[0];
                        }
                    }
                    else if (Y <= 1) // Up wall condition
                    {
                        if (Occupied(new int[] { X - offSett , size[1] }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northwest position is occupied");
                        }

                        else
                        {
                            Y = size[1];
                            X--;
                        }
                    }
                    else if (X <= 1) // Left wall condition
                    {
                        if (Occupied(new int[] { size[0] , Y - offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northwest position is occupied");
                        }

                        else
                        {
                            Y--;
                            X = size[0];
                        }

                    }
                    else // Other place in map
                    {
                        if (Occupied(new int[] { X - offSett, Y - offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northwest position is occupied");
                        }

                        else
                        {
                            Y--;
                            X--;
                        }
                    }
                    break;

                // Up right
                case 'e':
                    if (Y <= 1 && X >= size[0]) // Corner condition
                    {
                        if (Occupied(new int[] { offSett , size[1] }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northeast position is occupied");
                        }

                        else
                        {
                            Y = size[1];
                            X = 1;
                        }
                    }
                    else if (Y <= 1) // Up wall condition
                    {
                        if (Occupied(new int[] { X + offSett,  size[1] }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northeast position is occupied");
                        }

                        else
                        {
                            Y = size[1];
                            X++;
                        }

                    }
                    else if (X >= size[0]) // Right wall condition
                    {
                        if (Occupied(new int[] { offSett, Y - offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northeast position is occupied");
                        }

                        else
                        {
                            Y--;
                            X = 1;
                        }
                    }
                    else // Other place in map
                    {
                        if (Occupied(new int[] { X + offSett, Y - offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Northeast position is occupied");
                        }

                        else
                        {
                            Y--;
                            X++;
                        }
                    }
                    break;


                // Down left
                case 'z':
                    if (Y >= size[1] && X <= 1) // Corner
                    {
                        if (Occupied(new int[] { size[0], offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southwest position is occupied");
                        }
                        else
                        {
                            Y = 1;
                            X = size[0];
                        }
                    }
                    else if (Y >= size[1]) // Down
                    {
                        if (Occupied(new int[] { X - offSett, offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southwest position is occupied");
                        }
                        else
                        {
                            Y = 1;
                            X--;
                        }
                    }
                    else if (X <= 1) // Right side of map
                    {
                        if (Occupied(new int[] { size[0], Y + offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southwest position is occupied");
                        }

                        else
                        {
                            Y++;
                            X = size[0];
                        }
                    }
                    else
                    {
                        if (Occupied(new int[] { X - offSett, Y + offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southwest position is occupied");
                        }

                        else
                        {
                            Y++;
                            X--;
                        }
                    }
                    break;

                // Down right
                case 'c':
                    // Corner
                    if (Y >= size[1] && X >= size[0])
                    {
                        if (Occupied(new int[] { offSett, offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southeast position is occupied");
                        }

                        else
                        {
                            Y = 1;
                            X = 1;
                        }

                    }
                    else if (Y >= size[1]) // Base
                    {
                        if (Occupied(new int[] { X + offSett, offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southeast position is occupied");
                        }
                        else
                        {
                            Y = 1;
                            X++;
                        }
                    }

                    else if (X >= size[0]) // Right
                    {
                        if (Occupied(new int[] { offSett, Y + offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southeast position is occupied");
                        }
                        else
                        {
                            Y++;
                            X = 1;
                        }
                    }

                    else
                    {
                        if (Occupied(new int[] { X + offSett, Y + offSett }, agents)) // Lock agent j left movement
                        {
                            Render.PressKey("Southeast position is occupied");
                        }

                        else
                        {
                            Y++;
                            X++;
                        }
                    }
                    break;

                // Case input is invalid
                default:

                    break;
            }
        }

        /// <summary>
        /// Returns Agent to string, 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Ai: {Ai}; Agent: ";


        // Check if Agent exist in list
        public bool Equals(Agents other)
        {
            if (other == null) return false;

            else if (X == other.X && Y == other.Y) return true;

            else return false;
        }


        // Check if desired position is occupied by another agent
        private bool Occupied(int[] newPos, List<Agents> agents)
        {
            foreach (Agents a in agents)
            {
                if (newPos[0] == a.X && newPos[1] == a.Y)
                    return true;

            }
            return false;
        }
    }
}
