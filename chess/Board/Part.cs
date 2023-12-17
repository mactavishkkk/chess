namespace chess.Board
{
    internal class Part
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
        public Plank Board { get; protected set; }

        public Part(Position position, Color color, Plank board)
        {
            Position = position;
            Color = color;
            Board = board;
            Movements = 0;
        }
    }
}
