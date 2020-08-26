using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RookieC_Sharp
{
    /// <summary>
    /// 〇と✕を列挙型で列挙しておきます
    /// </summary>
    public enum Rows
    {
        Circle, //まる
        Cross //ばつ
    }

    
    /// <summary>
    ///  人を作ります
    /// </summary>
    public class Human
    {
        
        public string Name { get; set; }

        protected int Age { get; set; }

        public Rows Rows { get; set; }

        public bool victory { get; set; }


        /// <summary>
        /// 名前の入力を促すメソッド
        /// </summary>
        /// <param name="readLine"></param>
        public void nameinput(string readLine)
        {
            this.Name = readLine;
        }

        
        /// <summary>
        /// このメソッドで入力を促します
        /// </summary>
        /// <param name="bord"></param>
        /// <returns>妥当性確認された行列の数字が返ります</returns>
        public int[] putinput(string[,] bord)
        {
            string str;
            int[] result;
            Console.WriteLine($"{Name}さんの番です。");
            Console.WriteLine("行,列の形で入力してください");
            str = Console.ReadLine();
            // 入力を間違う回数がわからないので無限ループにしました
            while (true)
            {
                // 正規表現で入力チェック　正規表現なんとなくわかってきた
                if (Regex.IsMatch(str, "^[1-" + bord.GetLength(0) + "],[1-" + bord.GetLength(1) + "]$"))
                {
                    // 文字列をカンマを基準にバラします
                    // こういうのLinQと言うらしい　おしゃれ
                    result = str
                        .Split(',')
                        .Select(a => int.Parse(a))
                        .ToArray();
                    // 配列の添え字と対応するように減算します
                    result[1] -= 1;
                    result[0] -= 1;
                    // すでに書かれていたらもう一度入力を促す
                    if (bord[result[0], result[1]] != null)
                    {
                        Console.WriteLine("そこにはすでにコマが書かれています");
                        Console.WriteLine("行,列の形で入力してください");
                        str = Console.ReadLine();
                        continue;
                    }

                    break;
                }

                Console.WriteLine("入力値が不正です");
                Console.WriteLine("行,列の形で入力してください");
                str = Console.ReadLine();
            }

            return result;
        }
    }
}