using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Solar.Pages.Ekstern
{
    public class IndexModel : PageModel
    {
        private IUsersDataService _service;

        public IndexModel(IUsersDataService service)
        {
            _service = service;
        }

        [BindProperty]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string RepeatedPassword { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost() 
        {
            if(_service.CheckUsernameExist(Username)) 
            {
                ErrorMessage = "Brugernavn er allerede i brug";
                return Page();
            }

            if (Password != RepeatedPassword)
            {
                ErrorMessage = "Passwords matcher ikke";
                return Page();
            }

            User user = new User
            {
                Username = Username,
                Password = Password
            };

            _service.Create(user);
            return RedirectToPage("/Ekstern/Logind");
        }
    }
}
