using Microsoft.AspNetCore.Mvc;
using CustomTagHelper.Models;

namespace CustomTagHelper.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRepository _repository;

		public HomeController(IRepository repo)
		{
			_repository = repo;
		}

		public ViewResult Index() => View(_repository.Cities);

		public ViewResult Create() => View();

		[HttpPost]
		public IActionResult Create(City city)
		{
			_repository.AddCity(city);
			return RedirectToAction("Index");
		}
	}
}
