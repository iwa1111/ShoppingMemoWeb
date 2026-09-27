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
        public static List<ShoppingItem> ShoppingList { get; set; } = new List<ShoppingItem>()
        {
            new ShoppingItem { Name = "にんじん", IsCompleted = false },
            new ShoppingItem { Name = "じゃがいも", IsCompleted = false },
            new ShoppingItem { Name = "カレールー", IsCompleted = false }
        };

        // 3. ページが開かれたときに実行される処理
        public void OnGet()
        {
          
        }
        // ▼ここから新規追加：画面からデータが送信（POST）された時の処理▼
        public void OnPostUpdate(string itemName)
        {
            Console.WriteLine($"【テスト】通信が来ました！ 送られてきた品名: {itemName}");
            // 送られてきた品名と同じアイテムをリストの中から探します
            var item = ShoppingList.Find(itemlist => itemlist.Name == itemName);
            
            // もし見つかったら、チェック状態を反転（true⇔false）させます
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                Console.WriteLine($"【通信成功】{item.Name} のチェック状態が {item.IsCompleted} に更新されました！");
            }
            else
            {
                Console.WriteLine($"【エラー】リストの中に {itemName} が見つかりませんでした。");
            }
        }

        public void OnPostDelete(string itemName)
        {
            var item = ShoppingList.Find(x => x.Name == itemName);

            if(item != null)
            {
                ShoppingList.Remove(item);
                Console.WriteLine($"[削除成功] {item.Name} をリストから削除しました！");
            }
        }
       
    }
}