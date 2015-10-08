namespace BattleField
{
    using Logic;
    using Logic.Memento;
    using Logic.Utils;

    public class Program
    {
        public static void Main()
        {
            var newGame = new GameInstance(new CellProvider(new CellFactory()));

            var engine = new Core(new LogicController(), new ConsoleReader(), new ConsoleWriter(), new GameSaver(), newGame);
            engine.Run();
        }
    }
}