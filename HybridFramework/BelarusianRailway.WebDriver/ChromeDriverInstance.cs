using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BelarusianRailway.WebDriver
{
    public static class ChromeDriverInstance
    {
        private static Lazy<IWebDriver> driver = new(() =>
        {
            var options = new ChromeOptions();
            options.AddArguments("--headless", "--no-sandbox", "--disable-dev-shm-usage");
            var chromeDriver = new ChromeDriver(options);

            chromeDriver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            chromeDriver.Manage().Window.Maximize();

            return chromeDriver;
        });

        public static IWebDriver Driver => driver.Value;

        public static void CloseBrowser()
        {
            driver.Value.Quit();
            driver = null;
        }
    }
}
