using System;
using System.Text;
using System.Collections.Generic;

namespace ZombieGame
{
    class MapCreator
    {
        CharEnum symbol;

        public MapCreator()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }


        public void SelectChar(List<Agents> agents)
        {
            foreach (Agents agent in agents)
                if (agent is Human)
                    if(agent.Ai)
                    Console.Write(CharEnum.Human);
        }
    }
}
