using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFiveModel : PageModel
    {
        public Project ExistingData { get; set; }
        public ProjectStepFiveModel()
        {
            ExistingData = GlobalProjectDataService.ProjectDataStepFive;
        }
        public void OnGet()
        {
        }
    }
}
