namespace Game15
{
    using System;
    using System.Linq;

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
                        "Col value cannot be negative.");
                }

                this.col = value;
            }
        }

        public bool CheckNeighbour(Coordinates other)
        {
            if(this.row == other.row && this.col == other.col) 
            {
                throw new ArgumentException("Points cannot dublicate.");  
            }

            bool checkLeft = this.Row == other.Row && this.Col == other.Col - 1;
            bool checkRight = this.Row == other.Row && this.Col == other.Col + 1;
            bool checkTop = this.Row == other.Row - 1 && this.Col == other.Col;
            bool checkBottom = this.Row == other.Row + 1 && this.Col == other.Col;

            if (checkLeft || checkRight || checkTop || checkBottom)
            {
                return true;
            }

            return false;
        }
    }
}
