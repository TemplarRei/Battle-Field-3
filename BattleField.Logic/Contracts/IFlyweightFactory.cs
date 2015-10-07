namespace BattleField.Logic.Contracts
{
    public interface IFlyweightFactory
    {
        ICellObject GetCell(string cellType);
    }
}
