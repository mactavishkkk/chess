using chess;
using chess.Board;
using chess.Chess;

internal class Program
{
    private static void Main(string[] args)
    {
        Match match = new Match();
        Screen.PrintBoard(match.plank);
    }
}