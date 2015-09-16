namespace BattleFiled.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Models;

    interface IMineController: IFieldObjectController
    {
        IFieldObject Create(int x, int y, byte type);
        void Explode(Mine mineToExplode);
    }
}
