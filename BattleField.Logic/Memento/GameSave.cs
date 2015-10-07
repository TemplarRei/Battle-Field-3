namespace BattleField.Logic.Memento
{
    using BattleField.Logic.Contracts;
    public class GameSave
    {
        public string[,] Field { get; set; }

        public int Moves { get; set; }

        public override bool Equals(object obj)
        {
            var objAsGameSave = obj as GameSave;
            if (objAsGameSave == null)
            {
                return false;
            }

            if (objAsGameSave.Moves != this.Moves)
            {
                return false;
            }

            for (int i = 0;i < this.Field.GetLength(0);i++)
            {
                for (int j = 0;j < this.Field.GetLength(1);j++)
                {
                    if (this.Field[i,j] != objAsGameSave.Field[i,j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}