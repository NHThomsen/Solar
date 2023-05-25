using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Services.StaticServices;

namespace Solar.Pages.Intern
{
    public class Request : PageModel
    {
        private IProjectDataService ProjectDataService;
        public List<Project> AllProjects { get; set; }
        public Request(IProjectDataService projectDataService)
        {
            ProjectDataService = projectDataService;
        }
        public void OnGet()
        {
            AllProjects = ProjectDataService.GetAll();
        }
    }
}
