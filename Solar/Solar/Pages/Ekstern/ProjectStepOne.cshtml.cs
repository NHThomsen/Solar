using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepOneModel : PageModel
    {
        private IRoofTypeDataService _roofTypeDataService;

        private IRoofMaterialDataService _roofMaterielService;
        [BindProperty]
        public Project? ProjectData { get; set; }
        public Project ExistingData { get; set; }

        public ProjectStepOneModel(IRoofTypeDataService roofTypeDataService, IRoofMaterialDataService roofMaterielService)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            _roofTypeDataService = roofTypeDataService;
            _roofMaterielService = roofMaterielService;
        }
        
        public List<RoofType> Roofs { get; set; }
        public List<RoofMaterial> RoofMaterials { get; set; }

        public void OnGet()
        {

            Roofs = _roofTypeDataService.GetAll();
            RoofMaterials = _roofMaterielService.GetAll();
        }

        public IActionResult OnPost()
        {
            GlobalProjectDataService.ProjectDataStepOne = ProjectData;
            return RedirectToPage("/Ekstern/ProjectStepTwo");
        }
    }
}
