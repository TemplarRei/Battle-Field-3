using BattleField.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField.Logic.Contracts
{
    public interface IGameObject
    {
        int Size { get; set; }
        FieldCellComponent[,] Field { get; set; }
        IFieldCellFactory Factory { get; set; }
        void FieldInit();
    }
}
