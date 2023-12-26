using chess.Board;

namespace chess.Chess
{
    internal class King : Part
    {
        public King(Plank plank, Color color) : base(color, plank) { }

        private bool canMove(Position position)
        {
            Part part = Board.getPart(position);
            return part == null || part.Color != this.Color;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            // Up
            position.valueDefine(Position.Row - 1, Position.Column);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // URD
            position.valueDefine(Position.Row - 1, position.Column + 1);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // Right
            position.valueDefine(Position.Row, Position.Column + 1);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // LRD
            position.valueDefine(Position.Row + 1, Position.Column + 1);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // Down
            position.valueDefine(Position.Row + 1, Position.Column);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // LLD
            position.valueDefine(Position.Row + 1, Position.Column - 1);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // Left
            position.valueDefine(Position.Row, Position.Column - 1);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // ULD
            position.valueDefine(Position.Row - 1, Position.Column - 1);
            if (Board.validPosition(position) && canMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
