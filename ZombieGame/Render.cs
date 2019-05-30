using System;
using System.Threading;

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
            // Plays a simple tune
            Console.Beep();

            // Variable, saves user's input
            char choice;

            Console.WriteLine("Press 'R' to return to simulation");
            Console.WriteLine("Press 'I' for instructions");
            Console.WriteLine("Press 'Q' to Quit simulation");
            Console.WriteLine("Press 'S' to Save and Quit simulation");
            choice = Convert.ToChar(Console.ReadLine());

            switch (choice)
            {
                case 'r':
                    // Back to gameloop
                    break;

                // Shows instructions
                case 'i':
                    InstMove();
                    break;

                // Quits program
                case 'q':
                    Environment.Exit(0);
                    break;

                // Saves and Quits
                case 's':
                    // Saves
                    Environment.Exit(0);
                    break;

                // Case user types an unkwon option goes back to game
                default:
                    Console.WriteLine
                        ("Invalid choice, sending you back to the simulation");
                    break;
            }
        }

        /// <summary>
        /// Instructions, Movement
        /// </summary>
        public static void InstMove()
        {
            // Shows user how to move
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

        /// <summary>
        /// When all humans die shows message and quits program
        /// </summary>
        public static void AllHumansDead()
        {
            Console.WriteLine("All humans have died...");
            // Saves stats
            Thread.Sleep(10000);
        }
    }
}
