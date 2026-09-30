using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingMemoWeb.Pages
{
    // C#とHTMLを連携させるためのクラス
    public class IndexModel : PageModel
    {
        // データベースの窓口
        private readonly ShoppingDbContext _context;

        // プログラム起動時に窓口を受け取る
        public IndexModel(ShoppingDbContext context)
        {
            _context = context;
        }

        public List<ShoppingItem> ShoppingList {get; set;} = new List<ShoppingItem>();

        public void OnGet()
        {
            //すべてのデータを読み込みID順に並べる
            ShoppingList = _context.ShoppingItems.OrderBy(x => x.Id).ToList();
        }

        //更新処理(IDを使って探す)
        public IActionResult OnPostUpdate(int id)
        {
            var item = _context.ShoppingItems.Find(id);
            if(item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

        //削除処理
        public IActionResult OnPostDelete(int id)
        {
            //通信が届いたかログを出力
            Console.WriteLine($"【テスト】削除の通信を確認。送られてきたID:{id}");

            var item = _context.ShoppingItems.Find(id);
            if (item != null)
            {
                _context.ShoppingItems.Remove(item);
                _context.SaveChanges(); 

                Console.WriteLine($"【削除成功】 ID: {id}のアイテムを削除しました");
            }
            else
            {
                //データが見つからなかった
                Console.WriteLine($"【エラー】 ID:{id}のアイテムが見つかりませんでした");
            }
            return RedirectToPage();
        }
        
        
       
    }
}