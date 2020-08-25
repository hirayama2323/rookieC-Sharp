using System;
using System.Linq;
using System.Text.RegularExpressions;
using RookieC_Sharp;

namespace RookieC_Sharp
{
    /*    盤を作成するクラス    */
    public class Bord
    {
        //盤の大きさを設定する変数
        public int size { get; set; }

        //盤の二次元配列　半可変
        public string[,] bord { get; set; }

        //1～6までの数値以外ははじくクラス
        public bool checknumber(string str)
        {
            if (Regex.IsMatch(str, "^[1-6]$"))
            {
                return true;
            }

            return false;
        }

        public void sizeinput()
        {
            string str;
            do
            {
                Console.WriteLine("何個並んだら勝ちにしますか？\n※ 1～6の間でお願いします");
                str = Console.ReadLine();
                if (checknumber(str))
                {
                    Console.WriteLine($"{str}目並べを始めます");
                    this.size = Convert.ToInt32(str);
                    bord = new string[size + 2,size + 2];
                    return;
                }
                Console.WriteLine("入力値が不正です");
            } while (true);
        }
    }
}