﻿namespace BatalFieldLib.Utils
{
    using System;

    using BatalFieldLib.Contracts;

    public class ConsoleReader : IReader
    {
        public int GetIntFromInput(string input, bool coordinateFlag = false)
        {
            int coordFlag = coordinateFlag ? 0 : 1;
            var rowsString = input.Split(' ')[coordFlag];
            var rowsInt = int.Parse(rowsString);
            return rowsInt;
        }

        public string GetInput()
        {
            Console.WriteLine("Please enter coordinates: ");
            string input = Console.ReadLine();

            return input;
        }

        public int TakeFieldSize()
        {
            Console.Write("Enter the size of the battle field: n = ");
            int fieldSize = int.Parse(Console.ReadLine());
            return fieldSize;
        }
    }
}