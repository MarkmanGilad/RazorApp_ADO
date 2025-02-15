using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp_ADO.Model;

namespace RazorApp_ADO.Pages.Users
{
    public class Login_ScalarModel : PageModel
    {
        public string msg { get; set; } = string.Empty;
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string pass { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            string SQLStr = $"SELECT Admin FROM Users WHERE Username LIKE '{Username}' AND Pass LIKE '{pass}'";
            Helper helper = new Helper();
            object admin = helper.GetScalar(SQLStr);

            if (admin != null)
            {
                HttpContext.Session.SetString("Login", Username);
                HttpContext.Session.SetString("Admin", admin.ToString());
                return RedirectToPage("/Index");
            }
            msg = "Wrong username or password.";
            return Page();
        }
    }
}
