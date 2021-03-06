﻿using System;

namespace ZombieGame
{
    /// <summary>
    /// Contains all the game settings, such as how many player controlled
    /// units and total turns.
    /// </summary>
    class GameSettings
    {
        /* Argument example
        * dotnet run -- -x 20 -y 20 -z 10 -h 30 -Z 1 -H 2 -t 1000
        */

        /// <summary>
        /// Get and set map size horizontaly
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// Get and set map size verticaly
        /// </summary>
        public int y { get; set; }

        /// <summary>
        /// Get and set number of AI controlled zombies
        /// </summary>
        public int z { get; set; }

        /// <summary>
        /// Get and set number of AI controlled humans
        /// </summary>
        public int h { get; set; }

        /// <summary>
        /// Get and set number of playable zombies
        /// </summary>
        public int Z { get; set; }

        /// <summary>
        /// Get and set number of playable humans
        /// </summary>
        public int H { get; set; }

        /// <summary>
        ///  Get and set max game turns
        /// </summary>
        public int t { get; set; }

        /// <summary>
        ///  Get and set current game turns
        /// </summary>
        public int T { get; set; }

        /// <summary>
        /// Get the board size
        /// </summary>
        public int[] BoardSize { get; }


        /// <summary>
        /// Constructor will initialize the game variables from console args
        /// </summary>
        public GameSettings(string[] args)
        {
            // Run through all the given arguments
            for (byte i = 0; i < args.Length; i++)
            {
                // Check every letter for numbers
                foreach (char letter in args[i])
                {
                    switch (letter)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':   
                            AssignValue(args[i - 1], args[i]);
                            break;

                        default:
                            break;
                    }
                }
            }

            // Check the arguments for mistakes
            CheckArgs();

            // Success message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSuccessfully initialized game settings...");
            Console.WriteLine($"| Agents: {z + h + Z + H}\n" +
                $"| Playing Area: {x * y}\n");
            Console.ResetColor();

            // Assign board size
            BoardSize = new int[2] { x, y };
        }

        /// <summary>
        /// Will assign the correspondent variables using the given arguments
        /// </summary>
        /// <param name="idArg">The identifier letter ( x, h, y etc.. )</param>
        /// <param name="numArg">The number</param>
        private void AssignValue(string idArg, string numArg)
        {
            // Will check for the target number ID
            switch (idArg[1])
            {
                // Board lengh
                case 'x':
                    x = Convert.ToInt32(numArg);
                    break;

                // Board Height
                case 'y':
                    y = Convert.ToInt32(numArg);
                    break;

                // player zombies
                case 'z':
                    z = Convert.ToInt32(numArg);
                    break;

                // player humans
                case 'h':
                    h = Convert.ToInt32(numArg);
                    break;

                // AI zombies
                case 'Z':
                    Z = Convert.ToInt32(numArg);
                    break;

                // AI humans
                case 'H':
                    H = Convert.ToInt32(numArg);
                    break;

                // total turns
                case 't':
                    t = Convert.ToInt32(numArg);
                    break;

                // current turns
                case 'T':
                    T = Convert.ToInt32(numArg);
                    break;
            }

            T = 0;
        }

