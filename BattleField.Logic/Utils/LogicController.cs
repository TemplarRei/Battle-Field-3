namespace BattleField.Logic.Utils
{
    using System;

    using BattleField.Logic.Contracts;

    public class LogicController : ILogicController
    {

        public void FieldUpdate(int row, int col, int n, IGameObject battleField, IFieldCellFactory factory)
        {
            // TODO: FLYWEIGHT PATTERN NEEDED
           
            var explodedFieldCell = factory.GetFieldCell(FieldCellType.ExplodedFieldCell);
            if (battleField.Field[row, col].Select() != 0)
            {
                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    battleField.Field[row - 1, col - 1] = explodedFieldCell;
                }

                if (row - 1 >= 0 && col < n - 1)
                {
                    battleField.Field[row - 1, col + 1] = explodedFieldCell;
                }

                if (row < n - 1 && col - 1 > 0)
                {
                    battleField.Field[row + 1, col - 1] = explodedFieldCell;
                }

                if (row < n - 1 && col < n - 1)
                {
                    battleField.Field[row + 1, col + 1] = explodedFieldCell;
                }

                if (battleField.Field[row, col].Select() >= 2)
                {
                    if (row - 1 >= 0)
                    {
                        battleField.Field[row - 1, col] = explodedFieldCell;
                    }

                    if (col - 1 >= 0)
                    {
                        battleField.Field[row, col - 1] = explodedFieldCell;
                    }

                    if (col < n - 1)
                    {
                        battleField.Field[row, col + 1] = explodedFieldCell;
                    }

                    if (row < n - 1)
                    {
                        battleField.Field[row + 1, col] = explodedFieldCell;
                    }

                    if (battleField.Field[row, col].Select() >= 3)
                    {
                        if (row - 2 >= 0)
                        {
                            battleField.Field[row - 2, col] = explodedFieldCell;
                        }

                        if (col - 2 >= 0)
                        {
                            battleField.Field[row, col - 2] = explodedFieldCell;
                        }

                        if (col < n - 2)
                        {
                            battleField.Field[row, col + 2] = explodedFieldCell;
                        }

                        if (row < n - 2)
                        {
                            battleField.Field[row + 2, col] = explodedFieldCell;
                        }

                        if (battleField.Field[row, col].Select() >= 4)
                        {
                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                battleField.Field[row - 2, col - 1] = explodedFieldCell;
                            }

                            if (row - 2 >= 0 && col < n - 1)
                            {
                                battleField.Field[row - 2, col + 1] = explodedFieldCell;
                            }

                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                battleField.Field[row - 1, col - 2] = explodedFieldCell;
                            }

                            if (row - 1 >= 0 && col < n - 2)
                            {
                                battleField.Field[row - 1, col + 2] = explodedFieldCell;
                            }

                            if (row < n - 1 && col - 2 >= 0)
                            {
                                battleField.Field[row + 1, col - 2] = explodedFieldCell;
                            }

                            if (row < n - 1 && col < n - 2)
                            {
                                battleField.Field[row + 1, col + 2] = explodedFieldCell;
                            }

                            if (row < n - 2 && col - 1 > 0)
                            {
                                battleField.Field[row + 2, col - 1] = explodedFieldCell;
                            }

                            if (row < n - 2 && col < n - 1)
                            {
                                battleField.Field[row + 2, col + 1] = explodedFieldCell;
                            }

                            if (battleField.Field[row, col].Select() == 5)
                            {
                                if (row - 2 >= 0 && col - 2 >= 0)
                                {
                                    battleField.Field[row - 2, col - 2] = explodedFieldCell;
                                }

                                if (row - 2 >= 0 && col < n - 2)
                                {
                                    battleField.Field[row - 2, col + 2] = explodedFieldCell;
                                }

                                if (row < n - 2 && col - 2 > 0)
                                {
                                    battleField.Field[row + 2, col - 2] = explodedFieldCell;
                                }

                                if (row < n - 2 && col < n - 2)
                                {
                                    battleField.Field[row + 2, col + 2] = explodedFieldCell;
                                }
                            }
                        }
                    }
                }
            }

            battleField.Field[row, col] = explodedFieldCell;

            // return battleField;
        }

        public bool EndOfGameCheck(int fieldSize, IGameObject battleField)
        {
            //int count = 0;
            bool endOfGame = true;
            for (int rowCheck = 0; rowCheck < fieldSize; rowCheck++)
            {
                for (int colCheck = 0; colCheck < fieldSize; colCheck++)
                {
                    // if it is not 0 it is a mine
                    if (battleField.Field[rowCheck, colCheck].Select() != 0)
                    {
                        // it is not the end of the game
                        return false;
                    }
                }
            }
            //for (int rowCheck = 0; rowCheck < fieldSize; rowCheck++)
            //{
            //    for (int colCheck = 0; colCheck < fieldSize; colCheck++)
            //    {
            //        if (battleField.Field[rowCheck, colCheck] == "-" || battleField.Field[rowCheck, colCheck] == "X")
            //        {
            //            count++;
            //        }

            //        if (count == fieldSize * fieldSize)
            //        {
            //            endOfGame = true;
            //        }
            //    }
            //}

            return endOfGame;
        }

        public int GetMine(IGameObject battleField, int row, int col)
        {
            return battleField.Field[row, col].Select();
            //string currMoveObject = battleField.Field[row, col];
            //int mine = 0;

            //if (!int.TryParse(currMoveObject, out mine))
            //{
            //    Console.WriteLine("Invalid Move");
            //}

            //return mine;
        }
    }
}