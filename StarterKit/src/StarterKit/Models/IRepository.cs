using System.Collections.Generic;

namespace StarterKit.Models
{
	public interface IRepository
	{
		IEnumerable<City> Cities { get; }

		void AddCity(City newCity);
	}
}