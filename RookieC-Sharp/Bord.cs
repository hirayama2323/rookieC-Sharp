using System;
using System.Linq;
using System.Text.RegularExpressions;
using RookieC_Sharp;

namespace RookieC_Sharp
{
    /// <summary>
    /// 盤を作成するクラス
    /// </summary>
    public class Bord
    {
        // 盤の大きさを設定する変数
        public int size { get; set; }

        // 盤の二次元配列　半可変
        public string[,] bord { get; set; }

        /// <summary>
        /// 1～6までの数値以外ははじくクラス
        /// </summary>
        /// <param name="str"></param>
        /// <returns>チェックしてOKならtrueを返します</returns>
        public bool checknumber(string str)
        {
            // if (Regex.IsMatch(str, "^[1-6]$"))
            // {
            //     return true;
            // }
            //
            // return false;

            // 条件演算子とか三項演算子というらしい
            // <条件式> ? true:false;
            return Regex.IsMatch(str, "^[2-6]$") ? true : false;
        }

        /// <summary>
        /// 何目並べをやりたいかを伺うクラス
        /// ここでついでに盤も作ってます
        /// </summary>
        public bool sizeinput(string str)
        {
            // do
            // {
            //ここmain
            // Console.WriteLine("何個並んだら勝ちにしますか？\n※ 2～6の間でお願いします");
            // str = Console.ReadLine();

            if (checknumber(str))
            {
                Console.WriteLine($"{str}目並べを始めます");
                this.size = Convert.ToInt32(str);
                this.bord = new string[size + 2, size + 2];
                return true;
            }

            return false;

            // Console.WriteLine("入力値が不正です");
            // } while (true);
        }

        public void rule(Human human)
        {
            Check check = new Check();
            Jugement jugement = new Jugement();

            Bord tmpbord = new Bord();
            tmpbord.size = size;
            tmpbord.bord = bord;
            View.bordview(tmpbord);
            // 置きたい場所を入力させます
            int[] num = human.putinput(tmpbord.bord);
            
            // 置きたい盤にコマがないか判定します
            // ここの入れ子はぐちゃってる　悲しい　
            if (check.RowCount(num, tmpbord, human: human))
            {
                // なかったら置きます
                put(tmpbord, human, num);
                // 置きたい盤の周辺に同じコマが何個あるか判定します
                if (jugement.RowCount(num, tmpbord, human: human))
                {
                    Console.WriteLine($"****{human.Name}さんの勝ちです。****");
                    View.bordview(tmpbord);
                    Environment.Exit(0);
                }
            }
        }

        public void put(Bord tmpbord, Human human, int[] num)
        {
            if (human.Rows == Rows.Circle)
            {
                tmpbord.bord[(num[0]), (num[1])] = Rows.Circle.ToString();
            }
            else
            {
                tmpbord.bord[(num[0]), (num[1])] = Rows.Cross.ToString();
            }

            this.bord = tmpbord.bord;
        }
    }
}