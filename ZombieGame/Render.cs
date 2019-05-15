using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Render
    {
        // If program isn't run through the console we have a back up
        internal void EnterVaLues ()
        {
            Console.Write("Insert the map's x value: ");

            Console.Write("Now, the map's y value: ");

            Console.Write("Insert the number of zombies: ");

            Console.Write("Insert the number of humans: ");

            Console.Write("Number of zombies you want to control: ");

            Console.Write("Number of humans you want to control: ");

            Console.WriteLine("Insert the number of Max Turns");
        }
    }
}
