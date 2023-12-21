using chess.Board;

namespace chess
{
    internal class Screen
    {
        public static void PrintBoard(Plank plank)
        {
            for (int i = 0; i < plank.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < plank.Columns; j++)
                {
                    if (plank.getPart(i, j) == null)
                        Console.Write("- ");
                    else
                        printPart(plank.getPart(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void printPart(Part part)
        {
            if (part.Color == Color.White)
            {
                Console.Write(part);
                Console.Write(" ");
            } else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(part);
                Console.Write(" ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
