namespace Utils
{
    using System;
    using BattleFiled;

    public static class Printer
    {
        public static void PrintField(BattleField battleField)
        {
            for (int i = 0; i < battleField.Size; i++)
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

            for (int i = 0; i < battleField.Size; i++)
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

            for (int i = 0; i < battleField.Size; i++)
            {
                for (int j = -2; j < battleField.Size; j++)
                {
                    if (j == -2)
                    {
                        Console.Write("{0}", i);
                    }
                    else if (j == -1)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" {0} ", battleField.Field[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }

        public static void PrintMoves(int moves)
        {
            Console.WriteLine("Detonated mines {0}", moves);
        }
    }
}
