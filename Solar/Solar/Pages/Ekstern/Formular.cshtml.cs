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

        private IConsumptionCategoryDataService _ConsCat;

        public FormularModel(
            IProjectDataService service,
            IRoofTypeDataService roofservice,
            IRoofMaterialDataService roofMaterial,
            IDimensioningDataService dimensioningService,
            IConsumptionCategoryDataService ConsumptionCategory
            ) 
        {
            _service = service;
            _roofTypeDataService = roofservice;
            _roofMaterielService = roofMaterial;
            _DimensioningDataService = dimensioningService;
            _ConsCat = ConsumptionCategory;
        }

        [BindProperty]
        public Project project { get; set; }

        public List<RoofType> Roofs { get; set; }
        public List<RoofMaterial> RoofMaterials { get; set; }
        public List<Dimensioning> Dimensens { get; set; }

        public List<ConsumptionCategory> ConsCats { get; set; }

        public void OnGet()
        {
            Roofs = _roofTypeDataService.GetAll();
            RoofMaterials = _roofMaterielService.GetAll();
            Dimensens = _DimensioningDataService.GetAll();
            ConsCats = _ConsCat.GetAll();
        }

        public IActionResult OnPost()
        {
            project.DimensioningConsumption.HouseSize = null;
            _service.Create(project);

            return RedirectToPage("/Index");
        }

    }
}
