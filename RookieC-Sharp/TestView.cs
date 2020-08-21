using System;

namespace RookieC_Sharp
{
    public static class TestView
    {
        public static string[,] testview()
        {
            int i, j;
            string[,] bord;
            bord = new string[5,5];
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    bord[i, j] = Rows.Circle.ToString();
                }
                
            }
            return bord;
        }
    }
}