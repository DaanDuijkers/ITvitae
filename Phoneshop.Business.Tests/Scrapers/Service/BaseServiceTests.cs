using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Phoneshop.Business.Services;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Tests.Scrapers.Service
{
    public class BaseServiceTests
    {
        protected ScraperService scraperService;
        protected Mock<IEnumerable<IScraper>> mockedIRepository;

        protected CancellationTokenSource cancellationTokenSource;
        protected CancellationToken cancellationToken;
        protected SemaphoreSlim semaphore;

        public BaseServiceTests()
        {
            this.mockedIRepository = new Mock<IEnumerable<IScraper>>();
            // WL1: Since scraperService.Get is 
            // var lists = await Task.WhenAll(
            // scrapers
            //    .Where(s => s.CanExecute(url))
            //    .Select(s => s.Execute(url, cancelationToken, semaphore))
            //    );
            // return lists.SelectMany(l => l);
            // you need to mock the individual IScrapers

            Mock<IScraper> scraperMock = new();

            scraperMock.Setup(x =>
                x.CanExecute(It.IsAny<string>())).Returns(true);

            Phone fakePhone = new() { Type = "Test", Brand = new() { Name = "TestBrand" } };

            scraperMock.Setup(x =>
                x.Execute(It.IsAny<string>(), It.IsAny<CancellationToken>(),
                    It.IsAny<SemaphoreSlim>())).
                Returns(Task.FromResult(new List<Phone> { fakePhone }.AsEnumerable()));

            scraperService = new ScraperService(new List<IScraper> { scraperMock.Object });

            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = cancellationTokenSource.Token;
            this.semaphore = new SemaphoreSlim(5);
        }
    }
}