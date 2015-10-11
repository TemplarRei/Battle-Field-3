namespace BattleField.Logic.TreeOfResponsibility
{
    using Contracts;

    public abstract class CommandHandler: ICommandHandler
    {
        private ICommandHandler successor;
        public abstract void HandleCommand(string command);

        public void SetSuccessor(ICommandHandler successor)
        {
            this.successor = successor;
        }

    }
}
