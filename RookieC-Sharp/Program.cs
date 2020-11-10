using System;

namespace RookieC_Sharp
{
    /// <summary>
    /// 入力処理
    /// ①名前の入力    メソッド内でやる
    /// ②何個並べたら勝ちにするか    メソッド内でやる
    /// ③どこに置くか＊ｎ    mainでやる？
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// n目並べ
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            // 初期設定     
            string str;
            var socket = new SocketClass();
            IBord[] ibord =
            {
                new Check(),
                new Jugement()
            };
            
            // プレイヤー二人をまとめておく
            Human player, enemy;
            Human[] human =
            {
                player = new Human
                {
                    Rows = Rows.Circle
                }, 
                enemy = new Human
                {
                    Rows = Rows.Cross
                } 
            };
            
            // 盤を作成　n*nの二次元配列
            Bord bord = new Bord();
            
            // 何目並べか入力を促します。
            do
            {
                Console.WriteLine("何個並んだら勝ちにしますか？\n※ 2～6の間でお願いします");
                str = Console.ReadLine();
                if (bord.sizeinput(str))
                {
                    break;
                }
                Console.WriteLine("入力値が不正です");
            } while (true);

            Console.WriteLine("サーバー側なら1 クライアント側なら2を入力してください");
            var number = int.Parse(Console.ReadLine());

            // プレイヤー二人に名前を入力してもらいます
            if (number == 1)
            {
                Console.WriteLine($"{player.Rows}を使用する方の名前を入力してください");
                player.nameinput(Console.ReadLine());
            }
            else 
            {
                Console.WriteLine($"{enemy.Rows}を使用する方の名前を入力してください");
                enemy.nameinput(Console.ReadLine());
            }

            // 通信して名前を入れ合う
            if (number == 1)
            {
                enemy.nameinput(socket.Server(player.Name));
            }
            else
            {
                player.nameinput(socket.Client(enemy.Name));
            }
            
            Console.WriteLine("こいつらの戦い");
            Console.WriteLine($"{player.Name}と{enemy.Name}");
            
            // ここから戦い
            while (true)
            {
                foreach (var man in human)
                {
                    // n個以上コマがあったらtrueが返ってきてプログラムを終了する
                    if (bord.rule(man,ibord,number))
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}