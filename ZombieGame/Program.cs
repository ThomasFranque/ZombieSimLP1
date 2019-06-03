using System;
using System.Collections.Generic;
using System.Threading;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables
            GameSettings setts = new GameSettings(args);
            List<Agents> agents = new List<Agents>();
            TestMap map = new TestMap(setts.x, setts.y);

            // Save the settings
            FileManager.Save(setts.GetAllVars());
            // Load settings
            //setts = FileManager.LoadSetts();

            //###############################################
            // Debug ########################################
            //###############################################
            // Add AI h
            for (int i = 0; i < setts.H; i++)
                agents.Add(new Human(true));

            // Add player controled h
            for (int i = 0; i < setts.h; i++)
                agents.Add(new Human(false));

            // Add AI z
            for (int i = 0; i < setts.Z; i++)
                agents.Add(new Zombie(true));

            // Add player controled z
            for (int i = 0; i < setts.z; i++)
                agents.Add(new Zombie(false));

            int k = 0;
            foreach (Node a in agents)
            {
                Console.WriteLine($"{a.ToString()}; Count:{k}");
                k++;
            }

            Console.WriteLine("List count:" + agents.Count);
            Console.WriteLine("Map size:" + map.Board.Length);
            Console.WriteLine();

            //###############################################
            // Debug ########################################
            //###############################################

            Render.PrintBoard(setts.x, setts.y);
            Render.PlaceAgents(setts.y, agents);

            //map.ShowMap(setts.x, setts.y, setts.h, setts.z, setts.H, setts.Z);
            // map.FillMap(agents, map.Board);
            //map.ShowMap();

            Console.ResetColor();

            Console.WriteLine($"\nMap Lenght   x: {map.BoardX}");
            Console.WriteLine($"Map Height   y: {map.BoardY}");

            Console.WriteLine($"Zombies      z: {setts.z}");
            Console.WriteLine($"Humans       h: {setts.h}");

            Console.WriteLine($"Your zombies Z: {setts.Z}");
            Console.WriteLine($"Your humans  H: {setts.H}");


            // Nice
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n\t When i'm big, I want to be a game! \n" +
                "\t - Said small program.cs \n\n");
            Console.ResetColor();
        }
    }
}
