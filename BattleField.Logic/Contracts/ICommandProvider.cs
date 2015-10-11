namespace BattleField.Logic.Contracts
{
    public interface ICommandProvider
    {
        ICommandHandler GetCommand(string command);
    }
}
