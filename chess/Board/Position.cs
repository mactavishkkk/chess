namespace chess.Board
{
    internal class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Position() { }

        public void valueDefine(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return "Linha: " + Row + ", Coluna: " + Column;
        }
    }
}
