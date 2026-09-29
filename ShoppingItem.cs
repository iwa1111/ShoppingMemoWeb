namespace ShoppingMemoWeb
{
    public class ShoppingItem
    {
        //データベースでデータを一つずつ区別するための出席番号(主キー)
        public int Id {get;set;}

        //品名(空っぽを許容する)
        public string? Name {get;set;}

        //完了状態(チェックが入っているかどうか)
        public bool IsCompleted {get; set;}
    }
}