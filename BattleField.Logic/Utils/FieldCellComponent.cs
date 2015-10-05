using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.Logic.Utils
{
    public abstract class FieldCellComponent
    {
        protected FieldCellComponent(string drawingSign)
        {
            this.DrawingSign = drawingSign;
        }

        public string DrawingSign { get; set; }

        public virtual int Select()
        {
            return 0;
        }
    }
}
