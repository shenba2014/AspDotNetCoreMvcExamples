using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware.Middlewares
{
    public class ValidateBrowserMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public ValidateBrowserMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var isIeBrowser = httpContext.Items["IEBrowser"] as bool?;
            if (isIeBrowser.GetValueOrDefault())
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
