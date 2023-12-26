using chess.Board;

namespace chess.Chess
{
    internal class Match
    {
        public Plank plank { get; private set; }
        private int turn;
        private Color playerNow;
        public bool finish { get; private set; }

        public Match()
        {
            plank = new Plank(8, 8);
            turn = 1;
            playerNow = Color.White;
            finish = false;
            insertParts();
        }

        public void movimentExecute(Position origin, Position destiny)
        {
            Part part = plank.removePart(origin);
            part.incrementMoviment();
            Part capturedPart = plank.removePart(destiny);
            plank.insertPart(part, destiny);
        }

        private void insertParts()
        {
            plank.insertPart(new Tower(plank, Color.Black), new ChessPosition('A', 8).toPosition());
            plank.insertPart(new Tower(plank, Color.Black), new ChessPosition('H', 8).toPosition());
            plank.insertPart(new Tower(plank, Color.White), new ChessPosition('A', 1).toPosition());
            plank.insertPart(new Tower(plank, Color.White), new ChessPosition('H', 1).toPosition());

            plank.insertPart(new King(plank, Color.Black), new Position(0, 3));
            plank.insertPart(new King(plank, Color.White), new Position(7, 4));
        }
    }
}
