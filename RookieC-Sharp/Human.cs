namespace RookieC_Sharp
{
    public enum Rows
    {
        Circle,    //まる
        Cross    //ばつ
    }
    public class Human
    {
        protected string Name { get; set; }
        
        protected int Age { get; set; }

        public Rows Rows { get; set; }
        
        public bool victory { get; set; }

    }
}