using System;

namespace ZombieGame
{
    static class Render
    {
        /// <summary>
        /// Asks for input, agents' movement
        /// </summary>
        public static void AskInput()
        {
            Console.WriteLine("Choose where you want to move your agents...");
        }

        /// <summary>
        /// Shows options if pressed M
        /// </summary>
        public static void MenuOp()
        {
            Console.WriteLine("Press 'I' for instructions");
            Console.WriteLine("Press 'Q' to Quit simulation");
        }

        /// <summary>
        /// Instructions, Movement
        /// </summary>
        public static void InstMove()
        {
            Console.WriteLine("To move use the following keys:");
            Console.WriteLine("Q - Up Left");
            Console.WriteLine("w - Up");
            Console.WriteLine("E - Up Right");
            Console.WriteLine("A - Left");
            Console.WriteLine("S - Down");
            Console.WriteLine("D - Right");
            Console.WriteLine("Z - Down Left");
            Console.WriteLine("C - Down Right");
        }
    }
}
