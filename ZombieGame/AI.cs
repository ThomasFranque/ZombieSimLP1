using System.Threading;

namespace ZombieGame
{
    class AI : Agents
    {
        public AI(bool ai) : base(ai)
        {
        }

        /// <summary>
        /// Accepts a human agent and does it's movement accordingly
        /// </summary>
        /// <param name="agents"></param>
        public void CheckType(Agents j)
        {
            // Human, runs from zombie
            if (j is Human)
            {
                //MoveHumansAi(j);
                
            }
            // Zombie, runs towards human
            if (j is Zombie)
            {
                MoveZombiesAi(j);
                Thread.Sleep(2000);               
            }
        }

        public void MoveHumansAi(Agents i)
        {
            // Check if there's zombies around, move way from them
        }

        public void MoveZombiesAi(Agents i)
        {
            // Check if there's humans around, move towards them
        }
    }
}
