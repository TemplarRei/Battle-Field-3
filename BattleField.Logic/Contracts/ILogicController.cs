﻿namespace BattleField.Logic.Contracts
{
    public interface ILogicController
    {
        int GetMine(IGameInstance battleField, int row, int col);
        void FieldUpdate(int row, int col, IGameInstance battleField);
        bool EndOfGameCheck(int fieldSize, IGameInstance battleField);
    }
}