using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Solar.Pages.Ekstern
{
    public class LogindModel : PageModel
    {
        private IUsersDataService _service;

        public LogindModel(IUsersDataService userdata)
        {
            _service = userdata;
        }

        public static User LogedinUser { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; } 


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            LogedinUser = _service.VerifyUser(UserName, Password);

            if (LogedinUser == null)
            {
                return Page();
            }

            return RedirectToPage("/Ekstern/NewProject");
        }
    }
}
