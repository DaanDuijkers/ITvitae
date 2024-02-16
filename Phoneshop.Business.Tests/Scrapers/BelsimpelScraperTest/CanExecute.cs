using Xunit;

namespace Phoneshop.Business.Tests.Scrapers.BelsimpelScraperTest
{
    public class CanExecute : BelsimpelTestBase
    {
        [Fact]
        public void Should_Be_Possible_To_Execute()
        {
            bool canExecute = _scraper.CanExecute("https://www.belsimpel.nl/telefoon");

            Assert.True(canExecute);
        }

        [Fact]
        public void Should_Not_Be_Possible_To_Execute()
        {
            bool canExecute = _scraper.CanExecute("test.html");

            Assert.False(canExecute);
        }
    }
}