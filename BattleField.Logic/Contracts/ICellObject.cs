using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.Logic.Contracts
{
    public interface ICellObject
    {
        string DrawingSign { get; set; }

        int Select();
    }
}
