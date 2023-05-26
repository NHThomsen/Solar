using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFourModel : PageModel
    {
        private EFCInstallerDataService _installerDataService;

        [BindProperty]
        public Project? ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public string StepData { get; set; }
        public string InstallerDepartment { get; set; }
        public string InstallerName { get; set; }
        public ProjectStepFourModel()
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;

            if (GlobalProjectDataService.ProjectDataStepThreePointFive == null)
            {
                StepData = "/Ekstern/ProjectStepThree";
            } else
            {
                StepData = "/Ekstern/ProjectStepThreePointFive";
            }

            _installerDataService = new EFCInstallerDataService();

    }
        public void OnGet()
        {

            InstallerDepartment = _installerDataService.Read(int.Parse(User.Claims.ElementAt(1).Value)).Department;
            InstallerName = _installerDataService.Read(int.Parse(User.Claims.ElementAt(1).Value)).Installer1;

        }

        public IActionResult OnPost() 
        {
            
            GlobalProjectDataService.ProjectDataStepFour = ProjectData;

            return RedirectToPage("/Ekstern/ProjectStepFive");
        }
    }
}
