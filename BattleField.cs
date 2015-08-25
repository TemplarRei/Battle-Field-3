namespace BattleFiled
{
    using System;

    public class BattleField
    {
        private const int MinSize = 2;
        private const string FieldDrawingSymbol = "-";
        private int size;
        private string[,] field;

        public BattleField(int size)
        {
            this.Size = size;
            this.field = new string[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < MinSize)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Field size should be more than {0}", MinSize));
                }

                this.size = value;
            }
        }

        public string[,] Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }

        public void DrawField()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    this.Field[row, col] = FieldDrawingSymbol;
                }
            }
        }
    }
}