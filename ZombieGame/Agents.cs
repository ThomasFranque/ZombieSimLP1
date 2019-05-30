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
                        MovePlayer(k);
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
        /// Move agent to desired position
        /// </summary>
        /// <param name="j"></param>
        public virtual void MovePlayer(Node j)
        {
            char dir;
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

        /// <summary>
        /// Returns Agent to string, 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Ai: {Ai}; Agent: ";
    }
}
