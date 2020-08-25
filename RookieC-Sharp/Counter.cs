using System;

namespace RookieC_Sharp
{
    //4つ並んでいるか調べるクラス
    public class Jugement : IBord
    {
        public bool RowCount(int[] num, Bord bord, Human human)
        {
            //わかりやすく1を入れとく
            int count = 1;
            //周囲8方向を見る二重ループ
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    count = 0;
                    //置いたコマを見ないようにする条件
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    //配列の添え字に予期しない数値が入るのを抑制
                    if (num[0] + i < 0 || num[1] + j < 0 || num[0] + i >= bord.size+2 || num[1] + j >= bord.size+2)
                    {
                        continue;
                    }

                    //周囲８マスを調べてコマが置いてあるか判定
                    if (bord.bord[(num[0] + i), (num[1] + j)] != null)
                    {
                        //置いてあったら自分のかどうか判定
                        if (bord.bord[num[0] + i, num[1] + j] == human.Rows.ToString())
                        {
                            count++;
                            //自分のだった場合、何個並んでいるか数える
                            for (int k = 1; k <= bord.size; k++)
                            {
                                //配列の添え字を超えそうになったら飛ばす
                                if (num[0] + i * k < 0 || num[1] + j * k < 0 || num[0] + i * k >= bord.size+2 || num[1] + j * k >= bord.size+2)
                                {
                                    continue;
                                }
                                //1マス進んだ先にコマがあるかどうか判定
                                if (bord.bord[num[0] + i * k, num[1] + j * k] == null)
                                {
                                    break;
                                }
                                //あったらそれが自分の書いたものか判定
                                if (bord.bord[num[0] + (i * k), num[1] + (j * k)] == human.Rows.ToString())
                                {
                                    Console.WriteLine(count);
                                    count++;
                                }
                            }

                            //反対側も数える kに-1を積るだけ
                            for (int k = 1; k<= bord.size; k++)
                            {
                                if (num[0] + i * -k < 0 || num[1] + j * -k < 0 || num[0] + i * -k >= bord.size+2 || num[1] + j * -k >= bord.size+2)
                                {
                                    continue;
                                }
                                if (bord.bord[num[0] + i * -k, num[1] + j * -k] == null)
                                {
                                    break;
                                }

                                if (bord.bord[num[0] + i * -k, num[1] + j * -k] == human.Rows.ToString())
                                {
                                    Console.WriteLine(count);
                                    count++;
                                }
                            }

                            //n個以上あったら帰る
                            if (count >= bord.size)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }

    //決めた場所に何もないかを判定
    public class Check : IBord
    {
        public bool RowCount(int[] num, Bord bord, Human human)
        {
            if (bord.bord[num[0], num[1]] == null)
            {
                return true;
            }

            return false;
        }
    }

    //置く 参照使ってるから要修正
    public class Put : IBord
    {
        public bool RowCount(int[] num, Bord bord, Human human)
        {
            if (human.Rows == Rows.Circle)
            {
                bord.bord[(num[0]), (num[1])] = Rows.Circle.ToString();
            }
            else
            {
                bord.bord[(num[0]), (num[1])] = Rows.Cross.ToString();
            }

            return true;
        }
    }
}