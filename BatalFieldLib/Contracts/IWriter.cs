using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatalFieldLib.Contracts
{
    public interface IWriter
    {
        void PrintField(IGameObject battleField);
        void GameEndMessage(IGameObject battleField, int moveCounter);
    }
}
