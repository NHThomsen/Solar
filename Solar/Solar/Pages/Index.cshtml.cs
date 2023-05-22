using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solar.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			Status status = new Status();
			status.Status1 = "test";
			EFCStatusDataService statusDataService = new EFCStatusDataService();
			statusDataService.Create(status);
		}
	}
}