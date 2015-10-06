namespace BattleField.Logic.Utils
{
    using System;

    using BattleField.Logic.Contracts;

    public class LogicController : ILogicController
    {

        public void FieldUpdate(int row, int col, IGameObject battleField, IFieldCellFactory factory)
        {
            // TODO: FLYWEIGHT PATTERN NEEDED

            var explodedFieldCell = factory.GetFieldCell(FieldCellType.ExplodedFieldCell);
            switch (battleField.Field[row, col].Select())
            {
                case 1: ExplodeLevelOne(row, col, battleField.Size, battleField, explodedFieldCell);
                    break;
                case 2: ExplodeLevelTwo(row, col, battleField.Size, battleField, explodedFieldCell);
                    break;
                case 3: ExplodeLevelThree(row, col, battleField.Size, battleField, explodedFieldCell);
                    break;
                case 4: ExplodeLevelFour(row, col, battleField.Size, battleField, explodedFieldCell);
                    break;
                case 5: ExplodeLevelFive(row, col, battleField.Size, battleField, explodedFieldCell);
                    break;
                default:
                    break;
            }

            // return battleField;
        }

        private static void ExplodeLevelFive(int row, int col, int n, IGameObject battleField, FieldCellComponent explodedFieldCell)
        {
            ExplodeLevelFour(row, col, n, battleField, explodedFieldCell);

            if (row - 2 >= 0 && col - 2 >= 0)
            {
                battleField.Field[row - 2, col - 2] = explodedFieldCell;
            }

            if (row - 2 >= 0 && col < n - 2)
            {
                battleField.Field[row - 2, col + 2] = explodedFieldCell;
            }

            if (row < n - 2 && col - 2 >= 0)
            {
                battleField.Field[row + 2, col - 2] = explodedFieldCell;
            }

            if (row < n - 2 && col < n - 2)
            {
                battleField.Field[row + 2, col + 2] = explodedFieldCell;
            }
        }

        private static void ExplodeLevelFour(int row, int col, int n, IGameObject battleField, FieldCellComponent explodedFieldCell)
        {
            ExplodeLevelThree(row, col, n, battleField, explodedFieldCell);

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
        }

        private static void ExplodeLevelThree(int row, int col, int n, IGameObject battleField, FieldCellComponent explodedFieldCell)
        {
            ExplodeLevelTwo(row, col, n, battleField, explodedFieldCell);

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
        }

        private static void ExplodeLevelTwo(int row, int col, int n, IGameObject battleField, FieldCellComponent explodedFieldCell)
        {
            ExplodeLevelOne(row, col, n, battleField, explodedFieldCell);

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
        }

        private static void ExplodeLevelOne(int row, int col, int n, IGameObject battleField, FieldCellComponent explodedFieldCell)
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

            battleField.Field[row, col] = explodedFieldCell;
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