using System;
using BattleField.Logic.Contracts;
using BattleField.Logic.Utils;

namespace BattleField.Logic
{

    public class Core
    {
        private const string FieldInitMessage = "Enter the size of the battle field: n = ";
        private const string TurnPromptMessage = "Enter coordinates: ";

        private ILogicController controller;
        private IReader reader;
        private IWriter writer;
        private IGameInstance game;
        private IGameSaver saver;

        public Core(ILogicController controller, IReader reader, IWriter writer, IGameSaver saver, IGameInstance game)
        {
            this.controller = controller;
            this.reader = reader;
            this.writer = writer;
            this.saver = saver;
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
                this.writer.PrintString(TurnPromptMessage);
                string input = this.reader.GetInput();

                if (input == "undo" || input == "redo")
                {
                    var previous = input == "undo";

                    var save = this.saver.RetrieveState(previous);

                    for (int i = 0;i < this.game.Field.GetLength(0);i++)
                    {
                        for (int j = 0;j < this.game.Field.GetLength(1);j++)
                        {
                            this.game.Field[i, j] = this.game.CellStorage.GetCell(save.Field[i,j].DrawingSign);
                        }
                    }
                }
                else
                {
                    this.saver.SaveState(this.game);

                    int[] coords = ParseInput(input);
                    
                    var mine = controller.GetMine(game, coords[0], coords[1]);

                    if (mine != 0)
                    {
                        controller.FieldUpdate(coords[0], coords[1], this.game);
                        moveCounter++;
                    }
                }

                writer.PrintField(game);

                gameOver = controller.EndOfGameCheck(this.game.Size, game);

            }

            // This should be fixed with an external message dictionary and a Command pattern.

            writer.GameEndMessage(game, moveCounter);
        }

        private static int[] ParseInput(string input)
        {

            var parsedCoords = new int[2];

            parsedCoords[1] = GetIntFromInput(input, true);
            parsedCoords[0] = GetIntFromInput(input);

            return parsedCoords;
        }

        private static int GetIntFromInput(string input, bool coordinateFlag = false)
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
