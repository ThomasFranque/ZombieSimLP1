using System;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            GameSettings setts = new GameSettings(args);

            map.ShowMap(setts.x, setts.y, setts.h, setts.z, setts.H, setts.Z);
            Console.ResetColor();

            Console.WriteLine($"\nMap Lenght   x: {map.X}");
            Console.WriteLine($"Map Height   y: {map.Y}");

            Console.WriteLine($"Zombies      z: {map.Z}");
            Console.WriteLine($"Humans       h: {map.H}");

            Console.WriteLine($"Your zombies Z: {map.PZ}");
            Console.WriteLine($"Your humans  H: {map.PH}");


            // Nice
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n\t When i'm big, I want to be a game! \n" +
                "\t - Said small program.cs \n\n");
            Console.ResetColor();

        }
    }
}
