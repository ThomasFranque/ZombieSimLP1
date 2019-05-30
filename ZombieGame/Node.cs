using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    abstract class Node
    {
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
        public abstract char PrintPart(bool ai);
    }
}
