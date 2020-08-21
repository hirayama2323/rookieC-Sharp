using System;

namespace RookieC_Sharp
{
    public static class View
    {
        public static void bordview(string[,] rows)
        {
            for (int i = 0; i < rows.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < rows.GetLength(1); j++)
                {
                    if (rows[i,j] == Rows.Circle.ToString())
                    {
                        Console.Write("〇|");
                    }
                    else if (rows[i,j] == Rows.Cross.ToString())
                    {
                        Console.Write("×|");
                    }
                    else
                    {
                        Console.Write("|");
                    }
                    
                }
                Console.WriteLine("");
            }
            
        }
}
    }
