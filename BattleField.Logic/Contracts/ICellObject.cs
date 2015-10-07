namespace BattleField.Logic.Contracts
{
    public interface ICellObject
    {
        string DrawingSign { get; set; }

        int Select();
    }
}
