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

        public override string ToString() => (!Infected) ? base.ToString() + "Human" +
            $" X: {X}\tY: {Y}" : base.ToString() + "Zombie" +
            $" X: {X}\tY: {Y}";
    }
}
