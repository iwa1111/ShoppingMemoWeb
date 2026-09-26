using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShoppingMemoWeb.Pages
{
    // 追加ページ用のモデルクラス
    public class AddModel : PageModel
    {
        public void OnGet()
        {
            // ページが開かれた時は何もせず表示するだけ
        }

        // フォームからPOST送信された時の処理（引数名 newItemName に注意）[cite: 8]
        public IActionResult OnPost(string newItemName)
        {
            if (!string.IsNullOrWhiteSpace(newItemName))
            {
                // IndexModelのリストに直接追加します
                IndexModel.ShoppingList.Add(new IndexModel.ShoppingItem { Name = newItemName, IsCompleted = false });
                
                // 追加が終わったら、元のリスト画面（Index）に自動的に戻します（リダイレクト）
                return RedirectToPage("/Index");
            }

            return Page(); // もし空っぽだったら、元の追加画面に留まります
        }
    }
}