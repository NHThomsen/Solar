using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepTwoModel : PageModel
    {
        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }

        public ProjectStepTwoModel()
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            GlobalProjectDataService.ProjectDataStepTwo = ProjectData;
            return RedirectToPage("/Ekstern/ProjectStepThree");
        }
    }
}
