using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField.Logic.Contracts
{
    public interface IValidator
    {
        bool IsValidPlayerMove();
    }
}
