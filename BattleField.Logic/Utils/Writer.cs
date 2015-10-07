namespace BattleField.Logic.Utils
{
    using static System.Console;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void InitField(IGameInstance gameObject)
        {
            WriteLine("Welcome to \"Battle Field\" game.");

            WriteLine();
            PrintField(gameObject);
            WriteLine();
        }

        public void PrintField(IGameInstance battleField)
        {
            // Printing the first row of table 
            Write("   ");
            for (int i = 0; i < battleField.Size; i++)
            {
                Write("{0}  ", i);
            }

            WriteLine();

            // Print separator row
            Write("   -");
            for (int i = 1; i < battleField.Size; i++)
            {
                Write("---");
            }

            WriteLine();
            
            // Print all rows
            for (int i = 0; i < battleField.Size; i++)
            {
                Write("{0}|", i);

                for (int j = 0; j < battleField.Size; j++)
                {
                    Write(" {0} ", battleField.Field[i, j].DrawingSign);
                }

                WriteLine();
            }
        }

        public void GameEndMessage(IGameInstance battleField, int moveCounter)
        {
            this.PrintField(battleField);
            WriteLine("Game over!");
            this.PrintMoves(moveCounter);
        }

        public void PrintMoves(int moves)
        {
            WriteLine("Detonated mines {0}", moves);
        }

        public void PrintString(string str)
        {
            Write(str);
        }
    }
}
