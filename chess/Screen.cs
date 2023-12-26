using chess.Board;
using chess.Chess;
using System.Numerics;

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
                    PrintPart(plank.getPart(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Plank plank, bool[,] possiblePositions)
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor backgroundAlter = ConsoleColor.DarkGray;

            for (int i = 0; i < plank.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < plank.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = backgroundAlter;
                    } else
                    {
                        Console.BackgroundColor = backgroundDefault;
                    }
                    PrintPart(plank.getPart(i, j));
                }
                Console.WriteLine();
                Console.BackgroundColor = backgroundDefault;
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPart(Part part)
        {
            if (part == null)
            {
                Console.Write("- ");
            } else
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

        public static ChessPosition ReadChessPosition()
        {
            string str = Console.ReadLine();
            char column = str[0];
            int row = int.Parse(str[1] + "");
            return new ChessPosition(column, row);
        }
    }
}
