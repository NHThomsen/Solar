using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepThreeModel : PageModel
    {
        private IDimensioningDataService _DimensioningDataService;

        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public List<Dimensioning> Dimensions { get; set; }

        public ProjectStepThreeModel(IDimensioningDataService dimensioningDataService)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            _DimensioningDataService = dimensioningDataService;

        }
        public void OnGet()
        {
            Dimensions = _DimensioningDataService.GetAll();
        }

        public IActionResult OnPost()
        {
            GlobalProjectDataService.ProjectDataStepThree = ProjectData;

            if(ProjectData.DimensioningId == 2)
            {
                return RedirectToPage("/Ekstern/ProjectStepThreePointFive");
            }

            return RedirectToPage("/Ekstern/ProjectStepFour");
        }
    }
}
