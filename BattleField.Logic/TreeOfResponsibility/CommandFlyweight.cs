namespace BattleField.Logic.TreeOfResponsibility
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    class CommandFlyweight: ICommandProvider
    {
        private ICommandProvider factory;
        private IDictionary<string, ICommandHandler> commandsInUse;

        public CommandFlyweight()
        {
            this.factory = new CommandFactory();
            this.commandsInUse = new Dictionary<string, ICommandHandler>();
        }

        public ICommandHandler GetCommand(string command)
        {
            if(this.commandsInUse.ContainsKey(command))
            {
                return this.commandsInUse[command];
            }

            return factory.GetCommand(command);
        }
    }

    //private ICellProvider Factory;
    //private IDictionary<string, ICellObject> cellsInUse;

    //public CellProvider(ICellProvider factory)
    //{
    //    this.Factory = factory;
    //    this.cellsInUse = new Dictionary<string, ICellObject>();
    //}

    //public ICellObject GetCell(string type)
    //{
    //    if(this.cellsInUse.ContainsKey(type))
    //    {
    //        return this.cellsInUse[type];
    //    }

    //    var newCell = this.Factory.GetCell(type);

    //    return newCell;
    //}
}
