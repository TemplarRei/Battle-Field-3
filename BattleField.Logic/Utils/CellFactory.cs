namespace BattleField.Logic.Utils
{
    using System.Collections.Generic;
    using System;

    using Models;
    using Contracts;

    public class CellFactory :ICellFactory
    {
        private const string EMPTY_FIELD_CELL_DRAWING_SIGN = "-";
        private const string EXPLODED_FIELD_CELL_DRAWING_SIGN = "X";
        private static readonly string[] MINES_ARRAY = { "1", "2", "3", "4", "5" };

        private readonly Dictionary<string, Func<ICellObject>> CellFactories = new Dictionary<string, Func<ICellObject>>()
        {
            {"-", () => new EmptyFieldCell() },
            {"x", () => new ExplodedFieldCell() },
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
