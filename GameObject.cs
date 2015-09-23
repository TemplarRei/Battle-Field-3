namespace BattleField
{
    using System;

    public class GameObject
    {
        private const int MinSize = 2;
        private const string FieldDrawingSymbol = "-";
        private int size;
        private string[,] field;

        public GameObject()
        {
            
        }

        public GameObject(int size)
        {
            this.Size = size;
            this.field = new string[this.Size, this.Size];

            Random randomPosition = new Random();
            this.FillField();
            AddMines(this, randomPosition);
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

        public void FillField()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    this.Field[row, col] = FieldDrawingSymbol;
                }
            }
        }

        public GameObject FieldInit(int size)
        {
            var battleField = new GameObject(size);
            Random randomPosition = new Random();

            battleField.FillField();

            AddMines(battleField, randomPosition);

            return battleField;
        }

        private void AddMines(GameObject battleField, Random randomPosition)
        {
            string[] minesArray = { "1", "2", "3", "4", "5" };

            double fifteenPercentNSquared = 0.15 * battleField.Size * battleField.Size;
            double thirtyPercenNSquared = 0.3 * battleField.Size * battleField.Size;

            int fifteenPercent = Convert.ToInt16(fifteenPercentNSquared);
            int thirtyPercent = Convert.ToInt16(thirtyPercenNSquared);

            int numberOfMines = randomPosition.Next(fifteenPercent, thirtyPercent + 1);

            for (int i = 0; i < numberOfMines; i++)
            {
                int newRow = randomPosition.Next(0, battleField.Size);
                int newCol = randomPosition.Next(0, battleField.Size);
                                if (battleField.Field[newRow, newCol] == "-")
                {
                    battleField.Field[newRow, newCol] = minesArray[randomPosition.Next(0, 5)];
                }
                else
                {
                    numberOfMines--;
                }
            }
        }
    }
}