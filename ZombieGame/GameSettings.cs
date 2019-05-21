using System;

namespace ZombieGame
{
    /// <summary>
    /// Contains all the game settings, such as how many player controlled
    /// units and total rounds.
    /// </summary>
    class GameSettings
    {
        /*
        * dotnet run -- -x 20 -y 20 -z 10 -h 30 -Z 1 -H 2 -t 1000
        */

        /// <summary>
        /// Get and set map size horizontaly
        /// </summary>
        public int x { get; private set; }

        /// <summary>
        /// Get and set map size verticaly
        /// </summary>
        public int y { get; private set; }

        /// <summary>
        /// Get and set number of AI controlled zombies
        /// </summary>
        public int z { get; private set; }

        /// <summary>
        /// Get and set number of AI controlled humans
        /// </summary>
        public int h { get; private set; }

        /// <summary>
        /// Get and set number of playable zombies
        /// </summary>
        public int Z { get; private set; }

        /// <summary>
        /// Get and set number of playable humans
        /// </summary>
        public int H { get; private set; }

        /// <summary>
        ///  Get and set max game turns
        /// </summary>
        public int t { get; private set; }


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

            // #############
            // ### Debug ###
            // #############
            Console.WriteLine("x = " + x + "\nH = " + H);
            // #############
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
                // Fill these
                case 'x':
                    x = Convert.ToInt32(numArg);
                    break;

                // 
                case 'y':
                    y = Convert.ToInt32(numArg);
                    break;

                // 
                case 'z':
                    z = Convert.ToInt32(numArg);
                    break;

                // 
                case 'h':
                    h = Convert.ToInt32(numArg);
                    break;

                // 
                case 'Z':
                    Z = Convert.ToInt32(numArg);
                    break;

                // 
                case 'H':
                    H = Convert.ToInt32(numArg);
                    break;

                // 
                case 't':
                    t = Convert.ToInt32(numArg);
                    break;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="h"></param>
        /// <param name="Z"></param>
        /// <param name="H"></param>
        /// <param name="t"></param>
        public GameSettings(int x, int y, int z, int h, int Z, int H, int t)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.h = h;
            this.Z = Z;
            this.H = H;
            this.t = t;
        }
    }
}
