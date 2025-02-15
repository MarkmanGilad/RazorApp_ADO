using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorApp_ADO.Model;

namespace RazorApp_ADO.Pages.Users
{
    public class Index_readerModel : PageModel
    {
        public SqlDataReader Reader { get; set; }

        public void OnGet()
        {
            Helper helper = new Helper();
            string SQL = "SELECT * FROM Users";
            Reader = helper.GetDataReader(SQL);
        }
    }
}
