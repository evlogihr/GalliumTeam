using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game15
{
    public class Coordinates
    {
        private int row;
        private int col;

        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get 
            { 
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Row value cannot be negative.");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Row value cannot be negative.");
                }

                this.col = value; 
            }
        }

        public bool CheckNeighbour(Coordinates other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other elemntt cannot be null.");
            }

            if (row == other.row && (col == other.col + 1 || col == other.col - 1))
            {
                return true;
            }
            if ((row == other.row + 1 || row == other.row - 1) && col == other.col)
            {
                return true;
            }
            return false;
        }
    }
}
