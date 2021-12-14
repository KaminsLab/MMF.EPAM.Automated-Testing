using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace BelarusianRailway.PageObjects
{
    public class Page
    {
        public Page(IWebDriver webDriver, string entryUrl)
        {
            this.WebDriver = webDriver;
            this.EntryUrl = entryUrl;
            PageFactory.InitElements(webDriver, this);
        }

        protected IWebDriver WebDriver { get; }

        protected string EntryUrl { get; }

        public string CurrentUrl => this.WebDriver.Url;

        public virtual Page OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(this.EntryUrl);

            return this;
        }
        
        protected IWebElement FindBy(By key) => 
            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5))
                .Until(driver => driver.FindElement(key));
        
        protected IReadOnlyCollection<IWebElement> FindElementsBy(By key) => 
            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5))
                .Until(driver => driver.FindElements(key));
    }
}
