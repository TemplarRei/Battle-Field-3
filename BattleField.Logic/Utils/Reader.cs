namespace BattleField.Logic.Utils
{
    using System;

    using BattleField.Logic.Contracts;

    public class ConsoleReader : IReader
    {
        
        public string GetInput()
        {
            string input = Console.ReadLine();

            return input;
        }

        public int TakeFieldSize()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            return fieldSize;
        }
    }
}
