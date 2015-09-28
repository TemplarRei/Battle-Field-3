namespace BatalFieldLib
{
    using System;
    using Contracts;

    public class GameObject : IGameObject
    {
        private Random rng = new Random();

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
            this.AddMines();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
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

            set
            {
                this.field = value;
            }
        }

        public void SetSize(int size)
        {
        }

        public void FillField()
        {
            this.Field = new string[this.Size, this.Size];

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    this.Field[row, col] = FieldDrawingSymbol;
                }
            }
        }

        public void FieldInit()
        {
            Random randomPosition = new Random();

            this.FillField();

            this.AddMines();
        }

        private void AddMines()
        {
            string[] minesArray = { "1", "2", "3", "4", "5" };

            double fifteenPercentNSquared = 0.15 * this.Size * this.Size;
            double thirtyPercenNSquared = 0.3 * this.Size * this.Size;

            int fifteenPercent = Convert.ToInt16(fifteenPercentNSquared);
            int thirtyPercent = Convert.ToInt16(thirtyPercenNSquared);

            int numberOfMines = rng.Next(fifteenPercent, thirtyPercent + 1);

            for (int i = 0; i < numberOfMines; i++)
            {
                int newRow = rng.Next(0, this.Size);
                int newCol = rng.Next(0, this.Size);
                if (this.Field[newRow, newCol] == "-")
                {
                    this.Field[newRow, newCol] = minesArray[rng.Next(0, 5)];
                }
                else
                {
                    numberOfMines--;
                }
            }
        }
    }
}