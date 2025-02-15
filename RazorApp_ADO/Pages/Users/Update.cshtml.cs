using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp_ADO.Model;
using System.Data;

namespace RazorApp_ADO.Pages.Users
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; } = new User();
        public string msg { get; set; } = string.Empty;

        public IActionResult OnGet(string param)
        {
            int id = int.Parse(param);
            Helper helper = new Helper();
            string SQL = $"SELECT * FROM Users WHERE Id = {id}";
            DataTable dt = helper.RetrieveTable(SQL, "Users");
            DataRow dr = dt.Rows[0];
            //User user = new User();
            NewUser.ID = id;
            NewUser.Username = dr["Username"].ToString();
            NewUser.Pass = dr["Pass"].ToString();
            NewUser.FirstName = dr["Firstname"].ToString();
            NewUser.LastName = dr["Lastname"].ToString();
            NewUser.Email = dr["Email"].ToString();
            NewUser.Phone = dr["Phone"].ToString();
            NewUser.Admin = (bool)dr["Admin"];
            object obj = dr["Birthday"];
            if (dr["Birthday"] != DBNull.Value)
            {
                NewUser.Birthday = DateTime.Parse(dr["Birthday"].ToString());
            }
            else
            {
               NewUser.Birthday = null;
            }
            

            return Page();

        }
        
        public IActionResult OnPost()
        {
            Helper helper = new Helper();
            try
            {
                int n = helper.Update(NewUser, "Users");
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
