using Phoneshop.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Phoneshop.Business.Tests.Scrapers.VodafoneScraperTest;

public class Execute : VodafoneScaperTestBase
{

    [Fact]
    public async Task Should_Parse_Correctly()
    {
        // Arrange 
        var expected = new List<Phone> {
            new Phone {
                Id = 0,
                Type = "iPhone 13",
                Brand = new() { Name = "Apple"},
                Price = 744d
            },
            new Phone {
                Id = 0,
                Type = "Galaxy S22",
                Brand = new() { Name = "Samsung"},
                Price = 696d
            }
        };

        var result = new List<Phone>();

        // Act
        foreach (Phone p in await _scraper.Execute("Vodafone.html", cancellationToken, semaphore))
        {
            result.Add(p);
        }

        // Assert
        Assert.Equal(expected[0].FullName, result[0].FullName);
        Assert.Equal(expected[1].FullName, result[1].FullName);
    }

}