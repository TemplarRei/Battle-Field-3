using System;
using BatalFieldLib.Contracts;
using BatalFieldLib.Utils;

namespace BatalFieldLib
{
    public class Core
    {
        ILogicController controller;
        IReader reader;
        IWriter writer;
        IGameObject game;

        public Core(ILogicController controller, IReader reader, IWriter writer, IGameObject game)
        {
            this.controller = controller;
            this.reader = reader;
            this.writer = writer;
            this.game = game;
        }

        public void Run()
        {
            //var logicController = new LogicController();
            //var reader = new ConsoleReader();
            //var printer = new ConsoleWriter();
            //int fieldSize = reader.TakeFieldSize();
            //var gameObject = new GameObject(fieldSize);
            this.game.Size = reader.TakeFieldSize();
            this.game.FieldInit();

            int moveCounter = 0;
            bool gameOver = false;

            writer.PrintField(game);

            while (!gameOver)
            {

                string input = this.reader.GetInput();
                int row = reader.GetIntFromInput(input, true);
                int col = reader.GetIntFromInput(input);
                var mine = controller.GetMine(game, row, col);

                if (mine != 0)
                {
                    controller.FieldUpdate(row, col, this.game.Size, game);
                    moveCounter++;
                }

                writer.PrintField(game);

                gameOver = controller.EndOfGameCheck(this.game.Size, game);

            }

            writer.GameEndMessage(game, moveCounter);
        }
    }
}
