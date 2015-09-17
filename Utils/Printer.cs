namespace BattleField.Utils
{
    using System;
    using BattleField;

    public class Printer
    {
        public void PrintField(GameObject battleField)
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

        public void GameEndMessage(GameObject battleField, int moveCounter)
        {
            this.PrintField(battleField);
            Console.WriteLine("Game over!");
            this.PrintMoves(moveCounter);
        }

        public void PrintMoves(int moves)
        {
            Console.WriteLine("Detonated mines {0}", moves);
        }
    }
}
