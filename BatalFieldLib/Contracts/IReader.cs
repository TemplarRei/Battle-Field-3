using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatalFieldLib.Contracts
{
    public interface IReader
    {
        string GetInput();
        int GetIntFromInput(string input, bool coordinateFlag = false);
        int TakeFieldSize();
    }
}
