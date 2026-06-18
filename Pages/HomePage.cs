using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace selenium_csharp_demo.Pages;

public class HomePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public HomePage(IWebDriver driver, WebDriverWait wait)
    {
        this.driver = driver;
        this.wait = wait;
    }

    private IWebElement SearchInput => driver.FindElement(By.Id("search-query"));

    private IWebElement SearchButton => driver.FindElement(By.CssSelector("button[type='submit']"));

    private IReadOnlyCollection<IWebElement> ProductTitles => driver.FindElements(By.CssSelector("h5[data-test='product-name']"));
    public List<string> GetProductTitles()
    {
        return ProductTitles.Select(title => title.Text).ToList();
    }

    public void Search(string searchText)
    {
        SearchInput.Clear();
        SearchInput.SendKeys(searchText);
        SearchButton.Click();
        wait.Until(d =>
        {
            var titles = d.FindElements(
                By.CssSelector("h5[data-test='product-name']")
            );

            return titles.Count > 0 &&
                   titles.Any(title =>
                       title.Text.ToLower().Contains(searchText.ToLower()));
        });
    }
    private IWebElement CombinationPliersCard => driver.FindElement(By.XPath("//h5[@data-test='product-name' and contains(text(),'Combination Pliers')]/ancestor::a"));

    public string GetCombinationPliersHref()
    {
        var href = CombinationPliersCard.GetAttribute("href");
        Assert.That(href, Is.Not.Null);

        return href!;
    }
    public void OpenCombinationPliers()
    {
        CombinationPliersCard.Click();
    }
}