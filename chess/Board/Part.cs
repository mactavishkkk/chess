namespace chess.Board
{
    internal abstract class Part
    {
        public Position Position = new Position();
        public Color Color { get; protected set; }
        public Plank Board { get; protected set; }
        public int Movements { get; protected set; }

        public Part(Color color, Plank board)
        {
            Color = color;
            Board = board;
            Movements = 0;
        }

        public void incrementMoviment()
        {
            Movements++;
        }

        public void decrementMoviment()
        {
            Movements--;
        }

        public bool possibleMovimentExists()
        {
            bool[,] mat = possibleMoviments();

            for (int i = 0; i < Board.Rows; i++)
                for (int j = 0; j < Board.Columns; j++)
                    if (mat[i, j])
                        return true;

            return false;

        }

        public bool possibleMoviment(Position position)
        {
            return possibleMoviments()[position.Row, position.Column];
        }

        public abstract bool[,] possibleMoviments();
    }
}
