using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFiled
{
    public class GameProcessess
    {
        public static void BoardInit(out int fieldSize, out string[,] battleField)
        {
            Console.Write("Enter the size of the battle field: n = ");
            fieldSize = int.Parse(Console.ReadLine());


            //tuka si pravq poleto
            battleField = new string[fieldSize, fieldSize];

            Random randomPosition = new Random();

            //celta na tova e da se zapylni matricata default s cherti
            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {

                    battleField[row, col] = "-";
                }
            }

            GenerateMines(fieldSize, battleField, randomPosition);
        }

        private static void GenerateMines(int fieldSize, string[,] battleField, Random randomPosition)
        {
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

                if (battleField[newRow, newCol] == "-")
                {
                    battleField[newRow, newCol] = minesArray[randomPosition.Next(0, 5)];
                }
                else
                {
                    numberOfMines--;
                }

            }
        }

        public static void GameTurns(int fieldSize, string[,] battleField)
        {
            Console.WriteLine("Welcome to \"Battle Field\" game.");
            //tuka pochvame
            Console.WriteLine();
            PrintManager.PrintField(battleField);
            Console.WriteLine();
            int moveCounter = 0;
            //this is a cycle from ZERO to ONE-HUNDRED 
            for (int turns = 0; turns < 100; turns++)
            {

                //here we read a string from the console
                Console.Write("Please enter coordinates: ");
                string line = Console.ReadLine();
                string stringRow = "";
                string stringCol = "";
                int row;
                int col;
                bool flagForRow = true;
                bool flagForCol = false;
                int positionWhenIStopped = 0; ;

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

                if (battleField[row, col] == "-" || battleField[row, col] == "X")
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
                //tuka proverqvam dali emina
                if (battleField[row, col] == "1" || battleField[row, col] == "2" || battleField[row, col] == "3" || battleField[row, col] == "4" || battleField[row, col] == "5")
                {
                    battleField = HodNaIgracha(row, col, fieldSize, battleField);
                    moveCounter++;
                }


                PrintManager.PrintField(battleField);

                int count = 0;
                bool krai = false;

                for (int rowCheck = 0; rowCheck < fieldSize; rowCheck++)
                {
                    for (int colCheck = 0; colCheck < fieldSize; colCheck++)
                    {
                        if (battleField[rowCheck, colCheck] == "-" || battleField[rowCheck, colCheck] == "X")
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
                    PrintManager.PrintField(battleField);
                    Console.WriteLine("Game over!");
                    PrintManager.PrintMoves(moveCounter);
                    break;
                }
            }
        }

        // I really have no idea how to refactor this particular piece of code...

        static string[,] HodNaIgracha(int row, int col, int n, string[,] battleField)
        {
            if (Convert.ToInt16(battleField[row, col]) >= 1)
            {
                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    battleField[row - 1, col - 1] = "X";
                }
                if (row - 1 >= 0 && col < n - 1)
                {
                    battleField[row - 1, col + 1] = "X";
                }
                if (row < n - 1 && col - 1 > 0)
                {
                    battleField[row + 1, col - 1] = "X";
                }
                if (row < n - 1 && col < n - 1)
                {
                    battleField[row + 1, col + 1] = "X";
                }

                if (Convert.ToInt16(battleField[row, col]) >= 2)
                {
                    if (row - 1 >= 0)
                    {
                        battleField[row - 1, col] = "X";
                    }
                    if (col - 1 >= 0)
                    {
                        battleField[row, col - 1] = "X";
                    }
                    if (col < n - 1)
                    {
                        battleField[row, col + 1] = "X";
                    }
                    if (row < n - 1)
                    {
                        battleField[row + 1, col] = "X";
                    }

                    if (Convert.ToInt16(battleField[row, col]) >= 3)
                    {
                        if (row - 2 >= 0)
                        {
                            battleField[row - 2, col] = "X";
                        }
                        if (col - 2 >= 0)
                        {
                            battleField[row, col - 2] = "X";
                        }
                        if (col < n - 2)
                        {
                            battleField[row, col + 2] = "X";
                        }
                        if (row < n - 2)
                        {
                            battleField[row + 2, col] = "X";
                        }

                        if (Convert.ToInt16(battleField[row, col]) >= 4)
                        {
                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                battleField[row - 2, col - 1] = "X";
                            }
                            if (row - 2 >= 0 && col < n - 1)
                            {
                                battleField[row - 2, col + 1] = "X";
                            }
                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                battleField[row - 1, col - 2] = "X";
                            }
                            if (row - 1 >= 0 && col < n - 2)
                            {
                                battleField[row - 1, col + 2] = "X";
                            }
                            if (row < n - 1 && col - 2 >= 0)
                            {
                                battleField[row + 1, col - 2] = "X";
                            }
                            if (row < n - 1 && col < n - 2)
                            {
                                battleField[row + 1, col + 2] = "X";
                            }
                            if (row < n - 2 && col - 1 > 0)
                            {
                                battleField[row + 2, col - 1] = "X";
                            }
                            if (row < n - 2 && col < n - 1)
                            {
                                battleField[row + 2, col + 1] = "X";
                            }

                            if (Convert.ToInt16(battleField[row, col]) == 5)
                            {
                                if (row - 2 >= 0 && col - 2 >= 0)
                                {
                                    battleField[row - 2, col - 2] = "X";
                                }
                                if (row - 2 >= 0 && col < n - 2)
                                {
                                    battleField[row - 2, col + 2] = "X";
                                }
                                if (row < n - 2 && col - 2 > 0)
                                {
                                    battleField[row + 2, col - 2] = "X";
                                }
                                if (row < n - 2 && col < n - 2)
                                {
                                    battleField[row + 2, col + 2] = "X";
                                }
                            }
                        }
                    }
                }
            }

            battleField[row, col] = "X";

            return battleField;
        }

       
    }
}
