using Phoneshop.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Phoneshop.Business.Tests.Scrapers.BelsimpelScraperTest
{
    public class Execute : BelsimpelTestBase
    {
        [Fact]
        public async void Should_Get_List_Of_Phones()
        {
            List<Phone> phones = new();

            foreach (var phone in await _scraper.Execute("Belsimpel.html", cancellationToken, semaphore))
            {
                phones.Add(phone);
            }

            Assert.Equal("iPhone 13 128GB Zwart", phones[0].Type.Trim());
            Assert.Equal("Galaxy A13 128GB A135 Zwart", phones[1].Type.Trim());
        }

        [Fact]
        public void Should_Get_Exception()
        {
            _ = Assert.ThrowsAsync<ArgumentNullException>(() => _scraper.Execute(null, cancellationToken, semaphore));
        }
    }
}