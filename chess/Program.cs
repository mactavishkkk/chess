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
                Console.Clear();
                Screen.PrintBoard(match.plank);

                Console.WriteLine();

                Console.Write("Origem: ");
                Position origin = Screen.ReadChessPosition().toPosition();

                bool[,] possiblePositions = match.plank.getPart(origin).possibleMoviments();

                Console.Clear();
                Screen.PrintBoard(match.plank, possiblePositions);

                Console.WriteLine();

                Console.Write("Destino: ");
                Position destiny = Screen.ReadChessPosition().toPosition();

                match.movimentExecute(origin, destiny);
            }
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}