using chess;
using chess.Board;

internal class Program
{
    private static void Main(string[] args)
    {
        Plank plank;
        plank = new Plank(8, 8);

        Screen.PrintBoard(plank);
        Console.ReadLine();
    }
}