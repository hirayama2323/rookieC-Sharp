using System;

namespace RookieC_Sharp
{
    /*    出力用    */
    public static class View
    {
        public static void bordview(string[,] rows)
        {
            Console.WriteLine("今はこんな状況です");
            for (int i = 0; i < rows.GetLength(0); i++)
            {
                if (i==0)
                {
                    Console.WriteLine("   1  2  3  4  5");
                }
                Console.Write($"{i+1}|");
                for (int j = 0; j < rows.GetLength(1); j++)
                {
                    if (rows[i,j] == Rows.Circle.ToString())
                    {
                        Console.Write("〇|");
                    }
                    else if (rows[i,j] == Rows.Cross.ToString())
                    {
                        Console.Write("Ｘ|");
                    }
                    else
                    {
                        Console.Write("　|");
                    }
                    
                }
                Console.WriteLine("");
            }
            
        }
}
    }
