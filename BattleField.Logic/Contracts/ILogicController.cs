using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.Logic.Contracts
{
    public interface ILogicController
    {
        int GetMine(IGameObject battleField, int row, int col);
        void FieldUpdate(int row, int col, IGameObject battleField,IFieldCellFactory factory);
        bool EndOfGameCheck(int fieldSize, IGameObject battleField);
    }
}
