using System;

namespace MineSweeperUpdated
{
    public class ConsolePrinter
    {
        public static void Print(string[,] gridToPrint)
        {
            Console.WriteLine("Grid Hint: ");
            for (int line = 0; line < gridToPrint.GetLength(0); line++)
            {
                for (int column = 0; column < gridToPrint.GetLength(1); column++)
                {
                    var cell = gridToPrint[line, column];
                    Console.Write(cell);
                }
                Console.WriteLine("");
            }
        }
    }
}