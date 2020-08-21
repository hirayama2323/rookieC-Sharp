using System;
using System.Collections.Generic;
using System.Linq;

namespace RookieC_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] bord;
            bord = new string[5,5];
            int[] innum;
            innum = input();
            Console.WriteLine(innum[0] + "平山" + innum[1]);
            // bord = TestView.testview();
            // View.bordview(bord);
            

        }

        static int[] input()
        {
            string str;
            int[] result;
            Console.WriteLine("書きたい場所を指定してください");
            str = Console.ReadLine();
                result = str
                .Split(',')
                .Select(a => int.Parse(a))
                .ToArray();
            return result;
        }

    }
}