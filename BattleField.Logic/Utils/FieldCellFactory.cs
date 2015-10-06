using BattleField.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.Logic.Utils
{
    public class FieldCellFactory : IFieldCellFactory
    {
        private const string EMPTY_FIELD_CELL_DRAWING_SIGN = "-";
        private const string EXPLODED_FIELD_CELL_DRAWING_SIGN = "X";
        private static readonly string[] MINES_ARRAY = { "1", "2", "3", "4", "5" };
        private static readonly Random RANDOM = new Random();

        public FieldCellComponent GetFieldCell(FieldCellType fieldCellType)
        {
            // Can also be implemented using dictionary
            switch (fieldCellType)
            {
                case FieldCellType.EmptyFieldCell:
                    return new EmptyFieldCell(EMPTY_FIELD_CELL_DRAWING_SIGN);
                case FieldCellType.ExplodedFieldCell:
                    return new ExplodedFieldCell(EXPLODED_FIELD_CELL_DRAWING_SIGN);
                case FieldCellType.MineFieldCell:
                    var minePower ="5";// MINES_ARRAY[RANDOM.Next(0, MINES_ARRAY.Length)];
                    return new MineFieldCell(minePower);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
