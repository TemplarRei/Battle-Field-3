namespace BattleField.Logic.Contracts
{
    public interface ICellFactory
    {
        ICellObject GetCell(string type);
    }
}
