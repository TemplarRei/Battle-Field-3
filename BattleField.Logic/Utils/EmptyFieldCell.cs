using BattleField.Logic.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.Logic.Utils
{
    public class EmptyFieldCell : FieldCellComponent
    {
        public EmptyFieldCell(string drawingSign)
            : base(drawingSign)
        {

        }
    }
}
