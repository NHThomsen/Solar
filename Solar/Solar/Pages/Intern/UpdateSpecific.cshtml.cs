using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solar.Pages.Intern
{
    [Authorize(Policy = "admin")]
    public class UpdateSpecificModel : PageModel
    {
        private IDimensioningDataService _dimensioningDataService;
        private IProjectDataService _projectDataService;
        private IRoofTypeDataService _roofTypeDataService;

        [BindProperty]
        public Project DataBaseInfo { get; set; }
        public RoofType RoofType { get; set; }
        public List<Dimensioning> Dimensions { get; set; }



        public UpdateSpecificModel(IProjectDataService projectDataService, IRoofTypeDataService roofTypeDataService, IDimensioningDataService dimensioningDataService)
        {
            _projectDataService = projectDataService;
            _dimensioningDataService = dimensioningDataService;
            _roofTypeDataService = roofTypeDataService;
        }

        public void OnGet(int id)
        {

            DataBaseInfo = _projectDataService.Read(id);

            Dimensions = _dimensioningDataService.GetAll();

            RoofType = _roofTypeDataService.Read((int)DataBaseInfo.Assembly.RoofTypeId);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            
            _projectDataService.Update(DataBaseInfo);

            return RedirectToPage("/Intern/Requests");
        }
    }
}