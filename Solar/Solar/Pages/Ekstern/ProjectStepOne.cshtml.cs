using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solar.Services.StaticServices;
using System.Security.Claims;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepOneModel : PageModel
    {
        private IRoofTypeDataService _roofTypeDataService;

        private IRoofMaterialDataService _roofMaterielService;

        private EFCInstallerDataService _installerDataService;

        [BindProperty]
        public Project? ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public string InstallerDepartment { get; set; }
        public string InstallerName { get; set; }
        public string ErrorMessage { get; set; }
        public List<RoofType> Roofs { get; set; }
        public List<RoofMaterial> RoofMaterials { get; set; }

        public ProjectStepOneModel(IRoofTypeDataService roofTypeDataService, IRoofMaterialDataService roofMaterielService)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            _roofTypeDataService = roofTypeDataService;
            _roofMaterielService = roofMaterielService;
            _installerDataService = new EFCInstallerDataService();

        }

        public void OnGet()
        {
            Roofs = _roofTypeDataService.GetAll();
            RoofMaterials = _roofMaterielService.GetAll();

            InstallerDepartment = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Department;
            InstallerName = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Installer1;
        }

        public IActionResult OnPost()
        {
            GlobalProjectDataService.ProjectDataStepOne = ProjectData;

            if (ProjectData.Assembly.RoofMaterialId == null || ProjectData.Assembly.RoofTypeId == null)
            {
                ErrorMessage = "Du skal udfylde Montage type og Tag Type";
                OnGet();
                return Page();
            }

            return RedirectToPage("/Ekstern/ProjectStepTwo");
        }
    }
}
