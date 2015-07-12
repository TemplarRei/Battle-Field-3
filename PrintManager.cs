using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFiled
{
    public class PrintManager
    {

        public static void PrintField(string[,] battleField)
        {
            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("   {0}  ", i);
                }
                else
                {
                    Console.Write("{0}  ", i);
                }
            }

            Console.WriteLine();

            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("   -", i);
                }
                else
                {
                    Console.Write("---");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                for (int j = -2; j < battleField.GetLength(1); j++)

                    if (j == -2)
                        Console.Write("{0}", i);

                    else if (j == -1)
                        Console.Write("|");

                    else
                        Console.Write(" {0} ", battleField[i, j]);
                Console.WriteLine();
            }
        }

        public static void PrintMoves(int moves)
        {

            Console.WriteLine("Detonated mines {0}", moves);
        }

    }
}
