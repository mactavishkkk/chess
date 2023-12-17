using chess.Board;

namespace chess.Chess
{
    internal class King : Part
    {
        public King(Plank plank, Color color) : base(color, plank) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
