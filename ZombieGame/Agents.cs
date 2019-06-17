using System;
using System.Collections.Generic;

namespace ZombieGame
{
    // All derived class' contain these methods!
    abstract class Agents : IEquatable<Agents>
    {
        // Class variables
        private const int offSett = 1;

        // Know if the agent can infect
        internal bool canInfect;

        // Agents' Properties
        /// <summary>
        /// Bool to check if agent is AI controlled or not, read-only property
        /// </summary>
        public bool Ai { get; }

        /// <summary>
        /// Bool property to define if an agent is infected or not
        /// </summary>
        public bool Infected { get; protected set; }

        /// <summary>
        /// Read-only property of the position of the agent on the X axis
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Read-only property of the position of the agent on the Y axis
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Agent constructor, to be used by every derived class.
        /// </summary>
        /// <param name="AIUnit"> Defines if Agent is AI controlled or 
        /// not. </param>
        /// <param name="sizeX"> Uses board size to 
        /// give x position to agent </param>
        /// <param name="sizeY">Uses board size to 
        /// give y position to agent</param>
        public Agents(bool ai, int sizeX, int sizeY)
        {
            Random r = new Random();
            // Default position is x = 1 and y = 1
            // Random is set for debugging
            X = r.Next(1, sizeX + 1);
            Y = r.Next(1, sizeY + 1);

            Ai = ai;
        }

        /// <summary>
        /// Agent constructor to be used if user loads save file
        /// </summary>
        /// <param name="ai"> Defines if Agent is AI controlled or 
        /// not.</param>
        /// <param name="X"> Uses board size to 
        /// give x position to agent. </param>
        /// <param name="Y"> Uses board size to 
        /// give y position to agent. </param>
        public Agents(string ai, string X, string Y)
        {
            this.X = Convert.ToInt32(X);
            this.Y = Convert.ToInt32(Y);
            Ai = Convert.ToBoolean(ai);
        }

        /// <summary>
        /// Method to infect Human agents. To be used only when 
        /// human agents are involved
        /// </summary>
        /// <param name="human">Uses a given Human Agent</param>
        public virtual void Infect(Agents human)
        {
            human.Infected = true;
        }

