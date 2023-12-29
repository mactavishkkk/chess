using chess.Board;

namespace chess.Chess
{
    internal class Match
    {
        public Plank plank { get; private set; }
        public int turn { get; private set; }
        public Color playerNow;
        public bool finish { get; private set; }
        public bool check { get; private set; }
        private HashSet<Part> parts;
        private HashSet<Part> capturedsParts;

        public Match()
        {
            plank = new Plank(8, 8);
            turn = 1;
            playerNow = Color.White;
            finish = false;
            parts = new HashSet<Part>();
            capturedsParts = new HashSet<Part>();
            insertParts();
        }

        public Part movimentExecute(Position origin, Position destiny)
        {
            Part part = plank.removePart(origin);
            part.incrementMoviment();
            Part capturedPart = plank.removePart(destiny);
            plank.insertPart(part, destiny);

            if (capturedPart != null)
                capturedsParts.Add(capturedPart);

            return capturedPart;
        }

        public void undoMove(Position origin, Position destiny, Part capturedPart)
        {
            Part part = plank.removePart(destiny);
            part.decrementMoviment();

            if (capturedPart != null)
            {
                plank.insertPart(capturedPart, destiny);
                capturedsParts.Remove(capturedPart);
            }
            plank.insertPart(part, origin);
        }

        public void makeMove(Position origin, Position destiny)
        {
            Part capturedPart = movimentExecute(origin, destiny);
            if (itsInCheck(playerNow))
            {
                undoMove(origin, destiny, capturedPart);
                throw new PlankException("Você não pode se colocar em xeque!");
            }

            if (itsInCheck(adversary(playerNow)))
                check = true;
            else check = false;

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

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!plank.getPart(origin).canMoveTo(destiny))
                throw new PlankException("Posição de destino inválida!");
        }

        private void changePlayer()
        {
            if (playerNow == Color.White)
                playerNow = Color.Black;
            else playerNow = Color.White;
        }

        public HashSet<Part> partsInGame(Color color)
        {
            HashSet<Part> aux = new HashSet<Part>();
            foreach (Part part in parts)
            {
                if (part.Color == color)
                {
                    aux.Add(part);
                }
            }
            aux.ExceptWith(capturedParts(color));
            return aux;
        }

        private Color adversary(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Part selectKing(Color color)
        {
            foreach (Part part in partsInGame(color))
                if (part is King)
                    return part;

            return null;
        }

        public bool itsInCheck(Color color)
        {
            Part king = selectKing(color);
            if (king == null)
                throw new PlankException("Não existe um rei da cor: " + color + " no tabuleiro!");

            foreach (Part part in partsInGame(adversary(color)))
            {
                bool[,] mat = part.possibleMoviments();
                if (mat[king.Position.Row, king.Position.Column])
                    return true;

            }
            return false;


        }

        public HashSet<Part> capturedParts(Color color)
        {
            HashSet<Part> aux = new HashSet<Part>();
            foreach (Part part in capturedsParts)
            {
                if (part.Color == color)
                {
                    aux.Add(part);
                }
            }
            return aux;
        }

        public void insertNewPart(char column, int row, Part part)
        {
            plank.insertPart(part, new ChessPosition(column, row).toPosition());
            parts.Add(part);
        }

        private void insertParts()
        {
            insertNewPart('A', 8, new Tower(plank, Color.Black));
            insertNewPart('H', 8, new Tower(plank, Color.Black));
            insertNewPart('A', 1, new Tower(plank, Color.White));
            insertNewPart('H', 1, new Tower(plank, Color.White));

            insertNewPart('D', 8, new King(plank, Color.Black));
            insertNewPart('E', 1, new King(plank, Color.White));
        }
    }
}
