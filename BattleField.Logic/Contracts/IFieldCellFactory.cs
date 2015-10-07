using BattleField.Logic.Utils;
using System;
namespace BattleField.Logic.Contracts
{
    public interface ICellFactory
    {
        FieldCellComponent GetFieldCell(FieldCellType fieldCellType);
    }
}
