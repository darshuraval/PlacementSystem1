using Microsoft.AspNetCore.Mvc;

namespace PlacementSystem.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
