using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShoppingMemoWeb.Pages
{
    // 追加ページ用のモデルクラス
    public class AddModel : PageModel
    {
        private readonly ShoppingDbContext _context;

        public AddModel(ShoppingDbContext context)
        {
            _context = context;
        }

        public void OnGEt()
        {   
        }

        public IActionResult OnPost(String newItemName)
        {
            Console.WriteLine($"[登録要求]品名{newItemName}の登録要求が来た");
            if(!string.IsNullOrWhiteSpace(newItemName))
            {
                //データベースに新しいアイテムを追加
                _context.ShoppingItems.Add(new ShoppingItem {Name = newItemName, IsCompleted = false});
                _context.SaveChanges(); //変更を確定
                Console.WriteLine($"[登録完了]品名{newItemName}の登録完了");

                return RedirectToPage("/Index");
            }
            else
            {
                Console.WriteLine($"[エラー]品名{newItemName}の失敗");
            }
            return Page();
        }
    }
}