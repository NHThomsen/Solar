using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.AccessControl;

namespace Solar.Pages.Ekstern
{
    public class FormularModel : PageModel
    {
        private IProjectDataService _service;

        private IRoofTypeDataService _roofTypeDataService;

        private IRoofMaterialDataService _roofMaterielService;

        private IDimensioningDataService _DimensioningDataService;

        public FormularModel(
            IProjectDataService service,
            IRoofTypeDataService roofservice,
            IRoofMaterialDataService roofMaterial,
            IDimensioningDataService dimensioningService
            ) 
        {
            _service = service;
            _roofTypeDataService = roofservice;
            _roofMaterielService = roofMaterial;
            _DimensioningDataService = dimensioningService;
        }

        [BindProperty]
        public Project project { get; set; }

        public List<RoofType> Roofs { get; set; }
        public List<RoofMaterial> RoofMaterials { get; set; }
        public List<Dimensioning> Dimensens { get; set; }


        public void OnGet()
        {
            Roofs = _roofTypeDataService.GetAll();
            RoofMaterials = _roofMaterielService.GetAll();
            Dimensens = _DimensioningDataService.GetAll();
        }
    }
}
