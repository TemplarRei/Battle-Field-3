namespace BattleFiled
{
    using System;
    using Utils;

    public class Program
    {
        public static void Main()
        {
            int fieldSize = TakeFieldSize();
            var battleField = FieldInit(fieldSize);

            Console.WriteLine("Welcome to \"Battle Field\" game.");

            Console.WriteLine();
            Printer.PrintField(battleField);
            Console.WriteLine();
            int moveCounter = 0;
            bool gameOver = false;

            while (!gameOver)
            {

                string input = GetInput();
                int row = GetIntFromInput(input, true);
                int col = GetIntFromInput(input, false);
                var mine = GetMine(battleField, row, col);

                if (mine != 0)
                {
                    battleField = HodNaIgracha(row, col, fieldSize, battleField);
                    moveCounter++;
                }

                Printer.PrintField(battleField);

                gameOver = EndOfGameCheck(fieldSize, battleField);

            }

            GameEnd(battleField, moveCounter);
        }

        private static void GameEnd(BattleField battleField, int moveCounter)
        {
            Printer.PrintField(battleField);
            Console.WriteLine("Game over!");
            Printer.PrintMoves(moveCounter);
        }

        private static bool EndOfGameCheck(int fieldSize, BattleField battleField)
        {
            int count = 0;
            bool krai = false;

            for (int rowCheck = 0; rowCheck < fieldSize; rowCheck++)
            {
                for (int colCheck = 0; colCheck < fieldSize; colCheck++)
                {
                    if (battleField.Field[rowCheck, colCheck] == "-" || battleField.Field[rowCheck, colCheck] == "X")
                    {
                        count++;
                    }

                    if (count == fieldSize * fieldSize)
                    {
                        krai = true;
                    }
                }
            }

            return krai;
        }

        private static int GetMine(BattleField battleField, int row, int col)
        {
            string currMoveObject = battleField.Field[row, col];
            int mine = 0;

            if (!int.TryParse(currMoveObject, out mine))
            {
                Console.WriteLine("Invalid Move");
            }

            return mine;
        }

        private static int GetIntFromInput(string input, bool coordinateFlag)
        {
            int coordFlag = coordinateFlag ? 0 : 1;
            var rowsString = input.Split(' ')[coordFlag];
            var rowsInt = int.Parse(rowsString);
            return rowsInt;
        }

        private static string GetInput()
        {
            Console.WriteLine("Please enter coordinates: ");
            string input = Console.ReadLine();

            return input;
        }

        private static BattleField FieldInit(int size)
        {
            //console.write("enter the size of the battle field: n = ");
            //fieldsize = int.parse(console.readline());
            var battleField = new BattleField(size);
            Random randomPosition = new Random();

            battleField.DrawField();

            AddMines(battleField, randomPosition);

            return battleField;
        }

        private static int TakeFieldSize()
        {
            Console.Write("Enter the size of the battle field: n = ");
            int fieldSize = int.Parse(Console.ReadLine());
            return fieldSize;
        }

        private static void AddMines(BattleField battleField, Random randomPosition)
        {
            string[] minesArray = { "1", "2", "3", "4", "5" };

            double fifteenPercentNSquared = 0.15 * battleField.Size * battleField.Size;
            double thirtyPercenNSquared = 0.3 * battleField.Size * battleField.Size;

            int fifteenPercent = Convert.ToInt16(fifteenPercentNSquared);
            int thirtyPercent = Convert.ToInt16(thirtyPercenNSquared);

            int numberOfMines = randomPosition.Next(fifteenPercent, thirtyPercent + 1);

            for (int i = 0; i < numberOfMines; i++)
            {
                int newRow = randomPosition.Next(0, battleField.Size);
                int newCol = randomPosition.Next(0, battleField.Size);

                if (battleField.Field[newRow, newCol] == "-")
                {
                    battleField.Field[newRow, newCol] = minesArray[randomPosition.Next(0, 5)];
                }
                else
                {
                    numberOfMines--;
                }
            }
        }

        public static BattleField HodNaIgracha(int row, int col, int n, BattleField battleField)
        {
            if (Convert.ToInt16(battleField.Field[row, col]) >= 1)
            {
                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    battleField.Field[row - 1, col - 1] = "X";
                }

                if (row - 1 >= 0 && col < n - 1)
                {
                    battleField.Field[row - 1, col + 1] = "X";
                }

                if (row < n - 1 && col - 1 > 0)
                {
                    battleField.Field[row + 1, col - 1] = "X";
                }

                if (row < n - 1 && col < n - 1)
                {
                    battleField.Field[row + 1, col + 1] = "X";
                }

                if (Convert.ToInt16(battleField.Field[row, col]) >= 2)
                {
                    if (row - 1 >= 0)
                    {
                        battleField.Field[row - 1, col] = "X";
                    }

                    if (col - 1 >= 0)
                    {
                        battleField.Field[row, col - 1] = "X";
                    }

                    if (col < n - 1)
                    {
                        battleField.Field[row, col + 1] = "X";
                    }

                    if (row < n - 1)
                    {
                        battleField.Field[row + 1, col] = "X";
                    }

                    if (Convert.ToInt16(battleField.Field[row, col]) >= 3)
                    {
                        if (row - 2 >= 0)
                        {
                            battleField.Field[row - 2, col] = "X";
                        }

                        if (col - 2 >= 0)
                        {
                            battleField.Field[row, col - 2] = "X";
                        }

                        if (col < n - 2)
                        {
                            battleField.Field[row, col + 2] = "X";
                        }

                        if (row < n - 2)
                        {
                            battleField.Field[row + 2, col] = "X";
                        }

                        if (Convert.ToInt16(battleField.Field[row, col]) >= 4)
                        {
                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                battleField.Field[row - 2, col - 1] = "X";
                            }

                            if (row - 2 >= 0 && col < n - 1)
                            {
                                battleField.Field[row - 2, col + 1] = "X";
                            }

                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                battleField.Field[row - 1, col - 2] = "X";
                            }

                            if (row - 1 >= 0 && col < n - 2)
                            {
                                battleField.Field[row - 1, col + 2] = "X";
                            }

                            if (row < n - 1 && col - 2 >= 0)
                            {
                                battleField.Field[row + 1, col - 2] = "X";
                            }

                            if (row < n - 1 && col < n - 2)
                            {
                                battleField.Field[row + 1, col + 2] = "X";
                            }

                            if (row < n - 2 && col - 1 > 0)
                            {
                                battleField.Field[row + 2, col - 1] = "X";
                            }

                            if (row < n - 2 && col < n - 1)
                            {
                                battleField.Field[row + 2, col + 1] = "X";
                            }

                            if (Convert.ToInt16(battleField.Field[row, col]) == 5)
                            {
                                if (row - 2 >= 0 && col - 2 >= 0)
                                {
                                    battleField.Field[row - 2, col - 2] = "X";
                                }

                                if (row - 2 >= 0 && col < n - 2)
                                {
                                    battleField.Field[row - 2, col + 2] = "X";
                                }

                                if (row < n - 2 && col - 2 > 0)
                                {
                                    battleField.Field[row + 2, col - 2] = "X";
                                }

                                if (row < n - 2 && col < n - 2)
                                {
                                    battleField.Field[row + 2, col + 2] = "X";
                                }
                            }
                        }
                    }
                }
            }

            battleField.Field[row, col] = "X";

            return battleField;
        }
    }
}
