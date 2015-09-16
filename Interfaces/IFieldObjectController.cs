namespace BattleFiled.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Models;

    interface IFieldObjectController
    {
        IFieldObject Create(int x, int y);
        void Delete(Mine mineToDelete);
    }
}