using BattleField.Logic.Utils;
using System;
namespace BattleField.Logic.Contracts
{
    public interface IFieldCellFactory
    {
        FieldCellComponent GetFieldCell(FieldCellType fieldCellType, string minePower = "");
    }
}
