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
                    bord = new string[size + 2, size + 2];
                    return true;
                }

                return false;

                // Console.WriteLine("入力値が不正です");
                // } while (true);
        }
    }
}