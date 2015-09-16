using BattleFiled.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFiled.Models
{
    class Mine : IFieldObject
    {
        private int row;
        private int col;
        private byte type;

        public Mine(int row, int col, byte type)
        {
            this.Row = row;
            this.Col = col;
            this.Type = type;
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

        public byte Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }
    }
}
