using System;

namespace RookieC_Sharp
{
    public enum Rows
    {
        Circle,    //まる
        Cross    //ばつ
    }
    public class Human
    {
        public string Name { get; set; }
        
        protected int Age { get; set; }

        public Rows Rows { get; set; }
        
        public bool victory { get; set; }


        public void nameinput()
        {
            Console.WriteLine($"{Rows}を使用する方の名前を入力してください");
            this.Name = Console.ReadLine();
        }

    }
    
    
}