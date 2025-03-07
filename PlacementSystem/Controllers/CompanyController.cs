using Microsoft.AspNetCore.Mvc;

namespace PlacementSystem.Controllers
{
	public class CompanyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
