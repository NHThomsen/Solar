using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solar.Pages.Ekstern
{
    public class ProjectStep2Model : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Ekstern/ProjectStepThree");
        }
    }
}
