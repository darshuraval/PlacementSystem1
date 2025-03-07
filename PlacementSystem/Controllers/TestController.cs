using Microsoft.AspNetCore.Mvc;

namespace PlacementSystem.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
