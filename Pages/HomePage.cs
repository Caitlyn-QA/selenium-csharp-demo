using OpenQA.Selenium;

namespace selenium_csharp_demo.Pages;

public class HomePage
{
    private readonly IWebDriver driver;

    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
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
    }

}