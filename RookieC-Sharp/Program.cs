using System;
using System.Collections.Generic;
using System.Linq;

namespace RookieC_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // IBord[] rule =
            // {
            //     new Check(), 
            //     new Put(), 
            //     new Jugement(), 
            // };
            Check check = new Check();
            Put put = new Put();
            Jugement jugement = new Jugement();
            //二人のプレイヤーを作成
            //まるちゃん
            Human player = new Human
            {
                Rows = Rows.Circle
            };
            //ばつくん
            Human enemy = new Human
            {
                Rows = Rows.Cross
            };
            //盤を作成　5*5の二次元配列
            //と、思ったけど添え字が配列の外を示しちゃうときがあるため7*7で作ってみる
            string[,] bord = new string[7, 7];
            while (true)
            {
                //今の盤の状況を表示させます
                View.bordview(bord);
                //置きたい場所を入力させます
                int[] num = input();
                //置きたい盤にコマがないか判定します
                //ここの入れ子はぐちゃってる　悲しい　
                if (check.RowCount(num, bord, human: player))
                {
                    //なかったら置きます
                    if (put.RowCount(num, bord, human: player))
                    {
                        //置きたい盤の周辺に同じコマが何個あるか判定します
                        if (jugement.RowCount(num, bord, human: player))
                        {
                            put.RowCount(num, bord, human: player);
                            Console.WriteLine("あなたの勝ちです。");
                            View.bordview(bord);
                            Environment.Exit(0);
                        }
                    }
                }

                //今の盤の状況を表示させます
                View.bordview(bord);
                //置きたい場所を入力させます
                num = input();
                //置きたい盤にコマがないか判定します
                if (check.RowCount(num, bord, human: enemy))
                {
                    //なかったら置きます
                    if (put.RowCount(num, bord, human: enemy))
                    {
                        //置きたい盤の周辺に同じコマが何個あるか判定します
                        if (jugement.RowCount(num, bord, human: enemy))
                        {
                            Console.WriteLine("あなたの勝ちです。");
                            View.bordview(bord);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        static int[] input()
        {
            string str;
            int[] result;
            // Console.WriteLine("名前を入力してください");
            // str = Console.ReadLine();
            // name = str;
            Console.WriteLine("書きたい場所を指定してください");
            str = Console.ReadLine();
            //こういうのLinQと言うらしい　おしゃれ
            result = str
                .Split(',')
                .Select(a => int.Parse(a))
                .ToArray();
            return result;
        }
    }
}