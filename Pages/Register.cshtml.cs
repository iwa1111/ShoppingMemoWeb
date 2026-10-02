using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace ShoppingMemoWeb.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ShoppingDbContext _context;
        
        public RegisterModel(ShoppingDbContext context)
        {
            _context = context;

        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string userName, string email, string password)
        {
            Console.WriteLine($"【テスト】通信到達！ ユーザー名: {userName}, メール: {email}");
            //入力情報が埋まっているかの確認
            if(!string.IsNullOrWhiteSpace(userName) && 
               !string.IsNullOrWhiteSpace(email) &&
               !string.IsNullOrWhiteSpace(password))
            {
                var user = new User
                {
                    UserName = userName,
                    Email = email
                };
                

                //パスワードを暗号変換
                var hasher = new PasswordHasher<User>();
                user.PasswordHash = hasher.HashPassword(user,password);

                //データベースに登録
                _context.Users.Add(user);
                if (_context.SaveChanges() > 0)
                {
                    Console.WriteLine($"[ユーザー登録成功]{userName}さんをデータベースに登録しました");
                }
                else
                {
                    Console.WriteLine($"[ユーザー登録エラー]{userName}さんのデータベース登録に失敗しました");
                }

                
                // 登録完了後リスト画面に戻る
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}