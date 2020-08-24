using System;

namespace RookieC_Sharp
{
    //4つ並んでいるか調べるクラス
    public class Jugement : IBord
    {
        public bool RowCount(int[] num, string[,] bord, Human human)
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

                    if (num[0] + i < 0 || num[1] + j < 0 || num[0] + i >= 5 || num[1] + j >= 5)
                    {
                        continue;
                    }

                    //周囲８マスを調べてコマが置いてあるか判定
                    if (bord[(num[0] + i), (num[1] + j)] != null)
                    {
                        //置いてあったら自分のかどうか判定
                        if (bord[num[0] + i, num[1] + j] == human.Rows.ToString())
                        {
                            count++;
                            //自分のだった場合、何個並んでいるか数える
                            for (int k = 1; k < 5; k++)
                            {
                                if (num[0] + i * k < 0 || num[1] + j * k < 0 || num[0] + i * k >= 5 || num[1] + j * k >= 5)
                                {
                                    continue;
                                }
                                if (bord[num[0] + i * k, num[1] + j * k] == null)
                                {
                                    break;
                                }

                                if (bord[num[0] + (i * k), num[1] + (j * k)] == human.Rows.ToString())
                                {
                                    count++;
                                }
                            }

                            //反対側も数える
                            for (int k = 1; k < 5; k++)
                            {
                                if (num[0] + i * -k < 0 || num[1] + j * -k < 0 || num[0] + i * -k >= 5 || num[1] + j * -k >= 5)
                                {
                                    continue;
                                }
                                if (bord[num[0] + i * -k, num[1] + j * -k] == null)
                                {
                                    break;
                                }

                                if (bord[num[0] + i * -k, num[1] + j * -k] == human.Rows.ToString())
                                {
                                    count++;
                                }
                            }

                            //4個以上あったら帰る
                            if (count >= 4)
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
        public bool RowCount(int[] num, string[,] bord, Human human)
        {
            if (bord[num[0], num[1]] == null)
            {
                return true;
            }

            return false;
        }
    }

    //置く
    public class Put : IBord
    {
        public bool RowCount(int[] num, string[,] bord, Human human)
        {
            if (human.Rows == Rows.Circle)
            {
                bord[(num[0]), (num[1])] = Rows.Circle.ToString();
            }
            else
            {
                bord[(num[0]), (num[1])] = Rows.Cross.ToString();
            }

            return true;
        }
    }
}