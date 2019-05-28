using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Agents : Map
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
        public int AgentsInB
        {
            get => AgentsInB;
            set
            {
                AgentsInB = Z + H + PH + PZ; 
            }
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Agents ()
        {
            AgentsInB = Z + H + PH + PZ;
        }

        /// <summary>
        /// Agents move, Calls CheckAgents
        /// </summary>
        protected void MovePlayer()
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
            }

        }

        // Move to checker
        protected void CheckAgents()
        {
            while (AgentsInB > 0)
            {

            }
        }
    }
}
