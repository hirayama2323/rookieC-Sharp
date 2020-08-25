using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RookieC_Sharp
{
    public enum Rows
    {
        Circle, //まる
        Cross //ばつ
    }

    /*    人を作ります    */
    public class Human
    {
        public string Name { get; set; }

        protected int Age { get; set; }

        public Rows Rows { get; set; }

        public bool victory { get; set; }

        //名前の入力を促すメソッド
        public void nameinput()
        {
            Console.WriteLine($"{Rows}を使用する方の名前を入力してください");
            this.Name = Console.ReadLine();
        }

        //このメソッドで入力を促します
        public int[] putinput(string[,] bord)
        {
            /*
             * @param str 一時的に入力された文字列を格納する箱
             * @param result 入力された文字列を数値にして格納する箱
             */
            string str;
            int[] result;
            Console.WriteLine($"{Name}さんの番です。");
            Console.WriteLine("行,列の形で入力してください");
            str = Console.ReadLine();
            //入力を間違う回数がわからないので無限ループにしました
            while (true)
            {
                //正規表現で入力チェック　正規表現なんとなくわかってきた
                if (Regex.IsMatch(str, "^[1-" + bord.GetLength(0) + "],[1-" + bord.GetLength(1) + "]$"))
                {
                    //文字列をカンマを基準にバラします
                    //こういうのLinQと言うらしい　おしゃれ
                    result = str
                        .Split(',')
                        .Select(a => int.Parse(a))
                        .ToArray();
                    //配列の添え字と対応するように減算します
                    result[1] -= 1;
                    result[0] -= 1;
                    //すでに書かれていたらもう一度入力を促す
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