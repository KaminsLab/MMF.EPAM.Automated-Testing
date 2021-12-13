using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BelarusianRailway.PageObjects
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "https://pass.rw.by/en/?c=true")
        {
        }
        
        public IWebElement FromPlaceInput => this.FindBy(By.Id("one-way-raspFormFromTitle"));
        
        public IWebElement ToPlaceInput => this.FindBy(By.Id("one-way-raspFormToTitle"));

        public IWebElement Date => this.FindBy(By.XPath("//div[@id='filter-tab_2-1']//input[@placeholder='Choose date']"));
        
        public IWebElement FindButton => this.FindBy(By.XPath("//div[@id='filter-tab_2-1']//button[@type='submit'][normalize-space()='Find']"));

        public HomePage EnterDeparturePlace(string place)
        {
            this.FromPlaceInput.SendKeys(place);
            return this;
        }

        public HomePage EnterReachPlace(string place)
        {
            this.ToPlaceInput.SendKeys(place);
            
            return this;
        }

        public HomePage SelectDate(DateTime date)
        {
            this.Date.Click();

            this.FindDay(date)?.Click();
            
            return this;
        }

        public void SearchTrips() => this.FindButton.Click();

        private IWebElement FindDay(DateTime date)
        {
            var months = this.FindElementsBy(By.XPath(
                "//div[@class='ui-datepicker-group ui-datepicker-group-first']"));
            
            var month = months.FirstOrDefault(m 
                => m.FindElement(By.ClassName("ui-datepicker-month")).Text == date.ToString("MMMM")
                   && m.FindElement(By.ClassName("ui-datepicker-year")).Text ==
                   date.Year.ToString());
            
            var days = month?.FindElements(By.ClassName("ui-state-default"));
            
            return days?.FirstOrDefault(d => d.Text == date.Day.ToString());
        }

        private IWebElement FindBy(By key) => 
            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5))
                .Until(driver => driver.FindElement(key));
        
        private IReadOnlyCollection<IWebElement> FindElementsBy(By key) => 
            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5))
                .Until(driver => driver.FindElements(key));

        public override HomePage OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(this.EntryUrl);

            return this;
        }
    }
}