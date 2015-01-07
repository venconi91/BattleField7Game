using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class Printer
    {
        public static void PrintOnConsole(string[,] Field) 
        {
            var fieldSize = Field.GetUpperBound(0);

            Console.WriteLine();
            Console.Write("   ");
            for (int k = 0; k <= fieldSize; k++)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
            Console.Write("   ");

            for (int k = 0; k <= fieldSize; k++)
            {
                Console.Write("--");
            }
            Console.WriteLine();

            for (int i = 0; i <= fieldSize; i++)
            {
                Console.Write(i + "| ");
                for (int j = 0; j <= fieldSize; j++)
                {
                    Console.Write(Field[i, j] + " ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
