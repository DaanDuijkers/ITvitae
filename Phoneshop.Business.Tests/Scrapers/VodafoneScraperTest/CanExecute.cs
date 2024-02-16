using Xunit;

namespace Phoneshop.Business.Tests.Scrapers.VodafoneScraperTest;

public class CanExecute : VodafoneScaperTestBase {

    [Theory]
    [InlineData("https://www.vodafone.nl/telefoon/alle-telefoons", true)]
    [InlineData("https://www.vodafone.nl/telefoon/alle-telefoons/", true)]
    [InlineData("www.vodafone.nl/telefoon/alle-telefoons", true)]
    [InlineData("www.vodafone.nl/telefoon/alle-telefoons/", true)]
    [InlineData("vodafone.nl/telefoon/alle-telefoons", true)]
    [InlineData("vodafone.nl/telefoon/alle-telefoons/", true)]
    [InlineData("https://www.vodafone.nl/telefoon/alle-telefoon", false)]
    [InlineData("www.vodafone.nl/telefoon/alle-telefoon", false)]
    [InlineData("vodafone.nl/telefoon/alle-telefoon", false)]
    public void Should_Check_Url(string url, bool canExecute)
        => Assert.Equal(canExecute, _scraper.CanExecute(url));

}