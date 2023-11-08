using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace CMP_1005_Fall_2023_Testing;

[TestClass]
public class UnitTest1
{
    private IWebDriver _webDriver;

    public UnitTest1()
    {
        var config = new WebDriverManager.DriverConfigs.Impl.ChromeConfig();
        new DriverManager().SetUpDriver(config);
    }

    [TestInitialize]
    public void Setup()
    {
        var opts = new ChromeOptions();
        // opts.PageLoadStrategy = PageLoadStrategy.Eager;
        // opts.EnableMobileEmulation("iPhone XR");
        _webDriver = new ChromeDriver(opts);
    }

    [TestMethod]
    public void TestMethod1()
    {
        _webDriver.Navigate().GoToUrl("https://www.webscraper.io/test-sites/e-commerce/static");
        var heading = _webDriver.FindElement(By.CssSelector(".jumbotron > h1"));
        // Console.WriteLine(heading.Text);
        Assert.IsTrue(heading.Text.Contains("training"));
    }

    [TestMethod]
    public void TestMethod2()
    {
        _webDriver.Navigate().GoToUrl("https://www.webscraper.io/test-sites/e-commerce/static");
        var phoneLink = _webDriver.FindElement(By.CssSelector("a.category-link[href$=phones]"));
        phoneLink.Click();
        var touchLink = _webDriver.FindElement(By.CssSelector("a.subcategory-link[href$=touch]"));
        Assert.IsNotNull(touchLink);
        Assert.AreEqual("Touch", touchLink.Text);
    }

    [TestMethod]
    public void TestMethodFindScrapedHeading()
    {
        _webDriver.Navigate().GoToUrl("https://www.webscraper.io/test-sites/e-commerce/static/phones");
        var heading = _webDriver.FindElement(By.CssSelector(".col-lg-9 > h2"));
        Assert.IsTrue(heading.Text.Equals("Top items being scraped right now"));        
        Assert.IsTrue(heading.Text.Contains("scraped"));
    }

    [TestMethod]
    public void TestMethod3()
    {
        _webDriver.Navigate().GoToUrl("https://www.webscraper.io/test-sites/e-commerce/static");
       var topItems =_webDriver.FindElement(By.CssSelector(".jumbotron + h2"));
       Assert.IsTrue(topItems.Text.Contains("scraped"));
    }

    [TestMethod]
    public void TestMethod4()
    {
        _webDriver.Navigate().GoToUrl("https://www.webscraper.io/test-sites/e-commerce/static");
    //    var topItems =_webDriver.FindElement(By.CssSelector(".jumbotron + h2"));
    //    Assert.IsTrue(topItems.Text.Contains("scraped"));
       var Lenovo = _webDriver.FindElement(By.LinkText("Lenovo ThinkPad Yoga 370 Black"));
       Lenovo.Click();
       var Price = _webDriver.FindElement(By.ClassName("float-end price pull-right"));
       Assert.AreEqual("$1362.24", Price.Text);
    }

    [TestCleanup]
    public void Teardown()
    {
        _webDriver.Quit();
    }
}