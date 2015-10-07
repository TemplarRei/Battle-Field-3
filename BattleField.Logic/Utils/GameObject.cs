namespace BattleField.Logic
{
    using System;
    using BattleField.Logic.Contracts;
    using BattleField.Logic.Utils;

    public class GameObject : IGameObject
    {
        private const int MinSize = 2;
        private const string FieldDrawingSymbol = "-";
        private int size;
        private FieldCellComponent[,] field;
        private static readonly Random RANDOM = new Random();
        public ICellFactory Factory { get; set; }

        public GameObject(ICellFactory factory)
        {
            this.Factory = factory;
        }

        public GameObject(int size)
        {
            this.Size = size;
            this.field = new FieldCellComponent[this.Size, this.Size];

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
            // TODO : FLYWEIGHT PATTERN
            var emptyFieldCell = this.Factory.GetFieldCell(FieldCellType.EmptyFieldCell);
            this.Field = new FieldCellComponent[this.Size, this.Size];

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    this.Field[row, col] = emptyFieldCell;
                }
            }
        }

        public void FieldInit()
        {
            this.FillField();
            this.AddMines();
        }

        private void AddMines()
        {

            double fifteenPercentNSquared = 0.15 * this.Size * this.Size;
            double thirtyPercenNSquared = 0.3 * this.Size * this.Size;

            int fifteenPercent = Convert.ToInt16(fifteenPercentNSquared);
            int thirtyPercent = Convert.ToInt16(thirtyPercenNSquared);

            int numberOfMines = RANDOM.Next(fifteenPercent, thirtyPercent + 1);



            for (int i = 0; i < numberOfMines; i++)
            {
                int newRow = RANDOM.Next(0, this.Size);
                int newCol = RANDOM.Next(0, this.Size);
                if (this.Field[newRow, newCol] is EmptyFieldCell)
                {
                    //this.Field[newRow, newCol] = new MineFieldCell(minesArray[rng.Next(0, 5)]);
                    this.Field[newRow, newCol] = this.Factory.GetFieldCell(FieldCellType.MineFieldCell);
                }
                else
                {
                    numberOfMines--;
                }
            }
        }
    }
}