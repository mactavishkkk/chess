namespace chess.Board
{
    internal class Plank
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Part[,] Parts;

        public Plank(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Parts = new Part[rows, columns];
        }

        public Part getPart(int row, int col)
        {
            return Parts[row, col];
        }

        public Part getPart(Position position)
        {
            return Parts[position.Row, position.Column];
        }

        public bool partExists(Position position)
        {
            validatePosition(position);
            return getPart(position) != null;
        }

        public void insertPart(Part part, Position position)
        {
            if (partExists(position))
                throw new PlankException("Já existe uma peça nesta posição!");

            Parts[position.Row, position.Column] = part;
            part.Position = position;
        }

        public bool validPosition(Position position)
        {
            if (position.Row > 8 || position.Column > 8 || position.Row < 0 || position.Column < 0)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position position)
        {
            if (!validPosition(position))
                throw new PlankException("Posição inválida!");
        }
    }
}
