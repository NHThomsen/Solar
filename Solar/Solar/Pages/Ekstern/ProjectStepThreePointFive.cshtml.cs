using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;
using System.Security.Claims;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepThreePointFiveModel : PageModel
    {
        private IConsumptionCategoryDataService _ConsCat;
        private EFCInstallerDataService _installerDataService;
        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public List<ConsumptionCategory> ConsCats { get; set; }
        public string InstallerDepartment { get; set; }
        public string InstallerName { get; set; }
        public ProjectStepThreePointFiveModel(IConsumptionCategoryDataService consCat)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            _ConsCat = consCat;
            _installerDataService = new EFCInstallerDataService();
        }
        public void OnGet()
        {
            ConsCats = _ConsCat.GetAll();

            InstallerDepartment = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Department;
            InstallerName = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Installer1;
        }

        public IActionResult OnPost() 
        { 
            GlobalProjectDataService.ProjectDataStepThreePointFive = ProjectData;
            return RedirectToPage("/Ekstern/ProjectStepFour");
        }
    }
}
