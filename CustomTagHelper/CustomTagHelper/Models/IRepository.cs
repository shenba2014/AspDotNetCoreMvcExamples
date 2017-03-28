using System.Collections.Generic;

namespace CustomTagHelper.Models
{
	public interface IRepository
	{
		IEnumerable<City> Cities { get; }

		void AddCity(City newCity);
	}
}