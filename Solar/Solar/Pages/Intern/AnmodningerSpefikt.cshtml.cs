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


        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public Project InfoDump { get; set; }
       
        public RoofType RoofType { get; set; }
        public RoofMaterial RoofMaterial { get; set; }

        public AnmodningerSpefikt(IRoofTypeDataService roofTypeDataService, IRoofMaterialDataService roofMaterielService)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            //InfoDump = GlobalProjectDataService.Merge();

            _roofTypeDataService = roofTypeDataService;
            _roofMaterielService = roofMaterielService;
        }

        public void OnGet()
        {
            //RoofType = _roofTypeDataService.Read((int)InfoDump.Assembly.RoofTypeId);
            //RoofMaterial = _roofMaterielService.Read((int)InfoDump.Assembly.RoofMaterialId);

        }
    }
}
