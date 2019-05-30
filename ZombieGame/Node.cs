using System;
using System.Text;

namespace ZombieGame
{
    abstract class Node
    {
        // Property
        public bool Ai { get; }

        // Constructor to get AI value
        public Node(bool AiUnit)
        {
            Ai = AiUnit;
        }


        /// <summary>
        /// Defines text output encoding
        /// </summary>
        public virtual void MapCreator()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Prints the correct symbol for the agents
        /// </summary>
        /// <param name="infected"></param>
        /// <returns></returns>
        public abstract char PrintPart();
    }
}
