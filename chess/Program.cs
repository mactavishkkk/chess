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
                    Screen.PrintBoard(match.plank);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + match.turn);

                    if (match.playerNow == Color.White)
                        Console.WriteLine("Aguardando jogada das peças BRANCAS");
                    else Console.WriteLine("Aguardando jogada das peças PRETAS");

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