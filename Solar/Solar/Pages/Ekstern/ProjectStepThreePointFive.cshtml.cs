using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepThreePointFiveModel : PageModel
    {
        private IConsumptionCategoryDataService _ConsCat;
        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public List<ConsumptionCategory> ConsCats { get; set; }
        public ProjectStepThreePointFiveModel(IDimensioningDataService dimensioningDataService, IConsumptionCategoryDataService consCat)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            _ConsCat = consCat;

        }
        public void OnGet()
        {
            ConsCats = _ConsCat.GetAll();
        }

        public IActionResult OnPost() 
        { 
            GlobalProjectDataService.ProjectDataStepThreePointFive = ProjectData;
            return RedirectToPage("/Ekstern/ProjectStepFour");
        }
    }
}
