namespace chess.Board
{
    internal class Plank
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Part[,] Parts;

        public Plank (int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Parts = new Part[rows, columns];
        }

        public Part getPart(int row, int col)
        {
            return Parts[row, col];
        }
    }
}
