using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solar.Pages.Intern
{
    public class UpdateSpecificModel : PageModel
    {
        private IDimensioningDataService _DimensioningDataService;
        private IProjectDataService ProjectDataService;
        private IRoofTypeDataService RoofTypeDataService;

        private int id { get; set; }


        public List<Dimensioning> Dimensions { get; set; }
        public Project DataBaseInfo { get; set; }
        public RoofType RoofType { get; set; }



        public UpdateSpecificModel(IProjectDataService projectDataService, IRoofTypeDataService roofTypeDataService, IDimensioningDataService dimensioningDataService)
        {
            ProjectDataService = projectDataService;
            RoofTypeDataService = roofTypeDataService;

            _DimensioningDataService = dimensioningDataService;
        }

        public void OnGet(int id)
        {
            Dimensions = _DimensioningDataService.GetAll();

            DataBaseInfo = ProjectDataService.Read(id);
            RoofType = RoofTypeDataService.Read((int)DataBaseInfo.Assembly.RoofTypeId);
        }

        //public async Task<IActionResult> OnPost(int id)
        //{


        //    return RedirectToPage($"/Intern/RequestsSpecific/{id}");
        //}
    }
}