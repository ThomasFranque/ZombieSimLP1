using System;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();    

            // If user try's to start within the program the
            // Code will still run
            try
            {
                GameSettings sets = new GameSettings(args);
                map.ShowMap(sets.x, sets.y, sets.h, sets.z, sets.H, sets.Z);

            }
            // Case program isn't run through the console
            catch
            {
                GameSettings defSets = new GameSettings(25, 25, 10, 5, 0, 0, 20);
                map.ShowMap
                    (defSets.x, defSets.y, defSets.z, defSets.h, defSets.H, defSets.Z);

                Console.WriteLine($"{map.PH}");
            }

            // Nice
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t When i'm big, I want to be a game! \n" +
                "\t - Said small program.cs ");
            Console.ResetColor();

            Console.WriteLine($"{map.PH}");
        }
    }
}
