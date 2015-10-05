using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.Logic.Utils
{
    public class MineFieldCell : FieldCellComponent
    {
        public MineFieldCell(string drawingSign)
            : base(drawingSign)
        {

        }

        public override int Select()
        {
            return int.Parse(this.DrawingSign);
            // Explode
            //throw new NotImplementedException();
        }
    }
}
