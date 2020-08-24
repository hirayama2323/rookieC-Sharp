using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RookieC_Sharp
{
    class Program
    {
        /*
         * @class Check まるバツを書きたい場所にすでに書かれていないか判定します
         * @class put 入力されたマスに書きます。bord[,]が参照変数状態なのでわかりづらいかも
         * @class jugement 4つ並んでいるか判定します
         * @class Human プレイヤーを作成するクラス　名前を入力するメソッドが入っています
         * @class view 盤の状況を表示させるクラス
         */
        static void Main(string[] args)
        {
            Check check = new Check();
            Put put = new Put();
            Jugement jugement = new Jugement();
            //二人のプレイヤーを作成
            //まる
            Human player = new Human
            {
                Rows = Rows.Circle
            };
            //名前の入力を促します
            player.nameinput();
            
            //ばつ
            Human enemy = new Human
            {
                Rows = Rows.Cross
            };
            enemy.nameinput();
            
            //盤を作成　5*5の二次元配列
            string[,] bord = new string[5, 5];
            while (true)
            {
                //今の盤の状況を表示させます
                View.bordview(bord);
                //置きたい場所を入力させます
                int[] num = input(player,bord);
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
                            Console.WriteLine($"{player.Name}さんの勝ちです。");
                            View.bordview(bord);
                            Environment.Exit(0);
                        }
                    }
                }

                //今の盤の状況を表示させます
                View.bordview(bord);
                //置きたい場所を入力させます
                num = input(enemy,bord);
                //置きたい盤にコマがないか判定します
                if (check.RowCount(num, bord, human: enemy))
                {
                    //なかったら置きます
                    if (put.RowCount(num, bord, human: enemy))
                    {
                        //置きたい盤の周辺に同じコマが何個あるか判定します
                        if (jugement.RowCount(num, bord, human: enemy))
                        {
                            Console.WriteLine($"{enemy.Name}さんの勝ちです。");
                            View.bordview(bord);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        
        //盤のマスの入力を促します
        static int[] input(Human human,string[,] bord)
        {
            string str;
            int[] result;
            Console.WriteLine($"{human.Name}さんの番です。");
            Console.WriteLine("行,列の形で入力してください");
            str = Console.ReadLine();
            //こういうのLinQと言うらしい　おしゃれ
            while (true)
            {
                //正規表現で入力チェック　正規表現なんとなくわかってきた
                if (Regex.IsMatch(str, "^[1-5],[1-5]$"))
                {
                    result = str
                        .Split(',')
                        .Select(a => int.Parse(a))
                        .ToArray();
                    
                    result[1] -= 1;
                    result[0] -= 1;
                    //すでに書かれていたらもう一度入力を促す
                    if (bord[result[0],result[1]] != null)
                    {
                        Console.WriteLine("そこにはすでにコマが書かれています");
                        Console.WriteLine("行,列の形で入力してください");
                        str = Console.ReadLine();
                        continue;
                    }
                    break;
                }

                Console.WriteLine("行,列の形で入力してください");
                str = Console.ReadLine();
            }

            return result;
        }
    }
}