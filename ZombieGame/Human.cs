
namespace ZombieGame
{
    class Human : Agents
    {
        // Human constructor
        public Human (bool AIUnit)
        {
            Ai = AIUnit;
            Infected = false;
        }

        // Print symbol for human agents
        public override char PrintPart(bool ai)
        {
            // If human is AI controlled
            if (ai)
            {
                return 'ɥ';
            }

            // If human is player controlled
            else
            {
                return 'h';
            }
        }
    }
}
