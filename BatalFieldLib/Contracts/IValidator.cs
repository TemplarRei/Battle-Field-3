using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatalFieldLib.Contracts
{
    public interface IValidator
    {
        bool IsValidPlayerMove();
    }
}
