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
            // Printing the first row of table 
            Console.Write("   ");
            for (int i = 0; i < battleField.Size; i++)
            {
                Console.Write("{0}  ", i);
            }

            Console.WriteLine();

            // Print separator row
            Console.Write("   -");
            for (int i = 1; i < battleField.Size; i++)
            {
                Console.Write("---");
            }

            Console.WriteLine();
            
            // Print all rows
            for (int i = 0; i < battleField.Size; i++)
            {
                Console.Write("{0}|", i);

                for (int j = 0; j < battleField.Size; j++)
                {
                    Console.Write(" {0} ", battleField.Field[i, j]);
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
