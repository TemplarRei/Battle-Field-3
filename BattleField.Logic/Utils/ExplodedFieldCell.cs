using BattleField.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.Logic.Utils
{
    public class ExplodedFieldCell : FieldCellComponent
    {
        public ExplodedFieldCell()
            : base(GlobalConstants.EXPLODED_FIELD_CELL_DRAWING_SIGN)
        {

        }
    }
}
