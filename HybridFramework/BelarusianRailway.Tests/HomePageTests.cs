using BelarusianRailway.Models;
using BelarusianRailway.Services;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NUnit.Framework;

namespace BelarusianRailway.Tests
{
    [TestFixture]
    public class HomePageTests
    {
        private WebDriverManager manager;
        private ILogger<HomePageTests> logger;

        [OneTimeSetUp]
        public void Setup()
        {
            ILoggerFactory loggerFactory = LoggerFactory
                .Create(builder => builder.AddNLog());

            this.logger = loggerFactory.CreateLogger<HomePageTests>();

            this.manager = new WebDriverManager(logger);
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForAvailableTrips))]
        public void SearchTrips_Receive_Valid_TripDetails_Open_Page_With_Trips(TripDetails details)
        {
            var url = this.manager.PassTripDetails(details);
            this.logger.LogInformation($"Received url: {url}");
            Assert.IsTrue(this.manager.VerifyPageWithTrips(url, details));
        }
        
        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForNotAvailableTrips))]
        public void SearchTrips_No_Communication_Between_Stations_Open_Page_Without_Trips(TripDetails details)
        {
            var url = this.manager.PassTripDetails(details);
            this.logger.LogInformation($"Received url: {url}");
            Assert.IsTrue(this.manager.VerifyPageWithoutTrips(url));
        }
        
        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForUnknownPlace))]
        public void SearchTrips_Receive_Unknown_Stations_Open_Page_Without_Trips(TripDetails details)
        {
            var url = this.manager.PassTripDetails(details);
            logger.LogInformation($"Received url: {url}");
            Assert.IsTrue(this.manager.VerifyPageWithUnknownPlace(url));
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            this.manager.DestroyDriver();
            this.logger.LogInformation($"Driver closed.");
        }
    }
}