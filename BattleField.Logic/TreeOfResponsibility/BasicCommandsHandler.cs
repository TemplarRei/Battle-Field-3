namespace BattleField.Logic.TreeOfResponsibility
{
    using System;
    using Contracts;

    class BasicCommandsHandler: CommandHandler, ICommandHandler
    {
        public override void HandleCommand(string command)
        {
            if(command == "undo" || command == "redo")
            {
                // TODO - finish
            }
        }
    }
}
