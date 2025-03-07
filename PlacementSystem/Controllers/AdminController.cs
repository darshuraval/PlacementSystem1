using Microsoft.AspNetCore.Mvc;

namespace PlacementSystem.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
