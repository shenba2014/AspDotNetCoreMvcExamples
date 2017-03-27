using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomViewComponent.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CustomViewComponent.Controllers
{
	[ViewComponent(Name = "ComboComponent")]
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

		public IViewComponentResult Invoke() => new ViewViewComponentResult
		{
			ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData,
		_repository.Cities)
		};
	}
}
