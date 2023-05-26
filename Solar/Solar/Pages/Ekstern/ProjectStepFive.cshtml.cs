using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Models.Static;
using Solar.Services.Interfaces;
using Solar.Services.StaticServices;
using System.Diagnostics;
using System.Security.Claims;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFiveModel : PageModel
    {
        private IEmailSenderService _emailSender;

        private IRoofTypeDataService _roofTypeDataService;

        private IRoofMaterialDataService _roofMaterielService;

        private IProjectDataService _service;

        private EFCInstallerDataService _installerDataService;

        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public Project InfoDump { get; set; }
        private EmailClient Sender { get; set; }
        private EmailClient Reciever { get; set; }
        public RoofType RoofType { get; set; }
        public RoofMaterial RoofMaterial { get; set; }
        public string InstallerDepartment { get; set; }
        public string InstallerName { get; set; }
        public string InstallerPhone { get; set; }


        public ProjectStepFiveModel(IEmailSenderService emailSender, IRoofTypeDataService roofTypeDataService, IRoofMaterialDataService roofMaterielService, IProjectDataService service)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            InfoDump = GlobalProjectDataService.Merge();
            _emailSender = emailSender;

            _roofTypeDataService = roofTypeDataService;
            _roofMaterielService = roofMaterielService;

            _installerDataService = new EFCInstallerDataService();

            _service = service;
        }

        public void OnGet()
        {

            RoofType = _roofTypeDataService.Read((int)InfoDump.Assembly.RoofTypeId);
            RoofMaterial = _roofMaterielService.Read((int)InfoDump.Assembly.RoofMaterialId);

            InstallerDepartment = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Department;
            InstallerName = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).Installer1;
            InstallerPhone = _installerDataService.Read(int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value)).PhoneNumber;

        }

        public async Task<IActionResult> OnPost() 
        {
            Sender = new EmailClient("SolarTestClient@hotmail.com", "Solar123456");
            Reciever = new EmailClient(User.Identity.Name);

            await _emailSender.SendEmailAsync(Sender, Reciever, "Tilbudsanmodning er sendt til Solar", $" Info indtastet på sagen\nSagsinfo: {InfoDump.CaseName}\nAdresse: {InfoDump.Address}\nPostnr: {InfoDump.Zip}");
            await _emailSender.SendEmailAsync(Sender, Sender, $"Ny tilbudsanmodning på adressen {InfoDump.Address}", "Find sagen her: www.solar.dk ");

            InfoDump.StatusId = 1;
            InfoDump.UserId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value);

            _service.Create(InfoDump);

            return RedirectToPage("/Ekstern/SuccesRequest");
        }

    }
}
