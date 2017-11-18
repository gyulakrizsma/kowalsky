using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kowalsky.Services.Sentry
{
    /// <summary>
    /// https://aevitas.co.uk/logging-to-sentry-in-asp-net-core/
    /// </summary>
    public class SentryMiddleware
    {
        private readonly RequestDelegate _next;

        public SentryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IErrorReporter errorReporter)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await errorReporter.CaptureAsync(ex);

                // We're not handling, just logging. Throw it for someone else to take care of it.
                throw;
            }
        }
    }
}
