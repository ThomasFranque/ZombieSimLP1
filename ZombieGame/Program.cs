﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ZombieGame
{
    class Program
    {
        // Declare class variables
        private List<Agents> agents;
        private GameSettings setts;

        private Program(string[] args)
        {
            // Instanciate classes
            agents = new List<Agents>();
            setts = new GameSettings(args);

            // Save the settings
            FileManager.Save(setts.GetAllVars());
        }

        private static void Main(string[] args)
        {

            Program prgm = new Program(args);
            prgm.Start();


            // Load settings
            //setts = FileManager.LoadSetts();






            //map.ShowMap(setts.x, setts.y, setts.h, setts.z, setts.H, setts.Z);
            // map.FillMap(agents, map.Board);
            //map.ShowMap();



            //Console.WriteLine($"\nMap Lenght   x: {setts.x}");
            //Console.WriteLine($"Map Height   y: {setts.y}");

            //Console.WriteLine($"Zombies      z: {setts.z}");
            //Console.WriteLine($"Humans       h: {setts.h}");

            //Console.WriteLine($"Your zombies Z: {setts.Z}");
            //Console.WriteLine($"Your humans  H: {setts.H}");



            //Console.BackgroundColor = ConsoleColor.DarkGreen;

        }

        private void Start()
        {
            //  Declare block variables
            string option;

            //###############################################
            // Debug ########################################
            //###############################################
            // Add AI h
            for (int i = 0; i < setts.H; i++)
            {
                agents.Add(new Human(true));

            }

            // Add player controled h
            for (int i = 0; i < setts.h; i++)
            {
                agents.Add(new Human(false));

            }

            // Add AI z
            for (int i = 0; i < setts.Z; i++)
            {
                agents.Add(new Zombie(true));

            }

            // Add player controled z
            for (int i = 0; i < setts.z; i++)
            {
                agents.Add(new Zombie(false));

            }


            int k = 0;  // Used for debugging list count
            foreach (Agents a in agents)
            {
                Console.WriteLine($"{a.ToString()}; Count:{k}");
                k++;
            }

            Console.WriteLine("List count:" + agents.Count);
            Console.WriteLine("Map size:" + setts.x * setts.y);
            Console.WriteLine();

            //###############################################
            // Debug ########################################
            //###############################################


            // Ensure console doesn't get cluttered up
            //Console.Clear();

            PrintMap();
            FillBoard(setts, agents);

            

            //do
            //{
            //    // Render options or print them right here?

            //    option = Console.ReadLine();

            //    switch(option)
            //    {
            //        case "1":
            //            // Insert option
            //            break;

            //        case "2":
            //            // Insert option
            //            break;

            //        case "3":
            //            // Insert option
            //            break;

            //        case "4":
            //            break;

            //        default:
            //            Console.WriteLine("Invalid");
            //            break;
            //    }

            //} while (option != "4");
        }

        private void FillBoard(GameSettings setts, List<Agents> agents)
        {
            Render.PlaceAgents(setts.y, agents);
        }

        private void PrintMap()
        {
            Console.ResetColor();
            Render.PrintBoard(setts.x, setts.y);
            // Nice
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\t When i'm big, I want to be a game! \n" +
    "\t - Said small program.cs \n\n");
            Console.ResetColor();
        }
    }
}
