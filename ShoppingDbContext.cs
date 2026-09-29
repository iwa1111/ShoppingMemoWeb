using Microsoft.EntityFrameworkCore;

namespace ShoppingMemoWeb
{
    // C#とデータベースを繋ぐための専用クラス
    public class ShoppingDbContext : DbContext
    {
        //　接続設定を受け取るための決まり
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
        {
        }
        // データベースの中に「ShoppingItems」という名前のテーブルを作る宣言
        public DbSet<ShoppingItem> ShoppingItems {get; set;}
    }
}