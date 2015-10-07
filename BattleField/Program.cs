namespace BattleField
{
    using System;
    using BattleField.Logic;
    using BattleField.Logic.Utils;

    public class Program
    {
        public static void Main()
        {
            var newGame = new GameInstance(new CellProvider(new CellFactory()));

            var engine = new Core(new LogicController(), new ConsoleReader(), new ConsoleWriter(), newGame);
            engine.Run();
        }
    }
}