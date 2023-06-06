using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solar.Pages.Intern
{
    public class UpdateSpecificModel : PageModel
    {
        private IProjectDataService ProjectDataService;
        private IRoofTypeDataService RoofTypeDataService;

        private int id { get; set; }

        public Project DataBaseInfo { get; set; }
        public RoofType RoofType { get; set; }



        public UpdateSpecificModel(IProjectDataService projectDataService, IRoofTypeDataService roofTypeDataService)
        {
            ProjectDataService = projectDataService;
            RoofTypeDataService = roofTypeDataService;
        }

        public void OnGet(int id)
        {
            DataBaseInfo = ProjectDataService.Read(id);
            RoofType = RoofTypeDataService.Read((int)DataBaseInfo.Assembly.RoofTypeId);
        }

        //public async Task<IActionResult> OnPost(int id)
        //{


        //    return RedirectToPage($"/Intern/RequestsSpecific/{id}");
        //}
    }
}