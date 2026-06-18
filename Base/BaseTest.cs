using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace selenium_csharp_demo.Base;

public class BaseTest
{
    protected IWebDriver driver = null!;
    protected WebDriverWait wait = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://practicesoftwaretesting.com");

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(d => d.FindElement(By.Id("search-query")));

        wait.Until(d => d.FindElements(By.CssSelector("h5[data-test='product-name']")).Count > 0);
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}