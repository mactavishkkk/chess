using chess.Board;

namespace chess
{
    internal class Screen
    {
        public static void PrintBoard(Plank plank)
        {
            for (int i = 0; i < plank.Rows; i++)
            {
                for (int j = 0; j < plank.Columns; j++)
                {
                    if (plank.getPart(i, j) == null)
                        Console.Write(" - ");
                    else
                        Console.Write(plank.getPart(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
