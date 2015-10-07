namespace BattleField.Logic.Utils
{
    using System;
    using System.Collections.Generic;
    using BattleField.Logic.Contracts;
    using Models;

    public class FlyweightCell: IFlyweightFactory
    {
        private const string EMPTY_FIELD_CELL_DRAWING_SIGN = "-";
        private const string EXPLODED_FIELD_CELL_DRAWING_SIGN = "X";
        private static readonly string[] MINES_ARRAY = { "1", "2", "3", "4", "5" };
        private static readonly Random RANDOM = new Random();

        private ICellFactory Factory;
        private Dictionary<string, ICellObject> cellsInUse;

        public FlyweightCell(ICellFactory factory)
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

        //public FieldCellComponent GetFieldCell(FieldCellType fieldCellType)
        //{
        //    // Can also be implemented using dictionary
        //    //switch (fieldCellType)
        //    //{
        //    //    case FieldCellType.EmptyFieldCell:
        //    //        return new EmptyFieldCell(EMPTY_FIELD_CELL_DRAWING_SIGN);
        //    //    case FieldCellType.ExplodedFieldCell:
        //    //        return new ExplodedFieldCell(EXPLODED_FIELD_CELL_DRAWING_SIGN);
        //    //    case FieldCellType.MineFieldCell:
        //    //        var minePower = MINES_ARRAY[RANDOM.Next(0, MINES_ARRAY.Length)];
        //    //        return new MineFieldCell(minePower);

        //    //    default:
        //    //        throw new ArgumentException();
        //    //}
        
        //}
    }
}
