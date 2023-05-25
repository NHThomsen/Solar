using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;
using Solar.Services.StaticServices;

namespace Solar.Pages.Intern
{
    public class RequestSpecific : PageModel
    {
        private IProjectDataService ProjectDataService;
        private IRoofTypeDataService RoofTypeDataService;
        public Project DataBaseInfo { get; set; }
        public RoofType RoofType { get; set; }
        public RequestSpecific(IProjectDataService projectDataService, IRoofTypeDataService roofTypeDataService) 
        {
            ProjectDataService = projectDataService;
            RoofTypeDataService = roofTypeDataService;
        }
        public void OnGet(int id)
        {
            DataBaseInfo = ProjectDataService.Read(id);
            RoofType = RoofTypeDataService.Read((int)DataBaseInfo.Assembly.RoofTypeId);
        }
    }
}
