using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFourModel : PageModel
    {
        [BindProperty]
        public Project? ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public ProjectStepFourModel()
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            GlobalProjectDataService.ProjectDataStepFour = ProjectData;
            return RedirectToPage("index");
        }
    }
}
