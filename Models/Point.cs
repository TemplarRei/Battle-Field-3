namespace BattleFiled.Models
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BattleFiled.Interfaces;

    class Point : IFieldObject
    {
        private int col;
        private int row;

        public Point(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                this.col = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                this.row = value;
            }
        }
    }
}
