namespace ZombieGame
{
    class Human : Agents
    {
        // Human constructor
        public Human (bool AIUnit, int sizeX, int sizeY) :
            base(AIUnit, sizeX, sizeY)
        {
            Infected = false;
            canInfect = false;
        }

        public Human(string ai, string X, string Y) : 
            base(ai, X, Y)
        {
            Infected = false;
            canInfect = false;
        }

        // Print symbol for human agents
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

        public override string ToString() => (!Infected) ? base.ToString() + 
            "Human;" +
            $" X: {X} Y: {Y}" : base.ToString() + 
            "Zombie;" +
            $" X: {X} Y: {Y}";
    }
}
