using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware.Middlewares
{
    public class ContentMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public ContentMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync(
                    "Handled by content middleware", Encoding.UTF8);
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
