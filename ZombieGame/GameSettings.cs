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
        /// 
        /// </summary>
        public int x { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int y { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int z { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int h { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Z { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int H { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int t { get; private set; }


        /// <summary>
        /// Constructor will initialize the game variables
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
    }
}
