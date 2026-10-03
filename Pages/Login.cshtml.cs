using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ShoppingMemoWeb.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ShoppingDbContext _context;

        public LoginModel(ShoppingDbContext context)
        {
            _context = context;
        }

        //ログイン処理(async Task 通信に時間がかかるため)
        public async Task<IActionResult> OnPostAsync(string email, string password)
        {
            if(!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                //データベース登録メールアドレスから一致するユーザーを探す
                var user = _context.Users.FirstOrDefault(u => u.Email == email);
                if(user != null)
                {
                    var claims = new List<Claim>
                    {
                      new Claim(ClaimTypes.Name,user.UserName!),
                      new Claim(ClaimTypes.Email,user.Email!)  
                    };
                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(identity));
                    Console.WriteLine($"[ログイン成功]{user.UserName}さんがログインしました");
                    return RedirectToPage("/index");
                }
            }
            Console.WriteLine("[ログイン失敗]メールアドレスまたはパスワードが間違っています。");
            return Page();
        }
    }
}