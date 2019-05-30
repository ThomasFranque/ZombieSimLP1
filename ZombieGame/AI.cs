using System.Threading;

namespace ZombieGame
{
    static class AI
    {
        /// <summary>
        /// Accepts a human agent and does it's movement accordingly
        /// </summary>
        /// <param name="agents"></param>
        static public void CheckType(Node j)
        {
            // Human, runs from zombie
            if (j is Human)
            {
                MoveHumansAi(j);
            }
            // Zombie, runs towards human
            if (j is Zombie)
            {
                MoveZombiesAi(j);
                Thread.Sleep(2000);
            }
        }

        static public void MoveHumansAi(Node i)
        {
            // Check if there's zombies around, move way from them
        }

        static public void MoveZombiesAi(Node i)
        {
            // Check if there's humans around, move towards them
        }
    }
}
