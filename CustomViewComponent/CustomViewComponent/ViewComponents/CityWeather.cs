using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CustomViewComponent.ViewComponents
{
	public class CityWeather : ViewComponent
	{
		private static readonly Regex WeatherRegex = new Regex(@"<img id=cur-weather class=mtt title="".+?"" src=""//(.+?.png)"" width=80 height=80>");

		public async Task<IViewComponentResult> InvokeAsync(string country, string city)
		{
			city = city.Replace(" ", string.Empty);
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync($"https://www.timeanddate.com/weather/{country}/{city}");
				var content = await response.Content.ReadAsStringAsync();
				var match = WeatherRegex.Match(content);
				var imageUrl = match.Groups[1].Value;
				return View("Default", imageUrl);
			}
		}
	}
}
