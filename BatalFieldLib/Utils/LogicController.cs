namespace BatalFieldLib.Utils
{
    using System;

    using BatalFieldLib.Contracts;

    public class LogicController : ILogicController
    {

        public void FieldUpdate(int row, int col, int n, IGameObject battleField)
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

            // return battleField;
        }

        public bool EndOfGameCheck(int fieldSize, IGameObject battleField)
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

        public int GetMine(IGameObject battleField, int row, int col)
        {
            string currMoveObject = battleField.Field[row, col];
            int mine = 0;

            if (!int.TryParse(currMoveObject, out mine))
            {
                Console.WriteLine("Invalid Move");
            }

            return mine;
        }
    }
}