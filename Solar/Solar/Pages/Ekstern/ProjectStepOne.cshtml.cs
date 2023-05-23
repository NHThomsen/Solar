using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Solar.Pages.Ekstern
{
    public class ProjectStep1Model : PageModel
    {
        private IRoofTypeDataService _roofTypeDataService;

        private IRoofMaterialDataService _roofMaterielService;

        public ProjectStep1Model(IRoofTypeDataService roofTypeDataService, IRoofMaterialDataService roofMaterielService)
        {
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
            return RedirectToPage("/Ekstern/ProjectStepTwo");
        }
    }
}
