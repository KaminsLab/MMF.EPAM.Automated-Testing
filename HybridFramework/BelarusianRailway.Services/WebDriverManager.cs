﻿using System;
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

        public void DestroyDriver() => ChromeDriverInstance.CloseBrowser();
    }
}