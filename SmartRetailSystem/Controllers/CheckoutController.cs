using Microsoft.AspNetCore.Mvc;
using SmartRetailSystem.Models;

namespace SmartRetailSystem.Controllers
{
	public class CheckoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Success()
		{
			return View();
		}
	}
}