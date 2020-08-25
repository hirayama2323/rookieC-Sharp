using RookieC_Sharp;

namespace RookieC_Sharp
{
    /*    盤を作成するクラス    */
    class Bord
    {
        //盤の大きさを設定する変数
        public int size { get; set; }

        //盤の二次元配列　半可変
        public string[,] bord { get; set; }


    }
}