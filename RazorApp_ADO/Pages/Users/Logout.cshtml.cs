using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp_ADO.Pages.Users
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Clear the entire session
            HttpContext.Session.Clear();

            return RedirectToPage("/Index");
        }
    }
}
