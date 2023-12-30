using chess.Board;

namespace chess.Chess
{
    internal class King : Part
    {
        public King(Plank plank, Color color, Match match) : base(color, plank)
        {
            this.Match = match;
        }

        private Match Match;

        private bool CanMove(Position position)
        {
            Part part = Board.getPart(position);
            return part == null || part.Color != this.Color;
        }

        private bool testAvailableTowerForRook(Position position)
        {
            Part part = Board.getPart(position);
            return part != null && part is Tower && part.Color == this.Color && part.Movements == 0;

        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            // Up
            position.valueDefine(Position.Row - 1, Position.Column);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // URD
            position.valueDefine(Position.Row - 1, position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // Right
            position.valueDefine(Position.Row, Position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // LRD
            position.valueDefine(Position.Row + 1, Position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // Down
            position.valueDefine(Position.Row + 1, Position.Column);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // LLD
            position.valueDefine(Position.Row + 1, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // Left
            position.valueDefine(Position.Row, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            // ULD
            position.valueDefine(Position.Row - 1, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            if (Movements == 0 && !Match.check)
            {
                // #Roque-light
                Position towerPosition = new Position(Position.Row, Position.Column + 3);
                if (testAvailableTowerForRook(towerPosition))
                {
                    Position positionHouseOne = new Position(Position.Row, Position.Column + 1);
                    Position positionHouseTwo = new Position(Position.Row, Position.Column + 2);
                    if (Board.getPart(positionHouseOne) == null && Board.getPart(positionHouseTwo) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }

                // #Roque-large
                Position towerPositionLarge = new Position(Position.Row, Position.Column - 4);
                if (testAvailableTowerForRook(towerPositionLarge))
                {
                    Position positionHouseOne = new Position(Position.Row, Position.Column - 1);
                    Position positionHouseTwo = new Position(Position.Row, Position.Column - 2);
                    Position positionHouseThree = new Position(Position.Row, Position.Column - 3);
                    if (Board.getPart(positionHouseOne) == null && Board.getPart(positionHouseTwo) == null
                        && Board.getPart(positionHouseThree) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
