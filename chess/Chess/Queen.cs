using chess.Board;

namespace chess.Chess
{
    internal class Queen : Part
    {
        public Queen(Plank plank, Color color) : base(color, plank) { }

        private bool CanMove(Position position)
        {
            Part part = Board.getPart(position);
            return part == null || part.Color != this.Color;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            //Up
            position.valueDefine(Position.Row - 1, Position.Column);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Row--;
            }

            //DUpR
            position.valueDefine(Position.Row - 1, Position.Column + 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Row--;
                position.Column++;
            }

            // Right
            position.valueDefine(Position.Row, Position.Column + 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Column++;
            }

            //DDownR
            position.valueDefine(Position.Row + 1, Position.Column + 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Row++;
                position.Column++;
            }

            // Down
            position.valueDefine(Position.Row + 1, Position.Column);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Row++;
            }

            //DDownL
            position.valueDefine(Position.Row + 1, Position.Column - 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Row++;
                position.Column--;
            }

            // Left
            position.valueDefine(Position.Row, Position.Column - 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Column--;
            }

            //DUpL
            position.valueDefine(Position.Row - 1, Position.Column - 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.Row--;
                position.Column--;
            }

            return mat;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
