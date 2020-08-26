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
            
            // プレイヤー二人に名前を入力してもらいます
            Console.WriteLine($"{player.Rows}を使用する方の名前を入力してください");
            player.nameinput(Console.ReadLine());

            Console.WriteLine($"{enemy.Rows}を使用する方の名前を入力してください");
            enemy.nameinput(Console.ReadLine());

            // ここから戦い
            while (true)
            {
                foreach (var man in human)
                {
                    if (bord.rule(man))
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}