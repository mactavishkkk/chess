using chess.Board;

namespace chess.Chess
{
    internal class Bishop : Part
    {
        public Bishop(Plank plank, Color color) : base(color, plank) { }

        private bool CanMove(Position position)
        {
            Part part = Board.getPart(position);
            return part == null || part.Color != this.Color;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            //DUpR
            position.valueDefine(Position.Row - 1, Position.Column + 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.getPart(position) != null && Board.getPart(position).Color != Color)
                {
                    break;
                }
                position.valueDefine(position.Row - 1, position.Column + 1);
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
                position.valueDefine(position.Row - 1, position.Column - 1);
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
                position.valueDefine(position.Row + 1, position.Column + 1);
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
                position.valueDefine(position.Row + 1, position.Column - 1);
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
