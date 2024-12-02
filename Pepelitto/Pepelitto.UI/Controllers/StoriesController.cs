using Microsoft.AspNetCore.Mvc;

namespace Pepelitto.UI.Controllers
{
	[Route("stories/{id}/{action}")]
	public class StoriesController : Controller
	{
		public StoriesController()
		{

		}
		public IActionResult Index(string id)
		{
			return View();
		}
	}
}
