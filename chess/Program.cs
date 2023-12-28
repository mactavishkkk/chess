using chess;
using chess.Board;
using chess.Chess;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Match match = new Match();
            while (!match.finish)
            {
                try
                {
                    Console.Clear();
                    Screen.printHud(match);

                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().toPosition();
                    match.validateOriginPosition(origin);

                    bool[,] possiblePositions = match.plank.getPart(origin).possibleMoviments();

                    Console.Clear();
                    Screen.PrintBoard(match.plank, possiblePositions);

                    Console.WriteLine();

                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadChessPosition().toPosition();
                    match.validateDestinyPosition(origin, destiny);

                    match.makeMove(origin, destiny);
                } catch (PlankException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Pressione 'Enter' para tentar novamente");
                    Console.ReadLine();
                }
            }
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}