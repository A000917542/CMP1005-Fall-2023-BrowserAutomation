using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.DevTools.V118.Network;
using OpenQA.Selenium.Chromium;

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
        opts.PageLoadStrategy = PageLoadStrategy.Eager;
        // opts.EnableMobileEmulation("iPhone XR");
        _webDriver = new ChromeDriver(opts);
    }

    // [TestMethod]
    // public void TestMethod1()
    // {
    //     _webDriver.Navigate().GoToUrl("https://www.google.ca");
    //     Assert.IsTrue(_webDriver.Title.Contains("Google"));
    // }

    [TestMethod]
    public void TestMethod2()
    {
        // Textbox - name=q
        // input - name=btnK
        _webDriver.Navigate().GoToUrl("https://www.google.ca");
        var searchBox = _webDriver.FindElement(By.CssSelector("textarea[name=q]"));
        var searchBtn = _webDriver.FindElement(By.CssSelector("input.gNO89b"));

        searchBox.SendKeys("Hello");
        searchBtn.Click();

        Assert.IsTrue(_webDriver.Title.Contains("Hello"));
    }

    [TestCleanup]
    public void Teardown()
    {
        _webDriver.Quit();
    }
}