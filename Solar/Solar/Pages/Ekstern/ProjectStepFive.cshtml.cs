using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solar.Models.Static;
using Solar.Services.Interfaces;
using Solar.Services.StaticServices;

namespace Solar.Pages.Ekstern
{
    public class ProjectStepFiveModel : PageModel
    {
        private IEmailSenderService _emailSender;
        [BindProperty]
        public Project ProjectData { get; set; }
        public Project ExistingData { get; set; }
        public Project InfoDump { get; set; }
        private EmailClient Sender { get; set; }
        private EmailClient Reciever { get; set; }

        public ProjectStepFiveModel(IEmailSenderService emailSender)
        {
            ExistingData = GlobalProjectDataService.ProjectDataNewProject;
            InfoDump = GlobalProjectDataService.Merge();
            _emailSender = emailSender;

            // Static mails for now -- TODO
            Sender = new EmailClient("SolarTestClient@hotmail.com", "Solar123456");
            Reciever = new EmailClient("Robbers1996@hotmail.com");
        }

        public void OnGet()
        {
            
           
        }

        public async Task<IActionResult> OnPost() 
        {
            await _emailSender.SendEmailAsync(Sender, Reciever, "Tilbudsanmodning er sendt til Solar", $" Info indtastet på sagen\nSagsinfo: {InfoDump.CaseName}\nAdresse: {InfoDump.Address}\nPostnr: {InfoDump.Zip}");
            await _emailSender.SendEmailAsync(Sender, Sender, $"Ny tilbudsanmodning på adressen {InfoDump.Address}", "Find sagen her: www.solar.dk ");

            return RedirectToPage("/Index");
        }

    }
}
