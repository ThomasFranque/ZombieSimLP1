using System;
using System.Collections.Generic;
using System.Threading;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Agents> agents = new List<Agents>();
            Map map = new Map();
            GameSettings setts = new GameSettings(args);

            //###############################################
            // Debug ########################################
            //###############################################
            Random r = new Random();
            int[] testAgentsForMap = new int[setts.x + setts.h];

            // Add AI h
            for (int i = 0;  i < setts.h - setts.H; i++)
                testAgentsForMap[i] = r.Next(1, setts.x * setts.y);

            // Add player controled h
            for (int i = setts.h - setts.H; i < setts.h; i++)
                testAgentsForMap[i] = r.Next(1, setts.x * setts.y);

            // Add AI z
            for (int i = setts.h; i < setts.z - setts.Z; i++)
                testAgentsForMap[i] = r.Next(1, setts.x * setts.y);

            // Add player controled z
            for (int i = setts.z - setts.Z; i < setts.z; i++)
                testAgentsForMap[i] = r.Next(1, setts.x * setts.y);
            //###############################################
            // Debug ########################################
            //###############################################

            map.ShowMap(setts.x, setts.y, setts.h, setts.z, setts.H, setts.Z);
            Console.ResetColor();

            Console.WriteLine($"\nMap Lenght   x: {map.x}");
            Console.WriteLine($"Map Height   y: {map.y}");

            Console.WriteLine($"Zombies      z: {map.z}");
            Console.WriteLine($"Humans       h: {map.h}");

            Console.WriteLine($"Your zombies Z: {map.Z}");
            Console.WriteLine($"Your humans  H: {map.H}");


            // Nice
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n\t When i'm big, I want to be a game! \n" +
                "\t - Said small program.cs \n\n");
            Console.ResetColor();
        }
    }
}
