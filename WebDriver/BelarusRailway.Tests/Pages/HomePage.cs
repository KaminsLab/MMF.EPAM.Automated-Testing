﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BelarusRailway.Tests.Pages
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "https://pass.rw.by/en/?c=true")
        {
        }

        public IWebElement FromPlaceInput => this.FindBy(By.Id("one-way-raspFormFromTitle"));
        
        public IWebElement ToPlaceInput => this.FindBy(By.Id("one-way-raspFormToTitle"));

        public IWebElement Date => this.FindBy(By.XPath("html/body/div[1]/div[1]/div[1]/div/div/div/div[2]/main/div[1]/div[3]/div/div/div[1]/div[2]/div/div/div[2]/div/div/div[2]/div[1]/form/div/div[2]/div/div[1]/input[1]"));

        public IWebElement FindButton => this.FindBy(By.XPath("html/body/div[1]/div[1]/div[1]/div/div/div/div[2]/main/div[1]/div[3]/div/div/div[1]/div[2]/div/div/div[2]/div/div/div[2]/div[1]/form/div/div[3]/button"));

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

        public HomePage SelectDate(string date)
        {
            this.Date.SendKeys(date);

            return this;
        }

        public void SearchTrips() => this.FindButton.Click();

        private IWebElement FindBy(By key)
            => new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5))
                .Until(driver => driver.FindElement(key));

        public override HomePage OpenPage()
        {
            this.WebDriver.Navigate().GoToUrl(this.EntryUrl);

            return this;
        }
    }
}