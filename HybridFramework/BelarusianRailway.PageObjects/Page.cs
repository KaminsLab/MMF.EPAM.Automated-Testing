using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace BelarusianRailway.PageObjects
{
    public class Page
    {
        public Page(IWebDriver webDriver, ILogger logger, string entryUrl)
        {
            this.WebDriver = webDriver;
            this.EntryUrl = entryUrl;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            PageFactory.InitElements(webDriver, this);
        }

        protected IWebDriver WebDriver { get; }
        
        protected ILogger logger { get; }

        protected string EntryUrl { get; }

        public string CurrentUrl => this.WebDriver.Url;
        
        protected IWebElement FindBy(By key) => 
            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5))
                .Until(driver => driver.FindElement(key));
        
        protected IReadOnlyCollection<IWebElement> FindElementsBy(By key) => 
            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5))
                .Until(driver => driver.FindElements(key));
    }
}
