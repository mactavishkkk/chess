using chess.Board;

namespace chess.Chess
{
    internal class Horse : Part
    {
        public Horse(Plank plank, Color color) : base(color, plank) { }

        private bool CanMove(Position position)
        {
            Part part = Board.getPart(position);
            return part == null || part.Color != this.Color;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            // UpL
            position.valueDefine(Position.Row - 2, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            // UpR
            position.valueDefine(Position.Row - 2, Position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            // RightL
            position.valueDefine(Position.Row - 1, Position.Column + 2);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            // RightR
            position.valueDefine(Position.Row + 1, Position.Column + 2);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            // DownL
            position.valueDefine(Position.Row + 2, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            // DownR
            position.valueDefine(Position.Row + 2, Position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            // LeftR
            position.valueDefine(Position.Row - 1, Position.Column - 2);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            // LeftL
            position.valueDefine(Position.Row + 1, Position.Column - 2);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
