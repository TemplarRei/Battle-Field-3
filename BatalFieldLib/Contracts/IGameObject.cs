using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatalFieldLib.Contracts
{
    public interface IGameObject
    {
        int Size { get; set; }
        string[,] Field { get; set; }
        void FieldInit();
    }
}
