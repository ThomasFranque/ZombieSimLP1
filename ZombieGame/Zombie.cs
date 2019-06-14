namespace ZombieGame
{
    class Zombie : Agents
    {
        // Zombie constructor
        public Zombie(bool AIUnit, int sizeX, int sizeY) : 
            base(AIUnit, sizeX, sizeY)
        {
            Infected = true;
            canInfect = true;
        }

        public Zombie(string ai, string X, string Y) :
            base(ai, X, Y)
        {
            Infected = true;
            canInfect = true;
        }

        // Print symbols for zombie agents
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

        public override string ToString() => base.ToString() + "Zombie;" +
            $" X: {X} Y: {Y}";
    }
}
