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
        public string Department { get; set; }
        public string CVR { get; set; }
        public string Installer { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost() 
        {

            if (Username == null || Password == null)
            {
                ErrorMessage = "Udfyldt venligst felterne";
                return Page();
            }

            if (_service.CheckUsernameExist(Username)) 
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
            user.Installer.Installer1 = Installer;
            user.Installer.Department = Department;
            user.Installer.AccountNumber = CVR;

            _service.Create(user);
            return RedirectToPage("/Ekstern/Logind");
        }
    }
}
