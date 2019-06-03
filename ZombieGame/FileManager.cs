using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    static class FileManager
    {
        private static string dirPath;
        private static string filePath;

        /// <summary>
        /// 
        /// </summary>
        static FileManager()
        {
            // Get the location of the AppData dir
            dirPath = Environment.GetFolderPath
                (Environment.SpecialFolder.ApplicationData);

            // Name of the folder
            dirPath += @"\ZombieSimMBT";

            // File name and format
            filePath = dirPath + @"\sav.ini";                  
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
        public static void Save(int[] gameVars)
        {
            // Store arguments 
            // int x, int y, int z, int h, int Z, int H, int t, int T

            // If directory does not exist, create it. 
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            // Create file if doesnt exist
            if (!File.Exists(filePath))
            {
                // Create a file to write to
                using (FileStream fs = File.Create(filePath))
                {
                    // Write on it
                    // Write the vars in file
                    for (int i = 0; i < gameVars.Length; i++)
                    {
                        char varName = CheckChar(i);

                        // Add some text to file    
                        byte[] toWrite =
                            new UTF8Encoding(true).GetBytes("-" + varName +
                            " " + gameVars[i] + " ");
                        fs.Write(toWrite, 0, toWrite.Length);
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    byte counter = 0;
                    foreach (int num in gameVars)
                    {
                        char varName = CheckChar(counter);

                        // Add some text to file    
                        string toWrite = "-" + varName +
                            " " + gameVars[counter] + " ";

                        sw.Write(toWrite);
                        counter++;
                    }
                }
            }

            Console.WriteLine("The save file was stored on\n" +
                $"{dirPath}");
        }

        public static GameSettings LoadSetts()
        {
            string[] sav = new string[16];
            // Open the file to read from
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                if ((s = sr.ReadLine()) != null)
                {
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
                }
                else
                    Console.WriteLine("Error, no save file created.");
            }
            return new GameSettings(sav);
        }

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
