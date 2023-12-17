using chess.Board;

namespace chess.Chess
{
    internal class Tower : Part
    {
        public Tower(Plank plank, Color color) : base(color, plank) { }

        public override string ToString()
        {
            return "T";
        }
    }
}
