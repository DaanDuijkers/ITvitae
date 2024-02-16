using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business.Services
{
    public class ScraperService : IScraperService
    {
        public IEnumerable<IScraper> scrapers;

        public ScraperService(IEnumerable<IScraper> scrapers)
        {
            this.scrapers = scrapers;
        }

        public async Task<IEnumerable<Phone>> Get(string url, CancellationToken cancelationToken, SemaphoreSlim semaphore)
        {
            var lists = await Task.WhenAll(
                    scrapers
                        .Where(s => s.CanExecute(url))
                        .Select(s => s.Execute(url, cancelationToken, semaphore))
                );
            return lists.SelectMany(l => l);
        }
    }
}