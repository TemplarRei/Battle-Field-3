using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFiled
{
    class BattleField
    {
        static void Main(string[] args)
        {
            int fieldSize;
            string[,] battleField;
            GameProcessess.BoardInit(out fieldSize, out battleField);
            GameProcessess.GameTurns(fieldSize, battleField);
        }
    }
}
