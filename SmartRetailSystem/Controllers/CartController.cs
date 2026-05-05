using Microsoft.AspNetCore.Mvc;
using SmartRetailSystem.Models;
using SmartRetailSystem.Services;

namespace SmartRetailSystem.Controllers
{
	public class CartController : Controller
	{
		private static List<CartItem> cart = new();
		private readonly IProductService _service;

		public CartController(IProductService service)
		{
			_service = service;
		}

		public IActionResult Index()
		{
			return View(cart);
		}

		public IActionResult Add(int id)
		{
			var product = _service.GetById(id);

			var item = cart.FirstOrDefault(x => x.Product.Id == id);

			if (item == null)
				cart.Add(new CartItem { Product = product, Quantity = 1 });
			else
				item.Quantity++;

			return RedirectToAction("Index");
		}
	}
}