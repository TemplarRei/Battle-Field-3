using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleField.Logic.Contracts;

namespace BattleField.Logic.Memento
{
    internal static class GameInstanceExtensions
    {
        public static GameSave Save(this IGameInstance gameInstance)
        {
            
            var rowCount = gameInstance.Field.GetLength(0);
            var colCount = gameInstance.Field.GetLength(1);

            // TODO: Iplement prototype for ICellObject

            var result = new GameSave() {
                Field = new string[rowCount, colCount],
                Moves = -999
            };

            for (int i = 0;i < rowCount;i++)
            {
                for (int j = 0;j < colCount;j++)
                {
                    result.Field[i, j] = gameInstance.Field[i, j].DrawingSign;
                }
            }

            return result;
        }
    }


}
