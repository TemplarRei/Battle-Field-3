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
        public FieldCellComponent GetFieldCell(FieldCellType fieldCellType, string minePower = "")
        {
            // Can also be implemented using dictionary
            switch (fieldCellType)
            {
                case FieldCellType.EmptyFieldCell:
                    return new EmptyFieldCell();
                case FieldCellType.ExplodedFieldCell:
                    return new ExplodedFieldCell();
                case FieldCellType.MineFieldCell:
                    int i = 0;
                    bool isMinePowerAnInteger = int.TryParse(minePower, out i); //i now = 108
                    if (!isMinePowerAnInteger) 
                    {
                        // Invalid Move
                        throw new ArgumentException("Invalid mine power!");
                    }
                    return new MineFieldCell(minePower);

                default:
                    throw new ArgumentException();
            }
        }
    }
}
