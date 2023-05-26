using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;
using System.Security.Claims;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepThreeModel : PageModel
    {
        private IDimensioningDataService _DimensioningDataService;
        private EFCInstallerDataService _installerDataService;

        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public List<Dimensioning> Dimensions { get; set; }
        public string InstallerDepartment { get; set; }
        public string InstallerName { get; set; }

        public ProjectStepThreeModel(IDimensioningDataService dimensioningDataService)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            _DimensioningDataService = dimensioningDataService;
            _installerDataService = new EFCInstallerDataService();

        }
        public void OnGet()
        {
            Dimensions = _DimensioningDataService.GetAll();

            InstallerDepartment = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Department;
            InstallerName = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Installer1;
        }

        public IActionResult OnPost()
        {
            GlobalProjectDataService.ProjectDataStepThree = ProjectData;

            if(ProjectData.DimensioningId == 1)
            {
                return RedirectToPage("/Ekstern/ProjectStepThreePointFive");
            }

            GlobalProjectDataService.ProjectDataStepThreePointFive = null;


            return RedirectToPage("/Ekstern/ProjectStepFour");
        }
    }
}
