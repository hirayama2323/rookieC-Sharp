﻿﻿namespace RookieC_Sharp
{
    /// <summary>
    /// ルールをつかさどるインターフェース
    /// </summary>
    public interface IBord
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="bord"></param>
        /// <param name="human"></param>
        /// <returns></returns>
        bool RowCount(int[] num,Bord bord,Human human);
    }
    
}