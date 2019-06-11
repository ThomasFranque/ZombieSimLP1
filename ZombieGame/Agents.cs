using System;
using System.Collections.Generic;

namespace ZombieGame
{
    // All derived class' contain these methods!
    abstract class Agents : IEquatable<Agents>, IComparable<Agents>
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
        public Agents(bool ai, int sizeX, int sizeY)
        {
            Random r = new Random();
            // Default position is x = 1 and y = 1
            // Random is set for debugging
            X = r.Next(1, sizeX + 1);
            Y = r.Next(1, sizeY + 1);

            Ai = ai;
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
        public void Move(Agents j, int[] size, List<Agents> agents, char dir)
        {
            //// Goes through list and verifies if exist an agent with said coordinates
            switch (dir)
            {
                // Up
                case 'w':
                    if (Y <= 1)
                    {
                        // Lock agent j up movement, other side of map is occupied
                        if (Occupied(new int[] { X, size[1] }, agents))
                        {
                            Render.PressKey("North position is occupied");
                        }
                        // Goes around map (max size, Y)
                        else
                        {
                            Y = size[1];
                        }
                    }
                    else
                    {
                        // Lock agent j up movement, up position is occupied
                        if (Occupied(new int[] { X, Y - offSett }, agents))
                        {
                            Render.PressKey("North position is occupied");
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
                        // Lock agent j left movement, other side of map is occupied
                        if (Occupied(new int[] { size[0], Y }, agents))
                        {
                            Render.PressKey("West position is occupied");
                        }
                        // Goes arround map, (max size X)
                        else
                        {
                            X = size[0];
                        }
                    }
                    else
                    {
                        // Lock agent j left movement, position occupied
                        if (Occupied(new int[] { X - offSett, Y }, agents))
                        {
                            Render.PressKey("West position is occupied");
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
                        // Lock agent j right movement, other side of map is occupied
                        if (Occupied(new int[] { offSett, Y }, agents))
                        {
                            Render.PressKey("East position is occupied");
                        }
                        // Goes around map, right (min x)
                        else
                        {
                            X = 1;
                        }
                    }
                    else
                    {
                        // Lock agent j right movement, occupied pos
                        if (Occupied(new int[] { X + offSett, Y }, agents))
                        {
                            Render.PressKey("East position is occupied");
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
                        // Lock agent j down movement, other side occupied
                        if (Occupied(new int[] { X, offSett }, agents))
                        {
                            Render.PressKey("South position is occupied");
                        }
                        // Goes around map (min y)
                        else
                        {
                            Y = 1;
                        }
                    }
                    else
                    {
                        // Lock agent j down movement, up side is occupied
                        if (Occupied(new int[] { X, Y + offSett }, agents))
                        {
                            Render.PressKey("South position is occupied");
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
                        // Lock agent j up left movement, other corner is occupied
                        if (Occupied(new int[] { size[0], size[1] }, agents))
                        {
                            Render.PressKey("Northwest position is occupied");
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
                        // Lock agent j up movement, other side is occupied
                        if (Occupied(new int[] { X - offSett, size[1] }, agents))
                        {
                            Render.PressKey("Northwest position is occupied");
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
                        // Lock agent j left movement
                        if (Occupied(new int[] { size[0], Y - offSett }, agents))
                        {
                            Render.PressKey("Northwest position is occupied");
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
                        if (Occupied(new int[] { X - offSett, Y - offSett }, agents))
                        {
                            Render.PressKey("Northwest position is occupied");
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
                        // Lock agent j up right movement, occupied pos
                        if (Occupied(new int[] { offSett, size[1] }, agents))
                        {
                            Render.PressKey("Northeast position is occupied");
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
                        // Lock agent j up movement, pos occupied in other side
                        if (Occupied(new int[] { X + offSett, size[1] }, agents))
                        {
                            Render.PressKey("Northeast position is occupied");
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
                        if (Occupied(new int[] { offSett, Y - offSett }, agents))
                        {
                            Render.PressKey("Northeast position is occupied");
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
                        if (Occupied(new int[] { X + offSett, Y - offSett }, agents))
                        {
                            Render.PressKey("Northeast position is occupied");
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
                        // Lock agent j down left movement, occupied position in opposite corner
                        if (Occupied(new int[] { size[0], offSett }, agents))
                        {
                            Render.PressKey("Southwest position is occupied");
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
                        if (Occupied(new int[] { X - offSett, offSett }, agents))
                        {
                            Render.PressKey("Southwest position is occupied");
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
                        if (Occupied(new int[] { size[0], Y + offSett }, agents))
                        {
                            Render.PressKey("Southwest position is occupied");
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
                        if (Occupied(new int[] { X - offSett, Y + offSett }, agents))
                        {
                            Render.PressKey("Southwest position is occupied");
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
                        if (Occupied(new int[] { offSett, offSett }, agents))
                        {
                            Render.PressKey("Southeast position is occupied");
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
                        if (Occupied(new int[] { X + offSett, offSett }, agents))
                        {
                            Render.PressKey("Southeast position is occupied");
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
                        if (Occupied(new int[] { offSett, Y + offSett }, agents))
                        {
                            Render.PressKey("Southeast position is occupied");
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
                        if (Occupied(new int[] { X + offSett, Y + offSett }, agents))
                        {
                            Render.PressKey("Southeast position is occupied");
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
        /// <param name="j"></param>
        /// <param name="size"></param>
        /// <param name="agents"></param>
        public void Move(Agents j, int[] size, List<Agents> agents)
        {
            // Variables
            string options = "wasdqezc";
            Random rnd = new Random();
            char dir = options[rnd.Next(8)];

            Move(j, size, agents, dir);
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

        // Check for distance for closest target
        public int CompareTo(Agents other)
        {
            throw new NotImplementedException();
        }

    }
}
