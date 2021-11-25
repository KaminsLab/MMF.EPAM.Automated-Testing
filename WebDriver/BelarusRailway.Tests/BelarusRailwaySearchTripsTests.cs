using System.Threading;
using BelarusRailway.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BelarusRailway.Tests
{
    [TestFixture]
    public class BelarusRailwaySearchTripsTests
    {
        private IWebDriver driver;
        
        [SetUp]
        public void InitDriver()
        {
            var option = new ChromeOptions();
            option.AddArguments("--headless", "--no-sandbox", "--disable-dev-shm-usage");
            driver = new ChromeDriver(option);
        }

        [Test]
        public void SearchTrips_Test()
        {
            var homePage = new HomePage(driver)
                .OpenPage();

            homePage.AcceptNotification()
                .EnterDeparturePlace("Minsk")
                .EnterReachPlace("Hrodna")
                .SelectDate("30 Nov. 2021")
                .SearchTrips();

            var expectedPageUrl =
                "https://pass.rw.by/en/route/?from=Minsk&from_exp=&from_esr=&to=Hrodna&to_exp=&to_esr=&front_date=30+Nov.+2021&date=2021-11-30";
            var expectedPage = new Page(driver, expectedPageUrl).OpenPage();

            Assert.AreEqual(homePage.CurrentUrl, expectedPage.CurrentUrl);
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
