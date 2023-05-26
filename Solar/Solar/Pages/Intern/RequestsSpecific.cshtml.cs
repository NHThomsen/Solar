using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;
using Solar.Models.Static;
using Solar.Services.Interfaces;
using Solar.Services.StaticServices;

namespace Solar.Pages.Intern
{
    public class RequestSpecific : PageModel
    {
        private IProjectDataService ProjectDataService;
        private IRoofTypeDataService RoofTypeDataService;
        private IEmailSenderService _emailSender;

        private int Id { get; set; }

        public Project DataBaseInfo { get; set; }
        public RoofType RoofType { get; set; }
        public EmailClient Sender { get; set; }
        public EmailClient Reciever { get; set; }
        public string GoogleMapsData { get; set; }
        public RequestSpecific(IProjectDataService projectDataService, IRoofTypeDataService roofTypeDataService, IEmailSenderService emailSender) 
        {
            ProjectDataService = projectDataService;
            RoofTypeDataService = roofTypeDataService;
            _emailSender = emailSender;

        }
        public void OnGet(int id)
        {

            DataBaseInfo = ProjectDataService.Read(id);
            RoofType = RoofTypeDataService.Read((int)DataBaseInfo.Assembly.RoofTypeId);
           
            GoogleMapsData = $"{DataBaseInfo.Address}+{DataBaseInfo.Zip}";
            GoogleMapsData.Replace(" ", "+");
            Id = id;

            Sender = new EmailClient("SolarTestClient@hotmail.com", "Solar123456");
            Reciever = new EmailClient(DataBaseInfo.User.Username);
        }

        public async Task<IActionResult> OnPost(int id)
        {

            Project ProjectDataChange = ProjectDataService.Read(id);
            ProjectDataChange.StatusId = ProjectDataChange.StatusId + 1;
            ProjectDataService.Update(ProjectDataChange);

            OnGet(id);
            await _emailSender.SendEmailAsync(Sender, Reciever, $"Tilbud på solceller på adressen: {ProjectDataChange.Address}", "Tilbud");

            return RedirectToPage("Requests");
        }
    }
}
