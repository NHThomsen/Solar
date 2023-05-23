using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFiveModel : PageModel
    {
        public List<Project> DataFromAllProjects { get; set; }
        public ProjectStepFiveModel()
        {
            DataFromAllProjects = new List<Project>
            {
                GlobalProjectDataService.ProjectDataNewProject,
                GlobalProjectDataService.ProjectDataStepOne, 
                GlobalProjectDataService.ProjectDataStepTwo,
                GlobalProjectDataService.ProjectDataStepThree,
                GlobalProjectDataService.ProjectDataStepThreePointFive,
                GlobalProjectDataService.ProjectDataStepFour
            };

        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            GlobalProjectDataService.Merge(DataFromAllProjects);
        }
    }
}
