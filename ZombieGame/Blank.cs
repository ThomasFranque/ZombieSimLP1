using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class Blank : Node
    {
        public Blank(bool ai) : base(ai)
        {
        }

        public override char PrintPart()
        {
            return ' ';
        }

        public override string ToString() => $"Ai: {Ai} ; Blank";

    }
}
