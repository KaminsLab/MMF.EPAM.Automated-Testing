using System;
using BelarusianRailway.Models;
using BelarusianRailway.PageObjects;
using BelarusianRailway.WebDriver;
using OpenQA.Selenium;

namespace BelarusianRailway.Services
{
    public class WebDriverManager
    {
        private IWebDriver webDriver;

        public WebDriverManager() => this.webDriver = ChromeDriverInstance.Driver;
        
        public string PassTripDetails(TripDetails details)
        {
            var homePage = new HomePage(this.webDriver);
            
            homePage.OpenPage()
                .EnterDeparturePlace(details.From)
                .EnterReachPlace(details.To)
                .SelectDate(details.DepartureDay)
                .SearchTrips();
            
            return homePage.CurrentUrl;
        }

        public bool VerifyPageWithTrips(string url, TripDetails details) =>
            new TripsPage(this.webDriver, url).OpenPage().HasTrips(details.From, details.To, details.DepartureDay);
        
        public bool VerifyPageWithoutTrips(string url) =>
            new TripsPage(this.webDriver, url).OpenPage().HasNoTrips();
        
        public bool VerifyPageWithUnknownPlace(string url) =>
            new TripsPage(this.webDriver, url).OpenPage().IsInvalidPlace();

        public void DestroyDriver() => ChromeDriverInstance.CloseBrowser();
    }
}