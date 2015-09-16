namespace BattleFiled.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models;
    using Interfaces;

    class MineController : IMineController
    {
        public IFieldObject Create(int x, int y)
        {
            throw new NotImplementedException();
        }

        public IFieldObject Create(int x, int y, byte type)
        {
            throw new NotImplementedException();
        }

        public void Delete(Mine mineToDelete)
        {
            throw new NotImplementedException();
        }

        public void Explode(Mine mineToExplode)
        {
            throw new NotImplementedException();
        }
    }
}
