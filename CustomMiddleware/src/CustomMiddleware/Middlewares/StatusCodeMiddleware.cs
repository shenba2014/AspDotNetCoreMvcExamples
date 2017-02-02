using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware.Middlewares
{
    public class StatusCodeMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public StatusCodeMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _requestDelegate.Invoke(httpContext);

            switch (httpContext.Response.StatusCode)
            {
                case 403:
                    httpContext.Response.StatusCode = 200;
                    await httpContext.Response.WriteAsync("IE not supported", Encoding.UTF8);
                    break;
                case 404:
                    await httpContext.Response.WriteAsync("No page found", Encoding.UTF8);
                    break;
            }
        }
    }
}
