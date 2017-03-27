using System.Collections.Generic;

namespace CustomViewComponent.Models
{
	public interface IRepository
	{
		IEnumerable<City> Cities { get; }

		void AddCity(City newCity);
	}
}