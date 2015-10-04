﻿namespace BattleField
{
    using System;
    using BattleField.Logic;
    using BattleField.Logic.Utils;

    public class Program
    {
        public static void Main()
        {
            var engine = new Core(new LogicController(), new ConsoleReader(), new ConsoleWriter(), new GameObject());
            engine.Run();
        }
    }
}