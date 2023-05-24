using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFiveModel : PageModel
    {
        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public Project InfoDump { get; set; }

        public ProjectStepFiveModel()
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            InfoDump = GlobalProjectDataService.Merge();
        }

        public void OnGet()
        {
            
           
        }

    }
}
