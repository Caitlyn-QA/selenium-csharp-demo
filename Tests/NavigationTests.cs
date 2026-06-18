using selenium_csharp_demo.Base;
using selenium_csharp_demo.Pages;

namespace selenium_csharp_demo.Tests;

public class NavigationTests : BaseTest
{
    [Test]
    public void Open_Combination_Pliers_Product()
    {
        var homePage = new HomePage(driver, wait);

        var expectedUrl = homePage.GetCombinationPliersHref();

        homePage.OpenCombinationPliers();

        Assert.That( driver.Url,Does.Contain(expectedUrl));
    }
}