using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Models.Static;
using Solar.Services.StaticServices;

namespace Solar.Pages.Intern
{
    public class AnmodningerSpefikt : PageModel
    {
        private IRoofTypeDataService _roofTypeDataService;

        private IRoofMaterialDataService _roofMaterielService;

        private IProjectDataService _projectDataService;

        [BindProperty]
        public Project DataBaseInfo { get; set; }
       
        public RoofType RoofType { get; set; }
        public RoofMaterial RoofMaterial { get; set; }

        public AnmodningerSpefikt(IProjectDataService projectDataService, IRoofTypeDataService roofTypeDataService, IRoofMaterialDataService roofMaterielService)
        {
            

            _roofTypeDataService = roofTypeDataService;
            _roofMaterielService = roofMaterielService;
            _projectDataService = projectDataService;
        }

        public void OnGet(int id)
        {
            DataBaseInfo = _projectDataService.Read(id);

            RoofType = _roofTypeDataService.Read((int)DataBaseInfo.Assembly.RoofTypeId);
            RoofMaterial = _roofMaterielService.Read((int)DataBaseInfo.Assembly.RoofMaterialId);
        }
    }
}
