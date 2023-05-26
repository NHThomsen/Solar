using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;
using System.Security.Claims;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepTwoModel : PageModel
    {
        private EFCInstallerDataService _installerDataService;

        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public string InstallerDepartment { get; set; }
        public string InstallerName { get; set; }

        public ProjectStepTwoModel()
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            _installerDataService = new EFCInstallerDataService();
        }

        public void OnGet()
        {

            InstallerDepartment = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Department;
            InstallerName = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Installer1;
        }

        public IActionResult OnPost()
        {
            GlobalProjectDataService.ProjectDataStepTwo = ProjectData;
            return RedirectToPage("/Ekstern/ProjectStepThree");
        }
    }
}
