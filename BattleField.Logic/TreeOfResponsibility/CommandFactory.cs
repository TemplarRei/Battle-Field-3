using System;
using BattleField.Logic.Contracts;

namespace BattleField.Logic.TreeOfResponsibility
{
    internal class CommandFactory: ICommandProvider
    {
        public ICommandHandler GetCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}