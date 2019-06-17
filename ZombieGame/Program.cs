using System;
using System.Collections.Generic;
using System.Threading;

namespace ZombieGame
{
    class Program
    {
        // Declare class variables
        private List<Agents> agents;
        private GameSettings setts;
        private int turns;

        private Program(string[] args)
        {
            // This temporary line is used for debugging
            // Test load files by changing file name
            args = new string[] { "-s", "TestSave.sav" };

            // Instanciate classes;
            if (args.Length > 0)
                if(args[0].ToCharArray().Length > 0)
                    if (args[0][1] == 's')
                        FileManager.Load(args, out setts, out agents);

            if (setts == null)
                setts = new GameSettings(args);
        }

        private static void Main(string[] args)
        {
            Program prgm = new Program(args);
            prgm.Loop();
        }

        private void Loop()
        {
            //  Declare block variables
            string option;

            // Inicialize turn counter
            turns = 0;

            // Create agents to store in a list
            if (agents == null)
                CreateAgents();

            // Ensure console doesn't get cluttered up
            Console.Clear();

            // Plays a simple tune
            Songs.TuneHappy();

            // show map
            PrintMap();
            // by filling
            foreach (Agents agent in agents)
            {
                FillBoard(setts.y, agents, new int[2] { agent.X, agent.Y });
            }

            // Show initial screen
            Render.IntroScreen();

            do
            {
                turns++;
                // Get user choice
                option = Console.ReadLine();

                //Console.WriteLine(!agents.Exists(x => x.Infected == false));

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Render.MenuOp();
                        break;

                    case "2":
                        Console.Clear();
                        foreach (Agents agent in agents)
                        {
                            PrintMap();
                            FillBoard(setts.y, agents, new int[2]
                            { agent.X, agent.Y });
                            Console.WriteLine($"X: {agent.X}\nY: {agent.Y}");
                            //Console.WriteLine(agent.GetType());
                            Console.WriteLine($"turn number: {turns}");


                            // //* -----DEBUG-----
                            //foreach (Agents agent1 in agents)
                            //    Console.WriteLine(agent1);


                            // If agent is Ai controlled...
                            if (agent.Ai)
                            {
                                Console.WriteLine(agent);
                                agent.Move(agent, setts.BoardSize, agents);
                                
                                Thread.Sleep(1200);

                            }

                            // ... or if is player controlled
                            else
                            {
                                char dir;
                                do
                                {
                                    // Asks for input, converts input  
                                    Render.AskInput();

                                    // Store input
                                    // Convert to lowercase
                                    // and convert to char
                                    dir = Convert.ToChar
                                        (Console.ReadLine().ToLower()[0]);

                                } while (dir != 'a' && dir != 'w' && dir != 's'
                                &&
                                dir != 'd' && dir != 'q' && dir != 'e' &&
                                    dir != 'z' && dir != 'c');

                                agent.Move
                                    (agent, setts.BoardSize, agents, dir);
                            }

                            // Check if there aren't any agent...
                            //... with bool infected as false
                            if (!agents.Exists(x => x.Infected == false))
                                break;
                        }
                        // Show last agent movement
                        PrintMap();
                        // fill
                        foreach (Agents agent in agents)
                        {
                            FillBoard(setts.y, agents, new int[2]
                            { agent.X, agent.Y });
                        }

                        Render.IntroScreen();
                        break;

                    case "3":
                        // Insert option
                        FileManager.Save(setts.GetAllVars(), agents);
                        Render.IntroScreen();
                        break;

                    default:
                        Console.WriteLine("Invalid");
                        break;
                }

                // Shuffle list
                agents = ShuffleAgentsList(agents);

                if (!agents.Exists(x => x.Infected == false))
                {
                    turns = setts.T;
                }

                // Continue loop while user doesn't select option 4...
                //...or turns played is less than max turns or...
                //... still exists agents that are not infected
            } while (turns > setts.T);
            Render.AllHumansDead();
        }

        private void FillBoard(int y, List<Agents> agents, int[] targetUnit)
        {
            Render.PlaceAgents(y, agents, targetUnit);
        }

        private void PrintMap()
        {
            Console.ResetColor();
            Render.PrintBoard(setts.x, setts.y);
            // Nice
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("\n\n\t When i'm big, I want to be a game! \n" +
            //"\t - Said small program.cs \n\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Sets faction to agents and ai
        /// </summary>
        /// <param name="zombie"> </param>
        /// <param name="ai"> </param>
        /// <returns></returns>
        private Agents NewAgent(bool zombie, bool ai)
        {
            Agents tempA;
            if (zombie)
            {
                tempA = new Zombie(ai, setts.x, setts.y);
                while (agents.Contains(tempA))
                    tempA = new Zombie(ai, setts.x, setts.y);
            }
            else
            {
                tempA = new Human(ai, setts.x, setts.y);
                while (agents.Contains(tempA))
                    tempA = new Human(ai, setts.x, setts.y);
            }
            return tempA;
        }

        /// <summary>
        /// Adds agents in list
        /// </summary>
        private void CreateAgents()
        {
            agents = new List<Agents>();
            // Add AI h
            for (int i = 0; i < setts.H; i++)
            {
                agents.Add(NewAgent(false, true));
            }

            // Add player controled h
            for (int i = 0; i < setts.h; i++)
            {
                agents.Add(NewAgent(false, true));
                //agents.Add(NewAgent(false, false));
            }

            // Add AI z
            for (int i = 0; i < setts.Z; i++)
            {
                agents.Add(NewAgent(true, true));
            }

            // Add player controled z
            for (int i = 0; i < setts.z; i++)
            {
                agents.Add(NewAgent(true, true));
                //agents.Add(NewAgent(true, false));
            }

            // Shuffle list
            agents = ShuffleAgentsList(agents);

            // Show results
            Console.WriteLine("List count:" + agents.Count);
            Console.WriteLine("Map size:" + setts.x * setts.y);
            Console.WriteLine();
        }

        public List<Agents> ShuffleAgentsList(List<Agents> lst)
        {
            Random r = new Random();
            for (int size = lst.Count; size > 1; size--)
            {
                int randN = r.Next(0, size);

                Agents val = lst[randN];
                lst[randN] = lst[size - 1];
                lst[size - 1] = val;
            }
            return lst;
        }
    }
}
