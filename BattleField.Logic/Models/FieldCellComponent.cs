namespace BattleField.Logic.Models
{
    using BattleField.Logic.Contracts;

    public abstract class FieldCellComponent: ICellObject
    {
        protected FieldCellComponent(string drawingSign)
        {
            this.DrawingSign = drawingSign;
        }

        public string DrawingSign { get; set; }

        public virtual int Select()
        {
            return 0;
        }
    }
}