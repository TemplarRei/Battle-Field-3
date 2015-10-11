namespace BattleField.Logic.Utils
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class CellProvider: ICellProvider
    {
        private static readonly Random RANDOM = new Random();

        private ICellProvider Factory;
        private IDictionary<string, ICellObject> cellsInUse;

        public CellProvider(ICellProvider factory)
        {
            this.Factory = factory;
            this.cellsInUse = new Dictionary<string, ICellObject>();
        }

        public ICellObject GetCell(string type)
        {
            if (this.cellsInUse.ContainsKey(type))
            {
                return this.cellsInUse[type];
            }

            var newCell = this.Factory.GetCell(type);

            return newCell;
        }
    }
}
