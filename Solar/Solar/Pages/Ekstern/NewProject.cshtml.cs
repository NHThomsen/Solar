using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solar.Pages.Ekstern
{
    public class NewProjectModel : PageModel
    {
        [BindProperty]
        public Project Project { get; set; }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost() {


            return RedirectToPage("/Ekstern/ProjectStepOne");

        }

    }
}
