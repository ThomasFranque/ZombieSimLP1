using System;
using System.Collections.Generic;
using System.Threading;

namespace ZombieGame
{
    static class Render
    {
        /// <summary>
        /// Asks for input, agents movement
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
            Songs.TuneHappy();

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
                    Console.ReadKey(true);
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
            // Plays death tune
            Songs.TuneDeath();

            Console.WriteLine("All humans have died...");
            // Saves stats / why?
            Thread.Sleep(10000);
        }

        public static void PrintBoard(int length, int height)
        {
            Console.Clear();
            // For cicle to print map
            for (int k = 0; k < length * 4 + 1; k++)
                Console.Write("-");

            Console.WriteLine();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                    Console.Write("|   ");

                Console.WriteLine('|');

                for (int k = 0; k < length * 4 + 1; k++)
                    Console.Write("-");

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Will write the agents on the console
        /// </summary>
        /// <param name="boardHeight">Height of the board</param>
        /// <param name="agents">List of agents to be placed</param>
        public static void PlaceAgents
            (int boardHeight, IEnumerable<Agents> agents, int[] targetUnit)
        {
            string identifier;
            foreach (Agents agent in agents)
            {
                // Get normalized position
                int[] normalizedPos = NormalizePosition(agent.X, agent.Y);

                // Check if it is a Zombie or human
                identifier = (agent is Zombie || agent.Infected) ? "z" : "h";

                // Check if it is AI controlled
                if (agent.Ai)
                    identifier = identifier.ToUpper();

                // Set the color
                ConsoleColor unitColor = ConsoleColor.White;
                switch (identifier)
                {
                    case "z":
                        unitColor = ConsoleColor.DarkGreen;
                        break;
                    case "Z":
                        unitColor = ConsoleColor.DarkYellow;
                        break;
                    case "h":
                        unitColor = ConsoleColor.DarkCyan;
                        break;
                    case "H":
                        unitColor = ConsoleColor.Blue;
                        break;
                }
                Console.ForegroundColor = unitColor;

                if (agent.X == targetUnit[0] && agent.Y == targetUnit[1])
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                Console.SetCursorPosition(normalizedPos[0], normalizedPos[1]);

                Console.WriteLine(identifier);
                Console.ResetColor();

            }
            Console.SetCursorPosition(0,boardHeight * 2 + 1);
        }

        /// <summary>
        /// Normalizes the agent X and Y for the console coordinates
        /// </summary>
        /// <param name="x">Agent's X</param>
        /// <param name="y">Agent's Y</param>
        /// <returns>Normalized Coordinates</returns>
        private static int[] NormalizePosition(int x, int y) => 
            new int[2] { x * 4 - 2, y * 2 - 1 };
    }
}
