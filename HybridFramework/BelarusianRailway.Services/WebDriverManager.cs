using System;
using BelarusianRailway.Models;
using BelarusianRailway.PageObjects;
using BelarusianRailway.WebDriver;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace BelarusianRailway.Services
{
    public class WebDriverManager
    {
        private IWebDriver webDriver;
        private ILogger logger;

        public WebDriverManager(ILogger logger) => 
            (this.webDriver, this.logger) = logger is null 
                ? throw new ArgumentNullException(nameof(logger)) 
                : (ChromeDriverInstance.Driver, logger);
        
        public string PassTripDetails(TripDetails details)
        {
            var homePage = new HomePage(this.webDriver, this.logger);
            
            homePage.OpenPage()
                .EnterDeparturePlace(details.From)
                .EnterReachPlace(details.To)
                .SelectDate(details.DepartureDay)
                .SearchTrips();
            
            return homePage.CurrentUrl;
        }

        public bool VerifyPageWithTrips(string url, TripDetails details) =>
            new TripsPage(this.webDriver, this.logger, url).OpenPage().HasTrips(details.From, details.To, details.DepartureDay);
        
        public bool VerifyPageWithoutTrips(string url) =>
            new TripsPage(this.webDriver, this.logger, url).OpenPage().HasNoTrips();
        
        public bool VerifyPageWithUnknownPlace(string url) =>
            new TripsPage(this.webDriver, this.logger, url).OpenPage().IsInvalidPlace();

        public void DestroyDriver() => ChromeDriverInstance.CloseBrowser();
    }
}