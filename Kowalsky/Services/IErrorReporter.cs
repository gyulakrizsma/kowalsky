using System;
using System.Threading.Tasks;

namespace Kowalsky.Services
{
    public interface IErrorReporter
    {
        Task CaptureAsync(Exception exception);

        Task CaptureAsync(string message);
    }
}
