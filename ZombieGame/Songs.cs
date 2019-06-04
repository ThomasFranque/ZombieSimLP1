using System;
using System.Threading;

namespace ZombieGame
{
    class Songs
    {
        /// <summary>
        /// Plays a jingle using beeps and sleeps
        /// </summary>
        public static void TuneHappy()
        {
            Console.Beep(659, 100);
            Console.Beep(659, 100);
            Thread.Sleep(360);
            Console.Beep(659, 250);
            Console.Beep(523, 100);
            Console.Beep(659, 100);
            Thread.Sleep(380);
            Console.Beep(784, 500);
            Console.Beep(392, 500);
        }

        /// <summary>
        /// Plays music to be used when all humans die
        /// </summary>
        public static void TuneDeath()
        {
            Console.Beep(392, 200);
            Console.Beep(692, 200);
            Thread.Sleep(260);
            Console.Beep(692, 200);
            Console.Beep(692, 200);
            Console.Beep(652, 200);
            Console.Beep(592, 300);
            Console.Beep(522, 300);
            Console.Beep(392, 300);
            Console.Beep(392, 200);
            Console.Beep(322, 300);
        }
    }
}
