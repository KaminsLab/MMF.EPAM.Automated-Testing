using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace BelarusianRailway.PageObjects
{
    public class TripsPage : Page
    {
        private IReadOnlyCollection<IWebElement> Trips => 
            this.FindElementsBy(By.XPath("//div[@class='sch-table__body js-sort-body']"));
        
        public TripsPage(IWebDriver webDriver, ILogger logger, string entryUrl) 
            : base(webDriver, logger, entryUrl)
        {
        }

        public bool HasTrips(string from, string to, DateTime date)
        {
            this.logger.LogInformation($"Page verification with departure: {from}, reach: {to}, date: {date:M}");

            var validDeparture = this.FindElementsBy(By.XPath("//div[@class='sch-title__title h2']"))
                .FirstOrDefault(d => d.Text == $"{from} — {to},");

            var validDate = this.FindElementsBy(By.XPath("//div[@class='sch-title__date h3']"))
                .FirstOrDefault(d => d.Text.Contains($"{date.Day} {date:MMMM}"));

            return validDeparture is not null && validDate is not null && this.Trips.Count > 0;
        }

        public bool HasNoTrips()
        {
            this.logger.LogInformation($"Entered into HasNoTrips().");

            var message = this.FindElementsBy(By.ClassName("error_content"))
                .FirstOrDefault(e => e.Text == "No direct communication between stations");

            return message is not null && this.Trips.Count == 0;
        }
        
        public bool IsInvalidPlace()
        {
            this.logger.LogInformation($"Entered into IsInvalidPlace().");

            var message = this.FindElementsBy(By.ClassName("h3"))
                .FirstOrDefault(e => e.Text == "Please clarify arrival / departure stations");

            return message is not null && this.Trips.Count == 0;
        }

        public TripsPage OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(this.EntryUrl);
            this.logger.LogInformation($"Opened tickets page.");
            
            return this;
        }
    }
}