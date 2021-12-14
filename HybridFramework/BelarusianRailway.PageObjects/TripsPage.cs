using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace BelarusianRailway.PageObjects
{
    public class TripsPage : Page
    {
        private IReadOnlyCollection<IWebElement> Trips => 
            this.FindElementsBy(By.XPath("//div[@class='sch-table__body js-sort-body']"));
        
        public TripsPage(IWebDriver webDriver, string entryUrl) : base(webDriver, entryUrl)
        {
        }

        public bool HasTrips(string from, string to, DateTime date)
        {
            var validDeparture = this.FindElementsBy(By.XPath("//div[@class='sch-title__title h2']"))
                .FirstOrDefault(d => d.Text == $"{from} — {to},");

            var validDate = this.FindElementsBy(By.XPath("//div[@class='sch-title__date h3']"))
                .FirstOrDefault(d => d.Text.Contains($"{date.Day} {date:MMMM}"));

            return validDeparture is not null && validDate is not null && this.Trips.Count > 0;
        }

        public bool HasNoTrips()
        {
            var message = this.FindElementsBy(By.ClassName("error_content"))
                .FirstOrDefault(e => e.Text == "No direct communication between stations");

            return message is not null && this.Trips.Count == 0;
        }
        
        public bool IsInvalidPlace()
        {
            var message = this.FindElementsBy(By.ClassName("h3"))
                .FirstOrDefault(e => e.Text == "Please clarify arrival / departure stations");

            return message is not null && this.Trips.Count == 0;
        }

        public override TripsPage OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(this.EntryUrl);

            return this;
        }
    }
}