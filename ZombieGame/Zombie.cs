namespace ZombieGame
{
    class Zombie : Agents
    {
        // Zombie constructor
        public Zombie(bool AIUnit) : base(AIUnit)
        {
            Infected = true;
        }    

        // Print symbols for zombie agents
        public char PrintPart()
        {
            // If zombie is AI controlled
            if (Ai)
            {
                return 'ʞ';
            }

            // If zombie is player controlled
            else
            {
                return 'z';
            }
        }

        public override string ToString() => base.ToString() + "Zombie";
    }
}
