using System;

namespace RookieC_Sharp
{
    /// <summary>
    /// 出力用 
    /// </summary>
    public static class View
    {
        /// <summary>
        /// 出力します
        /// </summary>
        /// <param name="bord"></param>
        public static void bordview(Bord bord)
        {
            Console.WriteLine("今はこんな状況です");
            Console.Write("   1");
            for (int k = 2; k <= bord.bord.GetLength(0); k++)
            {
                Console.Write($"  {k}");
            }

            Console.WriteLine("");
            for (int i = 0; i < bord.bord.GetLength(0); i++)
            {
                Console.Write($"{i + 1}|");
                for (int j = 0; j < bord.bord.GetLength(1); j++)
                {
                    if (bord.bord[i, j] == Rows.Circle.ToString())
                    {
                        Console.Write("〇|");
                    }
                    else if (bord.bord[i, j] == Rows.Cross.ToString())
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