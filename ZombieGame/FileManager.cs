using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    static class FileManager
    {
        // instance variables
        private static string dirPath;
        private static string settsFilePath;

        /// <summary>
        /// Static File manager constructor
        /// </summary>
        static FileManager()
        {
            // Get the location of the AppData dir
            dirPath = Environment.GetFolderPath
                (Environment.SpecialFolder.ApplicationData);

            // Name of the folder
            dirPath += @"\ZombieSimMBT";

            // File name and format
            settsFilePath = dirPath + @"\save.sav";
        }

        /// <summary>
        /// Will save the game settings and current game state
        /// </summary>
        /// <param name="x">size horizontaly</param>
        /// <param name="y">size verticaly</param>
        /// <param name="z">AI controlled zombies</param>
        /// <param name="h">AI controlled humans</param>
        /// <param name="Z">playable zombies</param>
        /// <param name="H">playable humans</param>
        /// <param name="t">max game turns</param>
        /// <param name="T">current game turns</param>
        public static void Save(int[] gameVars, IEnumerable<Agents> agents)
        {
            // Store arguments 
            // int x, int y, int z, int h, int Z, int H, int t, int T

            // If directory does not exist, create it. 
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            Console.Write("Please insert the name of the save file " +
                "(extention included).\n>");
            string saveName = Console.ReadLine();
            settsFilePath = dirPath + @"\" + @saveName;

            // Create settings file if doesnt exist
            if (!File.Exists(settsFilePath))
            {
                // Create a file to write to
                using (FileStream fs = File.Create(settsFilePath))
                {
                    // Write the vars in file
                    for (int i = 0; i < gameVars.Length; i++)
                    {
                        char varName = CheckChar(i);

                        // Add some text to file    
                        byte[] toWrite =
                            new UTF8Encoding(true).GetBytes("-" + varName +
                            " " + gameVars[i] + " ");
                        fs.Write(toWrite , 0, toWrite.Length);
                    }

                    // Write a new line
                    fs.Write
                        (new UTF8Encoding(true).GetBytes(Environment.NewLine));

                    // Write agents
                    foreach (Agents a in agents)
                    {
                        byte[] toWrite = new UTF8Encoding(true).GetBytes(
                            a + Environment.NewLine);
                        fs.Write(toWrite);
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(settsFilePath))
                {
                    byte counter = 0;
                    foreach (int num in gameVars)
                    {
                        char varName = CheckChar(counter);

                        // Add game vars    
                        string toWrite = "-" + varName +
                            " " + gameVars[counter] + " ";

                        // write added var
                        sw.Write(toWrite);
                        counter++;
                    }

                    // Write a new line
                    sw.WriteLine();

                    // Write all the agents on the file
                    foreach (Agents a in agents)
                        sw.WriteLine(a);
                }
            }

            Render.PressKey("The save file was stored on\n" +
                $"{dirPath}");
        }

        public static void Load(string[] args, out GameSettings gs,
            out List<Agents> agents)
        {
            settsFilePath = dirPath + @"\" + @args[1];
            if (File.Exists(settsFilePath))
            {
                string[] sav = new string[16];
                agents = new List<Agents>();
                gs = null;


                // Open the file to read from
                using (StreamReader sr = File.OpenText(settsFilePath))
                {
                    // Temp vars
                    string s;
                    List<Agents> newAgents = new List<Agents>();
                    string[] agentsInfo;

                    if ((s = sr.ReadLine()) != null)
                    {
                        // Counters
                        string arg = "";
                        int counter = 0;
                        foreach (char c in s)
                        {
                            if (c != ' ')
                            {
                                arg += c;
                            }
                            else
                            {
                                sav[counter] += arg;
                                counter++;
                                arg = "";
                            }
                        }

                        // Get all agents
                        agentsInfo = File.ReadAllLines(settsFilePath);

                        // Run through all the agent lines
                        for (int i = 1; i < agentsInfo.Length; i++)
                        {
                            string[] values = agentsInfo[i].Split(' ');

                            // Add new zombies
                            if (values[3][0] == 'Z')
                                newAgents.Add(
                                    new Zombie(
                                        ai: values[1],
                                        X: values[5], 
                                        Y: values[7]));
                            // add new humans
                            else
                                newAgents.Add(
                                    new Human(
                                        ai: values[1],
                                        X: values[5],
                                        Y: values[7]));
                        }

                        // Assign out variables
                        gs = new GameSettings(sav);
                        agents = newAgents;

                        // Success message
                        Render.PressKey("Save file successfully loaded.");

                    }
                    // Error message
                    else
                        Render.PressKey("Error, no save file loaded.");
                }

            }
            else
            {
                // Defaults if save file not found
                gs = new GameSettings(args);
                agents = null;
                Console.WriteLine($"Save File: {args[1]} not found.");
            }
        }

        /// <summary>
        /// Get the correspondent char
        /// </summary>
        /// <param name="check">Number to check</param>
        /// <returns>Argument char</returns>
        private static char CheckChar(int check)
        {
            char varName = ' ';

            switch (check)
            {
                case 0:
                    varName = 'x';
                    break;
                case 1:
                    varName = 'y';
                    break;
                case 2:
                    varName = 'h';
                    break;
                case 3:
                    varName = 'z';
                    break;
                case 4:
                    varName = 'Z';
                    break;
                case 5:
                    varName = 'H';
                    break;
                case 6:
                    varName = 't';
                    break;
                case 7:
                    varName = 'T';
                    break;
            }
            return varName;
        }
    }
}
