namespace BattleField.Logic.Models
{
    public class MineFieldCell : FieldCellComponent
    {
        public MineFieldCell(string drawingSign)
            : base(drawingSign)
        {

        }

        public override int Select()
        {
            return int.Parse(this.DrawingSign);
        }
    }
}
