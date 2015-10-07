using System;
using BattleField.Logic.Contracts;
using BattleField.Logic.Utils;

namespace BattleField.Logic
{

    public class Core
    {
        private const string FieldInitMessage = "Enter the size of the battle field: n = ";
        private const string TurnPromptMessage = "Enter coordinates: ";

        ILogicController controller;
        IReader reader;
        IWriter writer;
        IGameInstance game;

        public Core(ILogicController controller, IReader reader, IWriter writer, IGameInstance game)
        {
            this.controller = controller;
            this.reader = reader;
            this.writer = writer;
            this.game = game;
        }

        public void Run()
        {
            SetFieldSize();
            this.game.FieldInit();

            int moveCounter = 0;
            bool gameOver = false;

            writer.PrintField(game);

            while (!gameOver)
            {
                // set the user input coordinates to a int array. coords[0] = row number and coords[1] = col number.
                // there's a bug, at the moment the logicController thinks coords[0] is col and coords[1] is row. Will be fixed asap.

                int[] coords = GetParsedInput();

                var mine = controller.GetMine(game, coords[0], coords[1]);

                if (mine != 0)
                {
                    controller.FieldUpdate(coords[0], coords[1], this.game);
                    moveCounter++;
                }

                writer.PrintField(game);

                gameOver = controller.EndOfGameCheck(this.game.Size, game);

            }

            // This should be fixed with an external message dictionary and a Command pattern.

            writer.GameEndMessage(game, moveCounter);
        }

        private int[] GetParsedInput()
        {
            this.writer.PrintString(TurnPromptMessage);
            string input = this.reader.GetInput();
            var parsedCoords = new int[2];

            parsedCoords[0] = GetIntFromInput(input, true);
            parsedCoords[1] = GetIntFromInput(input);

            return parsedCoords;
        }

        private int GetIntFromInput(string input, bool coordinateFlag = false)
        {
            int coordFlag = coordinateFlag ? 0 : 1;
            var rowsString = input.Split(' ')[coordFlag];
            var rowsInt = int.Parse(rowsString);
            return rowsInt;
        }

        private void SetFieldSize()
        {
            this.writer.PrintString(FieldInitMessage);
            this.game.Size = this.reader.TakeFieldSize();
        }
    }
}
