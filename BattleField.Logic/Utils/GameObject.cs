namespace BattleField.Logic
{
    using System;
    using Contracts;
    using BattleField.Logic.Utils;

    public class GameObject : IGameObject
    {
        private Random rng = new Random();

        private const int MinSize = 2;
        private const string FieldDrawingSymbol = "-";
        private int size;
        private FieldCellComponent[,] field;

        public GameObject()
        {

        }

        public GameObject(int size)
        {
            this.Size = size;
            this.field = new FieldCellComponent[this.Size, this.Size];

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

        public FieldCellComponent[,] Field
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
            this.Field = new FieldCellComponent[this.Size, this.Size];

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    this.Field[row, col] = new EmptyFieldCell();
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
                if (this.Field[newRow, newCol] is EmptyFieldCell)
                {
                    this.Field[newRow, newCol] = new MineFieldCell(minesArray[rng.Next(0, 5)]);
                }
                else
                {
                    numberOfMines--;
                }
            }
        }
    }
}