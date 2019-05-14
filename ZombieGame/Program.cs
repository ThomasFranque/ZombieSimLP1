using System;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSettings settings = new GameSettings(args);

            byte x;
            byte y;
            byte z;
            byte h;
            byte zp;
            byte hp;
            byte maxTurns;

            // If user try's to start within the program the
            // Code will still run
            try
            {
                // Convert entered values to be used
                x = Convert.ToByte(args[0]);
                y = Convert.ToByte(args[1]);
                z = Convert.ToByte(args[2]);
                h = Convert.ToByte(args[3]);
                zp = Convert.ToByte(args[4]);
                hp = Convert.ToByte(args[5]);
                maxTurns = Convert.ToByte(args[6]);

                /* Known problems: User can't choose
                Wich variable to type in first
                order is defined automatically.
                When back will create method for 
                new values in render and agents' classes
                */
            }
            catch
            {

            }

            // Nice
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t When i'm big, I want to be a game! \n" +
                "\t - Said small program.cs ");
            Console.ResetColor();
        }
    }
}
