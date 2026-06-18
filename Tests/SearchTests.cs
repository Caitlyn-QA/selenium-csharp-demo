using selenium_csharp_demo.Base;
using selenium_csharp_demo.Pages;

namespace selenium_csharp_demo.Tests;

public class SearchTests : BaseTest
{
    [Test]
    public void Search_For_Saw()
    {
        var homePage = new HomePage(driver, wait);

        homePage.Search("saw");

        var titles = homePage.GetProductTitles();

        foreach (var title in titles)
        {
            Assert.That(title.ToLower(),Does.Contain("saw"));
        }
    }
}
