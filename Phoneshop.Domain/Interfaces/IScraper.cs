using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces;

public interface IScraper
{
    bool CanExecute(string url);
    Task<IEnumerable<Phone>> Execute(string url, CancellationToken cancellationToken, SemaphoreSlim semaphore);
}