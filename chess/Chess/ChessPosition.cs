using chess.Board;

namespace chess.Chess
{
    internal class ChessPosition
    {
        private char Column { get; set; }
        private int Row { get; set; }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position toPosition()
        {
            return new Position(8 - Row, Column - 'A');
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
