using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFiveModel : PageModel
    {

        public void OnGet()
        {
            System.Diagnostics.Debug.WriteLine(GlobalProjectDataService.ProjectDataStepOne.Assembly.RoofTypeId);
            Project pro = new Project();
            Assembly asmb = new Assembly();
            asmb.RoofTypeId = GlobalProjectDataService.ProjectDataStepOne.Assembly.RoofTypeId;
            pro.Assembly = asmb;
            GlobalProjectDataService.Merge();
        }

    }
}
