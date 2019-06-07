namespace ZombieGame
{
    class Human : Agents
    {
        // Human constructor
        public Human (bool AIUnit) :base(AIUnit)
        {
            Infected = false;
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

        public override string ToString() => base.ToString() + "Human" +
            $" X: {X}\tY: {Y}";
    }
}
