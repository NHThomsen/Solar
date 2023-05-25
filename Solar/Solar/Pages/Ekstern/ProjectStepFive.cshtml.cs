using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Models.Static;
using Solar.Services.Interfaces;
using Solar.Services.StaticServices;
using System.Diagnostics;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFiveModel : PageModel
    {
        private IEmailSenderService _emailSender;

        private IRoofTypeDataService _roofTypeDataService;

        private IRoofMaterialDataService _roofMaterielService;

        private IProjectDataService _service;



        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public Project InfoDump { get; set; }
        private EmailClient Sender { get; set; }
        private EmailClient Reciever { get; set; }
        
        public RoofType RoofType { get; set; }
        public RoofMaterial RoofMaterial { get; set; } 


        public ProjectStepFiveModel(IEmailSenderService emailSender, IRoofTypeDataService roofTypeDataService, IRoofMaterialDataService roofMaterielService, IProjectDataService service)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            InfoDump = GlobalProjectDataService.Merge();
            _emailSender = emailSender;

            _roofTypeDataService = roofTypeDataService;
            _roofMaterielService = roofMaterielService;

            // Static mails for now -- TODO
            Sender = new EmailClient("SolarTestClient@hotmail.com", "Solar123456");
            Reciever = new EmailClient("Robbers1996@hotmail.com");
            _service = service;
        }

        public void OnGet()
        {
            RoofType = _roofTypeDataService.Read((int)InfoDump.Assembly.RoofTypeId);
            RoofMaterial = _roofMaterielService.Read((int)InfoDump.Assembly.RoofMaterialId);

        }

        public async Task<IActionResult> OnPost() 
        {
            await _emailSender.SendEmailAsync(Sender, Reciever, "Tilbudsanmodning er sendt til Solar", $" Info indtastet på sagen\nSagsinfo: {InfoDump.CaseName}\nAdresse: {InfoDump.Address}\nPostnr: {InfoDump.Zip}");
            await _emailSender.SendEmailAsync(Sender, Sender, $"Ny tilbudsanmodning på adressen {InfoDump.Address}", "Find sagen her: www.solar.dk ");

            System.Diagnostics.Debug.WriteLine(InfoDump.Remarks);

           

            return RedirectToPage("/Index");
        }

    }
}
