using System;
using System.Collections.Generic;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Agents> agents = new List<Agents>();
            Map map = new Map();
            GameSettings setts = new GameSettings(args);

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
