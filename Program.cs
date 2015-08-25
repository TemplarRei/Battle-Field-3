namespace BattleFiled
{
    using System;
    using Utils;

    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the size of the battle field: n = ");
            int fieldSize = int.Parse(Console.ReadLine());

            BattleField battleField = new BattleField(fieldSize);

            Random randomPosition = new Random();

            battleField.DrawField();

            string[] minesArray = { "1", "2", "3", "4", "5" };

            double fifteenPercentNSquared = 0.15 * fieldSize * fieldSize;
            double thirtyPercenNSquared = 0.3 * fieldSize * fieldSize;

            int fifteenPercent = Convert.ToInt16(fifteenPercentNSquared);
            int thirtyPercent = Convert.ToInt16(thirtyPercenNSquared);

            int numberOfMines = randomPosition.Next(fifteenPercent, thirtyPercent + 1);

            for (int i = 0; i < numberOfMines; i++)
            {
                int newRow = randomPosition.Next(0, fieldSize);
                int newCol = randomPosition.Next(0, fieldSize);

                if (battleField.Field[newRow, newCol] == "-")
                {
                    battleField.Field[newRow, newCol] = minesArray[randomPosition.Next(0, 5)];
                }
                else
                {
                    numberOfMines--;
                }
            }

            Console.WriteLine("Welcome to \"Battle Field\" game.");
            // tuka pochvame
            Console.WriteLine();
            Printer.PrintField(battleField);
            Console.WriteLine();
            int moveCounter = 0;
            // this is a cycle from ZERO to ONE-HUNDRED 
            for (int turns = 0; turns < 100; turns++)
            {
                // here we read a string from the console
                Console.Write("Please enter coordinates: ");
                string line = Console.ReadLine();
                string stringRow = string.Empty;
                string stringCol = string.Empty;
                int row;
                int col;
                bool flagForRow = true;
                bool flagForCol = false;
                int positionWhenIStopped = 0;

                for (int i = 0; i < 100; i++)
                {
                    if (flagForRow)
                    {
                        if (line[i] != ' ')
                        {
                            stringRow += line[i];

                            if (line[i + 1] == ' ')
                            {
                                positionWhenIStopped = i + 1;
                                flagForRow = false;
                                flagForCol = true;
                                break;
                            }
                        }
                    }
                }

                for (int i = positionWhenIStopped; i < 100; i++)
                {
                    if (flagForCol)
                    {
                        if (line[i] != ' ')
                        {
                            stringCol = stringCol + line[i];
                            break;
                        }
                    }
                }

                row = int.Parse(stringRow);
                col = int.Parse(stringCol);

                if (battleField.Field[row, col] == "-" || battleField.Field[row, col] == "X")
                {
                    if (turns > 0)
                    {
                        turns -= turns;
                    }
                    else
                    {
                        turns = -1;
                    }

                    Console.WriteLine("Invalid move!");
                }
                // tuka proverqvam dali emina
                if (battleField.Field[row, col] == "1" || battleField.Field[row, col] == "2" || battleField.Field[row, col] == "3" || battleField.Field[row, col] == "4" || battleField.Field[row, col] == "5")
                {
                    battleField = HodNaIgracha(row, col, fieldSize, battleField);
                    moveCounter++;
                }

                Printer.PrintField(battleField);

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

                if (krai)
                {
                    Printer.PrintField(battleField);
                    Console.WriteLine("Game over!");
                    Printer.PrintMoves(moveCounter);
                    break;
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
