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
            return Regex.IsMatch(str, "^[2-6]$") ? true : false;
        }

        /// <summary>
        /// 何目並べをやりたいかを伺うクラス
        /// ここでついでに盤も作ってます
        /// </summary>
        public bool sizeinput(string str)
        {
            if (checknumber(str))
            {
                Console.WriteLine($"{str}目並べを始めます");
                this.size = Convert.ToInt32(str);
                this.bord = new string[size + 2, size + 2];
                return true;
            }

            return false;
        }
        
        ///<summary>
        /// 実際にn目並べをするメソッド
        /// このクラスに入れてるのに違和感アリ
        /// </summary>
        /// <param name="human">プレイヤー</param>
        /// <returns>n個以上あったらtrueを返してmainでシステムを終了します</returns>
        public bool rule(Human human,IBord[] ibord)
        {
            Bord tmpbord = new Bord();
            
            tmpbord.size = size;
            tmpbord.bord = bord;
            
            //現在の状況を表示します
            View.bordview(tmpbord);
            // 置きたい場所を入力させます
            int[] num = human.putinput(tmpbord.bord);

            // 置きたい盤にコマがないか判定します
            if (ibord[0].RowCount(num, tmpbord, human: human))
            {
                // なかったら置きます
                put(tmpbord, human, num);
                // 置きたい盤の周辺に同じコマが何個あるか判定します
                if (ibord[1].RowCount(num, tmpbord, human: human))
                {
                    Console.WriteLine($"****{human.Name}さんの勝ちです。****");
                    View.bordview(tmpbord);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 実際にコマを書くメソッド
        /// 便宜上put（置く）
        /// </summary>
        /// <param name="tmpbord"></param>
        /// <param name="human"></param>
        /// <param name="num"></param>
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