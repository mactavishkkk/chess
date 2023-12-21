namespace chess.Board
{
    internal class Part
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
    }
}
