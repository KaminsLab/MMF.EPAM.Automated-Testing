using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BelarusianRailway.PageObjects
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver webDriver, ILogger logger) 
            : base(webDriver, logger, "https://pass.rw.by/en/?c=true")
        {
        }
        
        private IWebElement FromPlaceInput => this.FindBy(By.Id("one-way-raspFormFromTitle"));
        
        private IWebElement ToPlaceInput => this.FindBy(By.Id("one-way-raspFormToTitle"));

        private IWebElement Date => this.FindBy(By.XPath("//div[@id='filter-tab_2-1']//input[@placeholder='Choose date']"));
        
        private IWebElement FindButton => this.FindBy(By.XPath("//div[@id='filter-tab_2-1']//button[@type='submit'][normalize-space()='Find']"));

        public HomePage EnterDeparturePlace(string place)
        {
            this.FromPlaceInput.SendKeys(place);
            this.logger.LogInformation($"Entered departure place with value {nameof(place)} = {place}");
            return this;
        }

        public HomePage EnterReachPlace(string place)
        {
            this.ToPlaceInput.SendKeys(place);
            this.logger.LogInformation($"Entered reach place with value {nameof(place)} = {place}");
            return this;
        }

        public HomePage SelectDate(DateTime date)
        {
            this.logger.LogInformation($"Entered in method SelectDate() with parameters {date:M}");
            this.Date.Click();
            this.FindDay(date)?.Click();
            
            return this;
        }

        public void SearchTrips() => this.FindButton.Click();

        private IWebElement FindDay(DateTime date)
        {
            var months = new IWebElement[]
            {
                this.FindBy(By.XPath("//div[@class='ui-datepicker-group ui-datepicker-group-first']")),
                this.FindBy(By.XPath("//div[@class='ui-datepicker-group ui-datepicker-group-middle']")),
                this.FindBy(By.XPath("//div[@class='ui-datepicker-group ui-datepicker-group-last']"))
            };
            
            this.logger.LogTrace($"Count of found month = {months.Length}");
            
            var month = months.FirstOrDefault(m 
                => m.FindElement(By.ClassName("ui-datepicker-month")).Text == date.ToString("MMMM")
                   && m.FindElement(By.ClassName("ui-datepicker-year")).Text ==
                   date.Year.ToString());
            
            var days = month?.FindElements(By.ClassName("ui-state-default"));
            
            this.logger.LogTrace($"Count of days in month = {days?.Count}");

            return days?.FirstOrDefault(d => d.Text == date.Day.ToString());
        }
        
        public HomePage OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(this.EntryUrl);
            this.logger.LogInformation($"Opened home page.");
            return this;
        }
    }
}