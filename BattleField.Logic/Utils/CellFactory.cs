namespace BattleField.Logic.Utils
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class CellFactory :ICellProvider
    {
        private readonly Dictionary<string, Func<ICellObject>> CellFactories = new Dictionary<string, Func<ICellObject>>()
        {
            {"-", () => new EmptyFieldCell() },
            {"X", () => new ExplodedFieldCell() },
            {"1", () => new MineFieldCell("1") },
            {"2", () => new MineFieldCell("2") },
            {"3", () => new MineFieldCell("3") },
            {"4", () => new MineFieldCell("4") },
            {"5", () => new MineFieldCell("5") }
        };

        public ICellObject GetCell(string type)
        {
            var currentCell = CellFactories[type];
            return currentCell();
        }
    }
}
