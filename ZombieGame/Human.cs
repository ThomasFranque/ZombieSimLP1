namespace ZombieGame
{
    class Human : Agents
    {
        /// <summary>
        /// Human Agent constructor.
        /// </summary>
        /// <param name="AIUnit"> Defines if human is AI controlled or 
        /// not. </param>
        /// <param name="sizeX"> Uses board size to 
        /// give x position to agent </param>
        /// <param name="sizeY">Uses board size to 
        /// give y position to agent</param>
        public Human (bool AIUnit, int sizeX, int sizeY) :
            base(AIUnit, sizeX, sizeY)
        {
            Infected = false;
            canInfect = false;
        }

        /// <summary>
        /// Human agent constructor to be used if user loads save file
        /// </summary>
        /// <param name="ai">Defines if human is AI controlled or 
        /// not.</param>
        /// <param name="X"> Uses board size to 
        /// give x position to agent. </param>
        /// <param name="Y"> Uses board size to 
        /// give y position to agent. </param>
        public Human(string ai, string X, string Y) : 
            base(ai, X, Y)
        {
            Infected = false;
            canInfect = false;
        }

        /// <summary>
        /// Method to print char corresponding to specific agent, in this case
        /// print char for human agent and changes if is an AI human or not.
        /// </summary>
        /// <returns>Returns specific char. </returns>
        public char PrintPart()
        {
            // If human is AI controlled
            if (Ai)
            {
                return 'H';
            }

            // If human is player controlled
            else
            {
                return 'h';
            }
        }


        /// <summary>
        /// Override of the ToString() method to print human information
        /// depending on if said human is infected or not.
        /// </summary>
        /// <returns> Returns string with x an y position. </returns>
        public override string ToString() => (!Infected) ? base.ToString() + 
            "Human;" +
            $" X: {X} Y: {Y}" : base.ToString() + 
            "Zombie;" +
            $" X: {X} Y: {Y}";
    }
}
