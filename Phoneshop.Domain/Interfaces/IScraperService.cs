using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IScraperService
    {
        Task<IEnumerable<Phone>> Get(string url, CancellationToken cancellationToken, SemaphoreSlim semaphore);
    }
}