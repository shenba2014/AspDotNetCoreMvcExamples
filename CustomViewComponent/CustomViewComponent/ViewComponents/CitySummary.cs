using System;
using System.Linq;
using CustomViewComponent.Models;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace CustomViewComponent.ViewComponents
{
	public class CitySummary : ViewComponent
	{
		private readonly IRepository _repository;

		public CitySummary(IRepository repository)
		{
			_repository = repository;
		}

		public IViewComponentResult Invoke(string target)
		{
			target = target ?? RouteData.Values["id"] as string;
			var cities =
				_repository.Cities.Where(
					city => target == null || Compare(city.Country, target, StringComparison.OrdinalIgnoreCase) == 0).ToArray();
			return View(new CityViewModel
			{
				Cities = cities.Count(),
				Population = cities.Sum(c => c.Population)
			});
		}
	}
}
