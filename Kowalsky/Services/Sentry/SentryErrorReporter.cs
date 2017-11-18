using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SharpRaven.Core;
using SharpRaven.Core.Data;

namespace Kowalsky.Services.Sentry
{
    public class SentryErrorReporter : IErrorReporter
    {
        private readonly SentryOptions _options;

        public SentryErrorReporter(IOptions<SentryOptions> options)
        {
            _options = options.Value;
        }

        public async Task CaptureAsync(Exception exception)
        {
            if (!string.IsNullOrWhiteSpace(_options.Dsn))
            {
                var client = new RavenClient(_options.Dsn);
                await client.CaptureAsync(new SentryEvent(exception));
            }
        }

        public async Task CaptureAsync(string message)
        {
            if (!string.IsNullOrWhiteSpace(_options.Dsn) && !string.IsNullOrWhiteSpace(message))
            {
                var client = new RavenClient(_options.Dsn);
                await client.CaptureAsync(new SentryEvent(message));
            }
        }
    }
}