        /// <summary>
        /// Method for Agent movement, mo  with keys
        /// </summary>
        /// <param name="j"> Agent that will be moved. </param>
        /// <param name="size"> Max board size. </param>
        /// <param name="agents"> List of Agents in game. </param>
        /// <param name="dir"> Chosen direction. </param>
        public void Move(Agents j, int[] size, IEnumerable<Agents> agents,
            char dir)
        {
            // Goes through list...
            //...and verifies if exist an agent with said coordinates
            switch (dir)
            {
                // Up
                case 'w':
                    if (Y <= 1)
                    {
                        // Lock agent j up movement if bottom side of map...
                        // ...is occupied
                        if (Occupied(new int[] { X, size[1] }, agents))
                        {
                            Console.WriteLine("North position is occupied");
                        }
                        // Goes around map (max size, Y)
                        else
                        {
                            Y = size[1];
                        }
                    }
                    else
                    {
                        // Lock agent j up movement, if position above...
                        // ...is occupied.
                        if (Occupied(new int[] { X, Y - offSett }, agents))
                        {
                            Console.WriteLine("North position is occupied");
                        }
                        // Goes up
                        else
                        {
                            Y--;
                        }
                    }
                    break;

                // Left
                case 'a':
                    if (X <= 1)
                    {
                        // Lock agent j left movement... 
                        // ... if other side of map is occupied
                        if (Occupied(new int[] { size[0], Y }, agents))
                        {
                            Console.WriteLine("West position is occupied");
                        }
                        // Goes arround map, (max size X)
                        else
                        {
                            X = size[0];
                        }
                    }
                    else
                    {
                        // Lock agent j left movement if position occupied
                        if (Occupied(new int[] { X - offSett, Y }, agents))
                        {
                            Console.WriteLine("West position is occupied");
                        }
                        // Goes left
                        else
                        {
                            X--;
                        }
                    }
                    break;

                // Right
                case 'd':
                    if (X >= size[0])
                    {
                        // Lock agent j right movement...
                        // ... if other side of map is occupied
                        if (Occupied(new int[] { offSett, Y }, agents))
                        {
                            Console.WriteLine("East position is occupied");
                        }
                        // Goes around map, right (min x)
                        else
                        {
                            X = 1;
                        }
                    }
                    else
                    {
                        // Lock agent j right movement if occupied pos
                        if (Occupied(new int[] { X + offSett, Y }, agents))
                        {
                            Console.WriteLine("East position is occupied");
                        }
                        // Moves right
                        else
                        {
                            X++;
                        }
                    }
                    break;

                // Down
                case 's':
                    if (Y >= size[1])
                    {
                        // Lock agent j down movement if other side occupied
                        if (Occupied(new int[] { X, offSett }, agents))
                        {
                            Console.WriteLine("South position is occupied");
                        }
                        // Goes around map (min y)
                        else
                        {
                            Y = 1;
                        }
                    }
                    else
                    {
                        // Lock agent j down movement if up side is occupied
                        if (Occupied(new int[] { X, Y + offSett }, agents))
                        {
                            Console.WriteLine("South position is occupied");
                        }
                        // Moves down
                        else
                        {
                            Y++;
                        }
                    }
                    break;

                // ** Diagonals **
                // Up Left
                case 'q':
                    // Corner condition
                    if (Y <= 1 && X <= 1)
                    {
                        // Lock agent j up left movement... 
                        // ... if other corner is occupied
                        if (Occupied(new int[] { size[0], size[1] }, 
                            agents))
                        {
                            Console.WriteLine
                                ("Northwest position is occupied");
                        }
                        // Goes to opposite corner
                        else
                        {
                            Y = size[1];
                            X = size[0];
                        }
                    }
                    // Up wall condition
                    else if (Y <= 1)
                    {
                        // Lock agent j up movement if other side is occupied
                        if (Occupied(new int[] { X - offSett, size[1] },
                            agents))
                        {
                            Console.WriteLine
                                ("Northwest position is occupied");
                        }
                        // Goes around map and moves left
                        else
                        {
                            Y = size[1];
                            X--;
                        }
                    }
                    // Left wall condition
                    else if (X <= 1)
                    {
                        // Lock agent j left movement if other side is occupied
                        if (Occupied(new int[] { size[0], Y - offSett },
                            agents))
                        {
                            Console.WriteLine
                                ("Northwest position is occupied");
                        }
                        // Goes to the other side (max x) and left
                        else
                        {
                            Y--;
                            X = size[0];
                        }
                    }
                    // Normal place in map
                    else
                    {
                        // Lock agent j movement case a cell is occupied
                        if (Occupied(new int[] { X - offSett, Y - offSett },
                            agents))
                        {
                            Console.WriteLine("Northwest position is occupied");
                        }
                        // Moves diagonally
                        else
                        {
                            Y--;
                            X--;
                        }
                    }
                    break;


                // Up right
                case 'e':
                    // Corner condition
                    if (Y <= 1 && X >= size[0])
                    {
                        // Lock agent j up right movement if occupied pos
                        if (Occupied(new int[] { offSett, size[1] }, agents))
                        {
                            Console.WriteLine
                                ("Northeast position is occupied");
                        }
                        // Moves to opposite corner
                        else
                        {
                            Y = size[1];
                            X = 1;
                        }
                    }
                    // Up wall condition
                    else if (Y <= 1)
                    {
                        // Lock agent j up movement...
                        // ...if pos occupied in other side
                        if (Occupied(new int[] { X + offSett, size[1] },
                            agents))
                        {
                            Console.WriteLine
                                ("Northeast position is occupied");
                        }
                        // Goes around (max y) and right
                        else
                        {
                            Y = size[1];
                            X++;
                        }
                    }
                    // Right wall condition
                    else if (X >= size[0])
                    {
                        // Lock agent j right movement
                        if (Occupied(new int[] { offSett, Y - offSett },
                            agents))
                        {
                            Console.WriteLine("Northeast position is occupied");
                        }
                        // Goes around (min x) and up
                        else
                        {
                            Y--;
                            X = 1;
                        }
                    }
                    // Normal place in map
                    else
                    {
                        // Lock agent j up right movement, occupied position
                        if (Occupied(new int[] { X + offSett, Y - offSett }, 
                            agents))
                        {
                            Console.WriteLine
                                ("Northeast position is occupied");
                        }
                        // Moves diagonally
                        else
                        {
                            Y--;
                            X++;
                        }
                    }
                    break;

                // Down left
                case 'z':
                    // Corner condition
                    if (Y >= size[1] && X <= 1)
                    {
                        // Lock agent j down left movement...
                        // ...if occupied position in opposite corner
                        if (Occupied(new int[] { size[0], offSett }, agents))
                        {
                            Console.WriteLine
                                ("Southwest position is occupied");
                        }
                        // Moves to opposite corner
                        else
                        {
                            Y = 1;
                            X = size[0];
                        }
                    }
                    // Down condition
                    else if (Y >= size[1])
                    {
                        // Lock agent j down movement
                        if (Occupied(new int[] { X - offSett, offSett },
                            agents))
                        {
                            Console.WriteLine
                                ("Southwest position is occupied");
                        }
                        // Goes around map (min y) and left
                        else
                        {
                            Y = 1;
                            X--;
                        }
                    }
                    // Left side of map
                    else if (X <= 1)
                    {
                        // Lock agent j left movement
                        if (Occupied(new int[] { size[0], Y + offSett },
                            agents))
                        {
                            Console.WriteLine
                                ("Southwest position is occupied");
                        }
                        // Goes down and around (max x)
                        else
                        {
                            Y++;
                            X = size[0];
                        }
                    }
                    // Normal place in map
                    else
                    {
                        // Lock agent j down left movement, occupied position
                        if (Occupied(new int[] { X - offSett, Y + offSett },
                            agents))
                        {
                            Console.WriteLine
                                ("Southwest position is occupied");
                        }
                        // Moves diagonally
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
                        // Lock agent j down right movement
                        if (Occupied(new int[] { offSett,  offSett }, agents))
                        {
                            Console.WriteLine
                                ("Southeast position is occupied");
                        }
                        // Moves to opposite corner
                        else
                        {
                            Y = 1;
                            X = 1;
                        }

                    }
                    // Base/Down condition
                    else if (Y >= size[1])
                    {
                        // Lock agent j down movement, occupied pos
                        if (Occupied(new int[] { X + offSett, offSett }, 
                            agents))
                        {
                            Console.WriteLine
                                ("Southeast position is occupied");
                        }
                        // Goes around (min y) and right
                        else
                        {
                            Y = 1;
                            X++;
                        }
                    }
                    // Right
                    else if (X >= size[0])
                    {
                        // Lock agent j right movement, occupied
                        if (Occupied(new int[] { offSett, Y + offSett }, 
                            agents))
                        {
                            Console.WriteLine
                                ("Southeast position is occupied");
                        }
                        // Moves
                        else
                        {
                            Y++;
                            X = 1;
                        }
                    }
                    // Normal
                    else
                    {
                        // Lock agent j diagonal movement
                        if (Occupied(new int[] { X + offSett, Y + offSett },
                            agents))
                        {
                            Console.WriteLine
                                ("Southeast position is occupied");
                        }
                        // Moves
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
        /// Overload to the method Move() to be used by AI
        /// </summary>
        /// <param name="j"> Specific agent to be moved. </param>
        /// <param name="size"> Board size values. </param>
        /// <param name="agents"> List of Agents. </param>
        public void Move(Agents j, int[] size, List<Agents> agents)
        {
            Move(j, size, agents, FindNearest(agents, size));
        }

        /// <summary>
        /// Returns Agent to string.
        /// </summary>
        /// <returns> String with Agent's info. </returns>
        public override string ToString() => $"Ai: {Ai} Agent: ";


        /// <summary>
        /// Implementation of IEquatable, check if a Agent is equal to another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Depending on if Agents are equal,
        /// returns true or false. </returns>
        public bool Equals(Agents other)
        {
            if (other == null) return false;

            else if (X == other.X && Y == other.Y) return true;

            else return false;
        }


        /// <summary>
        /// Check if desired position is occupied by another agent
        /// </summary>
        /// <param name="newPos"> Array that contains
        /// board size values. </param>
        /// <param name="agents"> List of Agents to compare positions. </param>
        /// <returns></returns>
        private bool Occupied(int[] newPos, IEnumerable<Agents> agents)
        {
            foreach (Agents a in agents)
            {
                if (newPos[0] == a.X && newPos[1] == a.Y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Method that goes through Agent list and finds the first nearest
        /// Agent to specific Agent.
        /// </summary>
        /// <param name="agents"> List of Agents. </param>
        /// <param name="boardSize"> Array that contains
        /// board max values. </param>
        /// <returns></returns>
        private char FindNearest(List<Agents> agents, int[] boardSize)
        {
            // Direction
            char dir = ' ';
            // Radius of the circle
            int n = 1;
            // Used to determine where to check next
            int[] posOffset = new int[2] { 1, 0 };

            // Start place
            int[] pos = new int[2] { X - 1, Y + 1 };

            // Know how many to walk on each side
            int side = 0;

            if (Infected) canInfect = true;

            bool oppositeX, oppositeY;
            oppositeX = oppositeY = false;

            bool nonInfectedInGame = false;

            // While direction is default
            while (dir == ' ')
            {
                // In which of the agent we are 

                // Loop for adjacent cells
                for (int i = 0; i < n * 8; i++)
                {

                    if (pos[0] <= 0)
                    {
                        pos[0] = boardSize[0];
                        oppositeX = !oppositeX;
                    }
                    else if (pos[0] > boardSize[0])
                    {
                        pos[0] = 1;
                        oppositeX = !oppositeX;
                    }

                    if (pos[1] <= 0)
                    {
                        oppositeY = !oppositeY;
                        pos[1] = boardSize[1];
                    }
                    else if (pos[1] > boardSize[1])
                    {
                        oppositeY = !oppositeY;
                        pos[1] = 1;
                    }


                    // Run through all of the agents
                    foreach (Agents a in agents)
                    {
                        if (!a.Infected) nonInfectedInGame = true;

                        // found a human
                        if ((this is Zombie || Infected) && (a is Human &&
                            !a.Infected))
                        {
                            // Check if it is there
                            if (a.X == pos[0] && a.Y == pos[1])
                            {
                                if (!a.Infected && canInfect)
                                {
                                    Console.WriteLine("INFECTED: " + a);

                                    a.Infected = true;
                                    continue;
                                }

                                Console.WriteLine("\nGOING TOWARDS: \n" + a +
                                    "\n\n");

                                dir = ClosestChar(a, oppositeX, oppositeY);
                                // ADD INFECT LATER
                                break;
                            }
                        }
                        else if ((this is Human && !Infected) && (a.Infected ||
                            a is Zombie))
                        {
                            // Check if it is there
                            if (a.X == pos[0] && a.Y == pos[1])
                            {
                                Console.WriteLine("\nRUNNING FROM: \n" + a +
                                    "\n\n");
                                dir = ClosestChar(a, oppositeX, oppositeY);
                                break;
                            }
                        }
                    }

                    if (dir != ' ') break;

                    // Move the virtual cell
                    // Change offset
                    side++;
                    if (side > n + 1 + (n - 1))
                    {
                        // Going Up
                        if (posOffset[0] == 0 && posOffset[1] == -1)
                        {
                            posOffset[0] = -1;
                            posOffset[1] = 0;
                        }
                        // Going Right
                        else if (posOffset[0] == 1 && posOffset[1] == 0)
                        {
                            posOffset[0] = 0;
                            posOffset[1] = -1;
                        }
                        // Going Down
                        else if (posOffset[0] == 0 && posOffset[1] == 1)
                        {
                            posOffset[0] = 1;
                            posOffset[1] = 0;
                        }
                        // Going left
                        else if (posOffset[0] == -1 && posOffset[1] == 0)
                        {
                            posOffset[0] = 0;
                            posOffset[1] = 1;
                        }
                        side = 1;
                    }

                    pos[0] += posOffset[0];
                    pos[1] += posOffset[1];

                    // IF POSOFFSET[0] > BOARD.X POSOFFSET = 0;
                }

                if (!nonInfectedInGame) dir = 'd';

                // Reset direction
                posOffset[0] = 1;
                posOffset[1] = 0;

                // New position
                pos = new int[2] { pos[0] - 1, pos[1] + 1 };
                side = 0;
                nonInfectedInGame = false;
                canInfect = false;

                n++;
            }
            return dir;
        }


        /// <summary>
        /// Method to select directional char towards the closest Agent,
        /// to be used in AI movement.
        /// </summary>
        /// <param name="a"> Specific Agent to be moved</param>
        /// <param name="oppositeX"> Used to check if target Agent is
        /// on the oposite side of the board, horizontaly. </param>
        /// <param name="oppositeY"> Used to check if target Agent is
        /// on the oposite side of the board, verticaly. </param>
        /// <returns> Directional char. </returns>
        public virtual char
            ClosestChar(Agents a, bool oppositeX, bool oppositeY)
        {
            char dir = ' ';
            bool zombie = !(this is Human && !Infected);

            if (a.X > X && a.Y > Y)
                dir = 'c';
            if (a.X > X && a.Y < Y)
                dir = 'e';
            if (a.X < X && a.Y < Y)
                dir = 'q';
            if (a.X < X && a.Y > Y)
                dir = 'z';
            if (a.X >= X && a.Y == Y)
                dir = 'd';
            if (a.X <= X && a.Y == Y)
                dir = 'a';
            if (a.Y >= Y && a.X == X)
                dir = 's';
            if (a.Y <= Y && a.X == X)
                dir = 'w';

            switch (dir)
            {
                case 'a':
                    if (oppositeX || !zombie)
                        dir = 'd';
                    break;
                case 'd':
                    if (oppositeX || !zombie)
                        dir = 'a';
                    break;
                case 'w':
                    if (oppositeY || !zombie)
                        dir = 's';
                    break;
                case 's':
                    if (oppositeY || !zombie)
                        dir = 'w';
                    break;
                case 'q':
                    if (oppositeX && oppositeY || !zombie)
                        dir = 'c';
                    else if (oppositeX)
                        dir = 'e';
                    else if (oppositeY)
                        dir = 'z';
                    break;
                case 'e':
                    if (oppositeX && oppositeY || !zombie)
                        dir = 'z';
                    else if (oppositeX)
                        dir = 'q';
                    else if (oppositeY)
                        dir = 'c';
                    break;
                case 'z':
                    if (oppositeX && oppositeY || !zombie)
                        dir = 'e';
                    else if (oppositeX)
                        dir = 'c';
                    else if (oppositeY)
                        dir = 'q';
                    break;
                case 'c':
                    if (oppositeX && oppositeY || !zombie)
                        dir = 'q';
                    else if (oppositeX)
                        dir = 'z';
                    else if (oppositeY)
                        dir = 'e';
                    break;
            }
            return dir;
        }
    }
}
