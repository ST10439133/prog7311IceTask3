using Microsoft.AspNetCore.Mvc;
using SmartRetailSystem.Services;

namespace SmartRetailSystem.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _service;

		public ProductController(IProductService service)
		{
			_service = service;
		}

		public IActionResult Index()
		{
			var products = _service.GetAllProducts();
			return View(products);
		}
	}
}