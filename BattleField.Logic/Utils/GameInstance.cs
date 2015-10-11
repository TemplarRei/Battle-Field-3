namespace BattleField.Logic
{
    using System;

    using Contracts;
    using Models;

    public class GameInstance: IGameInstance
    {
        private const int MinSize = 2;
        private const string FieldDrawingSymbol = "-";

        private static readonly Random RANDOM = new Random();


        private int size;
        private ICellObject[,] field;
        public ICellProvider CellStorage { get; set; }

        public GameInstance(ICellProvider storage)
        {
            this.CellStorage = storage;
        }

        public GameInstance(int size)
        {
            this.Size = size;
            this.field = new ICellObject[this.Size, this.Size];

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
                if(value < MinSize)
                {
                    throw new ArgumentOutOfRangeException(string.Format($"Field size should be more than {MinSize}"));
                }

                this.size = value;
            }
        }

        public ICellObject[,] Field
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
            var emptyFieldCell = this.CellStorage.GetCell("-");
            this.Field = new ICellObject[this.Size, this.Size];

            for(int row = 0; row < this.Size; row++)
            {
                for(int col = 0; col < this.Size; col++)
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



            for(int i = 0; i < numberOfMines; i++)
            {
                int newRow = RANDOM.Next(0, this.Size);
                int newCol = RANDOM.Next(0, this.Size);
                if(this.Field[newRow, newCol] is EmptyFieldCell)
                {
                    var nextMineType = RANDOM.Next(1, 5).ToString();

                    this.Field[newRow, newCol] = this.CellStorage.GetCell(nextMineType);
                }
                else
                {
                    numberOfMines--;
                }
            }
        }
    }
}