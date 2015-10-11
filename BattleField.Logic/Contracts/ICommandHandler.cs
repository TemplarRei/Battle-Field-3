namespace BattleField.Logic.Contracts
{
    public interface ICommandHandler
    {
        ICommandHandler Successor { get; set; }

        void HandleCommand(string command);
    }
}
