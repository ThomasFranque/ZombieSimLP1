using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieGame
{
    class TestMap
    {
        // Declare Variables
        public Node[,] Board { get; set; }
        public int BoardX { get; }
        public int BoardY { get; }

        public TestMap(int x, int y)
        {
            BoardX = x;
            BoardY = y;
            Board = new Node[BoardX, BoardY];
        }

        // Instanciate bi-dim array of nodes with gameSettings x e y do mapa
        public void FillMap(List<Node> node, Node[,] nodes)
        {
            int a = 0;

            for (int i = 0; i < BoardY; i++)
            {
                for (int j = 0; j < BoardX; j++)
                {
                    Board[i, j] = node[a];
                    a++;
                }
            }
        }

        // For cycle to print array
        public void ShowMap()
        {
            for (int k = 0; k < BoardX * 4 + 1; k++)
                Console.Write("-");

            Console.WriteLine();

            for (int i = 0; i < BoardY; i++)
            {
                for (int j = 0; j < BoardX; j++)
                    foreach (Node a in Board)
                        Console.Write($"| {Board[i, j].PrintPart()} ");

                Console.WriteLine('|');

                for (int k = 0; k < BoardX * 4 + 1; k++)
                    Console.Write("-");

                Console.WriteLine();
            }

            //





            //public void ShowMap(int x, int y, int h, int z, int pH, int pZ)
            //{
            //    // Save parameter values in class properties
            //    this.x = x;
            //    this.y = y;
            //    this.h = h;
            //    this.z = z;
            //    H = pH;
            //    Z = pZ;

            //    // For cicle to print map
            //    for (int k = 0; k < x * 4 + 1; k++)
            //        Console.Write("-");

            //Console.WriteLine();

            //    for (int i = 0; i<y; i++)
            //    {
            //        for (int j = 0; j<x; j++)
            //            Console.Write("| O ");

            //        Console.WriteLine('|');

            //        for (int k = 0; k<x* 4 + 1; k++)
            //            Console.Write("-");

            //        Console.WriteLine();

            //    }
            //}
        }
    }
}
