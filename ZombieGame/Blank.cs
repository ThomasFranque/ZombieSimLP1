using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Blank : Node
    {
        public Blank() : base(false)
        {
        }

        public override char PrintPart()
        {
            return ' ';
        }
    }
}
