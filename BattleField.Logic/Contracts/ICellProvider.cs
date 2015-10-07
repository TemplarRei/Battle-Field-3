namespace BattleField.Logic.Contracts
{
    public interface ICellProvider
    {
        ICellObject GetCell(string cellType);
    }
}