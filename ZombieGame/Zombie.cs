
namespace ZombieGame
{
    class Zombie : Agents
    {
        // Zombie constructor
        public Zombie(bool AIUnit)
        {
            Ai = AIUnit;
            Infected = true;
        }    

        // Print symbols for zombie agents
        public override char PrintPart(bool ai)
        {
            // If zombie is AI controlled
            if (ai)
            {
                return 'ʞ';
            }

            // If zombie is player controlled
            else
            {
                return 'z';
            }
        }
    }
}
