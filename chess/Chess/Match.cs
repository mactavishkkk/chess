using chess.Board;

namespace chess.Chess
{
    internal class Match
    {
        public Plank plank { get; private set; }
        public int turn { get; private set; }
        public Color playerNow;
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

        public void makeMove(Position origin, Position destiny)
        {
            movimentExecute(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position origin)
        {
            if (plank.getPart(origin) == null)
                throw new PlankException("Não existe peça na posição de origem escolhida!");

            if (playerNow != plank.getPart(origin).Color)
                throw new PlankException("A peça de origem escolhida não é sua");

            if (!plank.getPart(origin).possibleMovimentExists())
                throw new PlankException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        private void changePlayer()
        {
            if (playerNow == Color.White)
                playerNow = Color.Black;
            else playerNow = Color.White;
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
