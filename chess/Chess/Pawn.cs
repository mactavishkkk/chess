using chess.Board;
using System;
namespace chess.Chess
{
    internal class Pawn : Part
    {
        public Pawn(Plank plank, Color color, Match match) : base(color, plank)
        {
            this.Match = match;
        }

        private Match Match;

        private bool CanMove(Position position)
        {
            Part part = Board.getPart(position);
            return part == null || part.Color != this.Color;
        }

        public bool enemyExists(Position position)
        {
            Part part = Board.getPart(position);
            return part != null && part.Color != Color;
        }

        public bool free(Position position)
        {
            return Board.getPart(position) == null;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.valueDefine(Position.Row - 1, Position.Column);
                if (Board.validPosition(position) && free(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.valueDefine(Position.Row - 2, Position.Column);
                if (Board.validPosition(position) && free(position) && Movements == 0)
                {
                    mat[position.Row, position.Column] = true;
                }

                position.valueDefine(Position.Row - 1, Position.Column - 1);
                if (Board.validPosition(position) && enemyExists(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.valueDefine(Position.Row - 1, Position.Column + 1);
                if (Board.validPosition(position) && enemyExists(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                // # En Passant
                if (Position.Row == 3)
                {
                    Position partLeft = new Position(Position.Row, Position.Column - 1);
                    if (Board.validPosition(partLeft) && enemyExists(partLeft) && Board.getPart(partLeft) == Match.partEnPassant)
                    {
                        mat[partLeft.Row - 1, partLeft.Column] = true;
                    }

                    Position partRight = new Position(Position.Row, Position.Column + 1);
                    if (Board.validPosition(partRight) && enemyExists(partRight) && Board.getPart(partRight) == Match.partEnPassant)
                    {
                        mat[partRight.Row - 1, partRight.Column] = true;
                    }
                }
            } else
            {
                position.valueDefine(Position.Row + 1, Position.Column);
                if (Board.validPosition(position) && free(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.valueDefine(Position.Row + 2, Position.Column);
                if (Board.validPosition(position) && free(position) && Movements == 0)
                {
                    mat[position.Row, position.Column] = true;
                }

                position.valueDefine(Position.Row + 1, Position.Column - 1);
                if (Board.validPosition(position) && enemyExists(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.valueDefine(Position.Row + 1, Position.Column + 1);
                if (Board.validPosition(position) && enemyExists(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                // # En Passant
                if (Position.Row == 4)
                {
                    Position partLeft = new Position(Position.Row, Position.Column - 1);
                    if (Board.validPosition(partLeft) && enemyExists(partLeft) && Board.getPart(partLeft) == Match.partEnPassant)
                    {
                        mat[partLeft.Row + 1, partLeft.Column] = true;
                    }

                    Position partRight = new Position(Position.Row, Position.Column + 1);
                    if (Board.validPosition(partRight) && enemyExists(partRight) && Board.getPart(partRight) == Match.partEnPassant)
                    {
                        mat[partRight.Row + 1, partRight.Column] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
