using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.AccessControl;

namespace Solar.Pages.Ekstern
{
    public class FormularModel : PageModel
    {
        private IProjectDataService _service;

        public FormularModel(IProjectDataService service) 
        {
            service = _service;
        }

        [BindProperty]
        public Project project { get; set; }



        public void OnGet()
        {
        }
    }
}
