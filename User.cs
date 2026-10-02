namespace ShoppingMemoWeb
{
    public class User
    {
        //ユーザーID (出席者番号)
        public int Id {get;set;}

        //メールアドレス
        public string? Email {get;set;}

        // アカウント名
        public string? UserName {get;set;}

        //パスワード
        public string? PasswordHash {get;set;}
    }
}