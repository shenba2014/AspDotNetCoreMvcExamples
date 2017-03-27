using System.Linq;
using CustomViewComponent.Models;

namespace CustomViewComponent.ViewComponents
{
	public class PocoViewComponent
    {
	    private readonly IRepository _repository;

	    public PocoViewComponent(IRepository repository)
	    {
		    _repository = repository;
	    }

	    public string Invoke()
	    {
		    return $"{_repository.Cities.Count()} cities, "
		           + $"{_repository.Cities.Sum(c => c.Population)} people";
	    }
    }
}
