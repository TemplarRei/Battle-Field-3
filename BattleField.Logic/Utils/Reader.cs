namespace BattleField.Logic.Utils
{
    using static System.Console;

    using Contracts;

    public class ConsoleReader :IReader
    {

        public string GetInput()
        {
            string input = ReadLine();
            return input;
        }

        public int TakeFieldSize()
        {
            int fieldSize = int.Parse(ReadLine());
            return fieldSize;
        }
    }
}
