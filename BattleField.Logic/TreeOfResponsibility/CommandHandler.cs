namespace BattleField.Logic.TreeOfResponsibility
{
    using System;
    using Contracts;

    public abstract class CommandHandler: ICommandHandler
    {
        private ICommandHandler successor;

        public ICommandHandler Successor
        {
            get
            {
                return successor;
            }

            set
            {
                this.successor = value;
            }
        }

        public abstract void HandleCommand(string command);

        
    }
}
