using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public User _User { get; set; }

        public IActionResult OnGet()
        {
            System.Diagnostics.Debug.WriteLine("on get");
            return Page();
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Create(_User);
            return RedirectToPage("/Ekstern/Logind");
        }
    }
}
