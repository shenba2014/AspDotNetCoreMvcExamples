using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware.Middlewares
{
    public class EditContextMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public EditContextMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["IEBrowser"] = httpContext.Request.Headers["User-Agent"]
                .Any(v => v.ToLower().Contains("trident"));
            await _nextDelegate.Invoke(httpContext);
        }
    }
}
