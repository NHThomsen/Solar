using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class NewProjectModel : PageModel
    {
        [BindProperty]
        public Project? ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public NewProjectModel()
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
        }

        public void OnGet()
        {
            
            
        }

        public IActionResult OnPost() 
        {
            
            GlobalProjectDataService.ProjectDataNewProject = ProjectData;
            
            return RedirectToPage("/Ekstern/ProjectStepOne");

        }

    }
}
