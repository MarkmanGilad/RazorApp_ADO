using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp_ADO.Model;
using System.Data;

namespace RazorApp_ADO.Pages.Users
{
    public class IndexModel : PageModel
    {
        public DataTable dt { get; set; }
        [BindProperty]
        public string filter { get; set; } = string.Empty;
        [BindProperty]
        public string column { get; set; }
        [BindProperty]
        public string Order { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public void OnGet()
        {
            Helper helper = new Helper();
            string SQL = "SELECT * FROM Users";
            dt = helper.RetrieveTable(SQL, "Users");
            
        }
        
        public void OnPostFilter()
        {
            Helper helper = new Helper();
            string SQL;
            if (filter == string.Empty)
            {
                SQL = "SELECT * FROM Users";
            }
            else
            {
                SQL = $"SELECT * FROM Users WHERE Firstname LIKE '%{filter}%' OR Lastname Like '%{filter}%'";
            }
            dt = helper.RetrieveTable(SQL, "Users");
        }
        
        public void OnPostSort()
        {
            Helper helper = new Helper();
            string SQL = $"SELECT * FROM Users ORDER BY {column} {Order}";
            dt = helper.RetrieveTable(SQL, "Users");
        }
        
        public void OnPostDelete()
        {
            Helper helper = new Helper();
            helper.Delete(Id, "Users");
            string SQL = "SELECT * FROM Users";
            dt = helper.RetrieveTable(SQL, "Users");
        }

    }

    

}
