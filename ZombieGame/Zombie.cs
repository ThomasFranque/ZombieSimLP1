namespace ZombieGame
{
    class Zombie : Agents
    {
        /// <summary>
        /// Zombie Agent constructor.
        /// </summary>
        /// <param name="AIUnit"> Defines if zombie is AI controlled or 
        /// not. </param>
        /// <param name="sizeX"> Uses board size to 
        /// give x position to agent </param>
        /// <param name="sizeY">Uses board size to 
        /// give y position to agent</param>
        public Zombie(bool AIUnit, int sizeX, int sizeY) : 
            base(AIUnit, sizeX, sizeY)
        {
            Infected = true;
            canInfect = true;
        }

        /// <summary>
        /// Zombie agent constructor to be used if user loads save file
        /// </summary>
        /// <param name="ai">Defines if zombie is AI controlled or 
        /// not.</param>
        /// <param name="X"> Uses board size to 
        /// give x position to agent. </param>
        /// <param name="Y"> Uses board size to 
        /// give y position to agent. </param>
        public Zombie(string ai, string X, string Y) :
            base(ai, X, Y)
        {
            Infected = true;
            canInfect = true;
        }


        /// <summary>
        /// Method to print char corresponding to specific agent, in this case
        /// print char for zombie agent and changes if is an AI zombie or not.
        /// </summary>
        /// <returns>Returns specific char. </returns>
        public char PrintPart()
        {
            // If zombie is AI controlled
            if (Ai)
            {
                return 'Z';
            }

            // If zombie is player controlled
            else
            {
                return 'z';
            }
        }

        /// <summary>
        /// Override of the ToString() method to print zombie information.
        /// </summary>
        /// <returns> Returns string with x an y position. </returns>
        public override string ToString() => base.ToString() + "Zombie;" +
            $" X: {X} Y: {Y}";
    }
}
