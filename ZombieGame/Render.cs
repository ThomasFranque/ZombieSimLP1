﻿using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace ZombieGame
{
    static class Render
    {
        /// <summary>
        /// Asks for input, agents movement.
        /// </summary>
        public static void AskInput()
        {
            WriteLine("Choose where you want to move your agents...");
        }

        /// <summary>
        /// Shows options if M is pressed.
        /// </summary>
        public static void MenuOp()
        {
            // Variable, saves user's input
            char choice;

            WriteLine("Press 'R' to return to simulation");
            WriteLine("Press 'I' for instructions");
            WriteLine("Press 'Q' to Quit simulation");
            WriteLine("Press 'S' to Save and Quit simulation");

            choice = Convert.ToChar(ReadLine());

            switch (choice)
            {
                case 'r':
                    Clear();
                    IntroScreen();
                    break;

                // Shows instructions
                case 'i':
                    Clear();
                    InstMove();
                    ReadKey(true);
                    IntroScreen();
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
                    WriteLine
                        ("Invalid choice, sending you back to the simulation");
                    WriteLine();
                    IntroScreen();
                    break;
            }
        }

        /// <summary>
        /// Instructions, Movement.
        /// </summary>
        public static void InstMove()
        {
            // Shows user how to move
            WriteLine("To move use the following keys:");
            WriteLine("Q - Up Left");
            WriteLine("w - Up");
            WriteLine("E - Up Right");
            WriteLine("A - Left");
            WriteLine("S - Down");
            WriteLine("D - Right");
            WriteLine("Z - Down Left");
            WriteLine("C - Down Right");
            WriteLine("Press any key to continue...");
        }

        /// <summary>
        /// When all humans die shows message and quits program.
        /// </summary>
        public static void AllHumansDead()
        {
            // Plays death tune
            Songs.TuneDeath();

            WriteLine("All humans have died...");

            Thread.Sleep(10000);
        }

        /// <summary>
        /// Print the board in ASCII.
        /// </summary>
        /// <param name="length"> Board X size. </param>
        /// <param name="height"> Board Y size. </param>
        public static void PrintBoard(int length, int height)
        {
            Clear();
            // For cicle to print map
            for (int k = 0; k < length * 4 + 1; k++)
                Write("-");

            // New line
            WriteLine();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                    Write("|   ");

                WriteLine('|');

                for (int k = 0; k < length * 4 + 1; k++)
                    Write("-");

                WriteLine();
            }
        }

        /// <summary>
        /// Will write the agents on the console.
        /// </summary>
        /// <param name="boardHeight"> Height of the board. </param>
        /// <param name="agents"> List of agents to be placed. </param>
        /// <param name="targetUnit"> Specific Agent position. </param>
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
                        unitColor = ConsoleColor.Green;
                        break;
                    case "Z":
                        unitColor = ConsoleColor.Yellow;
                        break;
                    case "h":
                        unitColor = ConsoleColor.Cyan;
                        break;
                    case "H":
                        unitColor = ConsoleColor.Blue;
                        break;
                }
                ForegroundColor = unitColor;

                if (agent.X == targetUnit[0] && agent.Y == targetUnit[1])
                    BackgroundColor = ConsoleColor.DarkGray;

                SetCursorPosition(normalizedPos[0], normalizedPos[1]);

                WriteLine(identifier);
                ResetColor();

            }
            SetCursorPosition(0, boardHeight * 2 + 1);
        }

        /// <summary>
        /// Normalizes the agent X and Y for the console coordinates.
        /// </summary>
        /// <param name="x"> Agent's X position. </param>
        /// <param name="y"> Agent's Y position. </param>
        /// <returns>Normalized Coordinates</returns>
        private static int[] NormalizePosition(int x, int y) =>
            new int[2] { x * 4 - 2, y * 2 - 1 };

        /// <summary>
        /// Asks the user for a key before the program proceeds.
        /// </summary>
        public static void PressKey()
        {
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        /// <summary>
        /// Overload of PressKey() to display a message.
        /// </summary>
        /// <param name="msg"> Message to display. </param>
        public static void PressKey(string msg)
        {
            WriteLine(msg);
            PressKey();
        }

        /// <summary>
        /// Normalize positions for AI Agents.
        /// </summary>
        /// <param name="x"> AI Agent's X position. </param>
        /// <param name="y"> AI Agent's Y position. </param>
        public static void AI(int x, int y)
        {
            int[] a = NormalizePosition(x, y);
            if (a[0] <= 0)
                a[0] = 1;
            if (a[1] <= 0)
                a[1] = 1;
            SetCursorPosition(a[0], a[1]);
        }

        /// <summary>
        /// Show if Agent is AI controlled.
        /// </summary>
        /// <param name="agent"> Agent to be checked. </param>
        public static void IsAi(Agents agent)
        {
            WriteLine($"Is Agent Ai? --> {agent.Ai}");
        }

        /// <summary>
        /// Display initial menu
        /// </summary>
        public static void IntroScreen()
        {
            WriteLine("Press 1 for simulation menu; \n" +
                "Press 2 for movement; \n" +
                "Press 3 to save the game.\n");
        }
    }
}