        /// <summary>
        /// Will check if any of the arguments was not given and set it 
        /// to a "random" number and if the zombies / humans fit 
        /// </summary>
        private void CheckArgs()
        {
            // Temporary method variables
            Random rand = new Random();
            int[] args = new int[7] { x, y, h, z, Z, H, t };
            int[] randArgs = new int[7];

            Console.ForegroundColor = ConsoleColor.Red;

            // Check for ungiven values
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == 0)
                    switch (i)
                    {
                        // x
                        case 0:
                            x = rand.Next(8, 16);
                            randArgs[0] = x;
                            RandomNumMsg('x', x);
                            break;
                        // y
                        case 1:
                            y = rand.Next(8, 16);
                            randArgs[1] = y;
                            RandomNumMsg('y', y);
                            break;
                        // h
                        case 2:
                            h = (x * y) / 6;
                            randArgs[2] = h;
                            RandomNumMsg('h', h);
                            break;
                        // z
                        case 3:
                            z = (x * y) / 7;
                            randArgs[3] = z;
                            RandomNumMsg('z', z);
                            break;
                        // Z
                        case 4:
                            Z = rand.Next(0, z / 2);
                            randArgs[4] = Z;
                            RandomNumMsg('Z', Z);
                            break;
                        // H
                        case 5:
                            H = rand.Next(0, h / 2);
                            randArgs[5] = H;
                            RandomNumMsg('H', H);
                            break;
                        // t
                        case 6:
                            t = rand.Next(8, x * y);
                            randArgs[6] = t;
                            RandomNumMsg('t', t);
                            break;
                    }
            }
            Console.ResetColor();

            // Check if the board is valid
            while (x * y <= z + h || BoardWarning())
            {
                // Ask if player wants to continue with the oversized board
                Console.WriteLine($"\nUps...\nTotal Agents: {z + h + Z + H}\n" 
                    + $"Board Area: {x * y}");
                Console.WriteLine("It seems that what you are trying to " +
                    "do surpasses the board capabilities.\n");

                InvalidArgs(rand);
            }

            // Warn the player if any of the values was set to random
        }

        /// <summary>
        /// Used if the given arguments are invalid
        /// </summary>
        /// <param name="rand">Random object previously created</param>
        private void InvalidArgs(Random rand)
        {
            // Var
            char decision;

            // Message
            Console.Write("Do you wish to generate a new board or " +
             "generate new agents?\n" +
             "Generate New Board ......... <b>\n" +
             "Generate New Agents ........ <a>\n>");

            // Get input
            decision = PlayerInput();

            // While not a valid input
            while (decision != 'B' && decision != 'A')
            {
                Console.Write("Sorry, not a valid input.\n>");
                decision = PlayerInput();
            }

            // If player chooses to change the board
            if (decision == 'B')
            {
                // Set board x and y using agents
                do
                {
                    // Prevent min and max random exeption
                    try
                    {
                        x = rand.Next(h / 2, z / 2);
                        y = rand.Next(h / 2, z / 2);
                    }
                    catch
                    {
                        x = rand.Next(z / 2, h / 2);
                        y = rand.Next(z / 2, h / 2);
                    }
                } while (x * y <= z + h);
            }
            // Player wants to generate new agents
            else
            {
                // Setting total
                h = (x * y) / 3;
                z = (x * y) / 4;

                // Setting controlled
                Z = rand.Next(0, z / 2);
                H = rand.Next(0, h / 2);
            }
        }

        /// <summary>
        /// Will let the player know that the board is big
        /// </summary>
        /// <returns>True if the player doesn't want to proceed</returns>
        private bool BoardWarning()
        {
            bool restart = false;
            if (x * y >= 600 || x * y <= 6)
            {
                char decision;

                // Message
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("\nWARNING!\n" +
                    $"The board has {x * y} cells!\n" +
                    "Do you wish to proceed?\n| <y> or <n> |\n>");

                decision = PlayerInput();
                Console.ResetColor();

                if (decision == 'N')
                {
                    restart = true;
                }
            }

            return restart;
        }

        /// <summary>
        /// Gets the player intention
        /// </summary>
        /// <returns>A char representing the first Upercase letter of 
        /// the player input</returns>
        private char PlayerInput()
        {
            return Convert.ToChar(Console.ReadLine().ToUpper()[0]);
        }

        /// <summary>
        /// Will warn the player of a variable was set to random
        /// </summary>
        /// <param name="valN">Name of the variable</param>
        /// <param name="val">Variable number</param>
        private void RandomNumMsg(char valN, int val)
        {
            Console.WriteLine($"\nRandom Warning!\n" +
                $"Not given argument {valN} was set to {val}\n");
        }

        /// <summary>
        /// Used to get all of the game settings variables
        /// </summary>
        /// <returns>An array with all the variables</returns>
        public int[] GetAllVars() => new int[8] { x, y, h, z, Z, H, t, T };
    }
}
