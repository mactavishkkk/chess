using chess;
using chess.Board;
using chess.Chess;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Plank plank;
            plank = new Plank(8, 8);
            plank.insertPart(new King(plank, Color.White), new Position(0, 4));
            plank.insertPart(new King(plank, Color.Black), new Position(7, 3));

            Screen.PrintBoard(plank);
        } catch (PlankException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}