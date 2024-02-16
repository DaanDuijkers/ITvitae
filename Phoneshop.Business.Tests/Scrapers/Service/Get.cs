using Phoneshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Phoneshop.Business.Tests.Scrapers.Service
{
    public class Get : BaseServiceTests
    {
        [Fact]
        public void GetNullException()
        {
            _ = Assert.ThrowsAsync<ArgumentNullException>(() => scraperService.Get("", cancellationToken, semaphore));
        }

        [Fact]
        public async void GetList()
        {
            List<Phone> phones = (await scraperService.Get("\"C:\\Users\\daand\\source\\repos\\Phoneshop\\Phoneshop.Business.Tests\\Scrapers\\LocalHtml\\Belsimpel.html", cancellationToken, semaphore)).ToList();

            Assert.NotNull(phones);
        }
    }
}