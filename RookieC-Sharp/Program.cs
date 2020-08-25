using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RookieC_Sharp
{
    //n目並べにしたい
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
            /*   初期設定     */
            Check check = new Check();
            Put put = new Put();
            Jugement jugement = new Jugement();
            
            //盤を作成　n*nの二次元配列
            Bord bord = new Bord();
            //何目並べか入力を促します。
            bord.sizeinput();
            
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
            
            
            /*    ここから戦い    */
            while (true)
            {
                //今の盤の状況を表示させます
                View.bordview(bord);
                //置きたい場所を入力させます
                int[] num = player.putinput(bord.bord);
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
                num = enemy.putinput(bord.bord);
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
    }
}