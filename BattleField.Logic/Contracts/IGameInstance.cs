using BattleField.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField.Logic.Contracts
{
    public interface IGameInstance
    {
        int Size { get; set; }
        ICellObject[,] Field { get; set; }
        IFlyweightFactory CellStorage { get; set; }
        void FieldInit();
    }
}
