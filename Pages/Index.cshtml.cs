using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ShoppingMemoWeb.Pages
{
    // C#とHTMLを連携させるためのクラス
    public class IndexModel : PageModel
    {
        // 1. 買い物アイテムの設計図
        public class ShoppingItem
        {
            public string Name { get; set; }
            public bool IsCompleted { get; set; }
        }

        // 2. HTML（表側）に渡すためのリストを準備
        public List<ShoppingItem> ShoppingList { get; set; } = new List<ShoppingItem>();

        // 3. ページが開かれたときに実行される処理
        public void OnGet()
        {
            // リストにデータを追加します（じゃがいもだけチェック済みにしてみます）
            ShoppingList.Add(new ShoppingItem { Name = "にんじん", IsCompleted = false });
            ShoppingList.Add(new ShoppingItem { Name = "じゃがいも", IsCompleted = true });
            ShoppingList.Add(new ShoppingItem { Name = "カレールー", IsCompleted = false });
        }
    }
}