using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleField.Utils;

namespace BattleField
{
    public class Core
    {
        public void Run()
        {
            var logicController = new LogicController();
            var reader = new Reader();
            var printer = new Printer();
            int fieldSize = reader.TakeFieldSize();
            var gameObject = new GameObject(fieldSize);

            

            Console.WriteLine("Welcome to \"Battle Field\" game.");

            Console.WriteLine();
            printer.PrintField(gameObject);
            Console.WriteLine();
            int moveCounter = 0;
            bool gameOver = false;

            while (!gameOver)
            {

                string input = reader.GetInput();
                int row = reader.GetIntFromInput(input, true);
                int col = reader.GetIntFromInput(input, false);
                var mine = logicController.GetMine(gameObject, row, col);

                if (mine != 0)
                {
                    gameObject = logicController.FieldUpdate(row, col, fieldSize, gameObject);
                    moveCounter++;
                }

                printer.PrintField(gameObject);

                gameOver = logicController.EndOfGameCheck(fieldSize, gameObject);

            }

           printer.GameEndMessage(gameObject, moveCounter);
        }
    }
}
