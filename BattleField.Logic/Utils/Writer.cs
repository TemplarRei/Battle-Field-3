namespace BattleField.Logic.Utils
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void InitField(IGameObject gameObject)
        {
            Console.WriteLine("Welcome to \"Battle Field\" game.");

            Console.WriteLine();
            PrintField(gameObject);
            Console.WriteLine();
        }

        public void PrintField(IGameObject battleField)
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

        public void GameEndMessage(IGameObject battleField, int moveCounter)
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
