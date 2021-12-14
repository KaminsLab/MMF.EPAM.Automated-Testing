using BelarusianRailway.Models;
using BelarusianRailway.Services;
using NUnit.Framework;

namespace BelarusianRailway.Tests
{
    [TestFixture]
    public class HomePageTests
    {
        private WebDriverManager manager;
            
        [OneTimeSetUp]
        public void Setup()
        {
            this.manager = new WebDriverManager();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForAvailableTrips))]
        public void SearchTrips_Receive_Valid_TripDetails_Open_Page_With_Trips(TripDetails details)
        {
            var url = this.manager.PassTripDetails(details);
            Assert.IsTrue(this.manager.VerifyPageWithTrips(url, details));
        }
        
        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForNotAvailableTrips))]
        public void SearchTrips_No_Communication_Between_Stations_Open_Page_Without_Trips(TripDetails details)
        {
            var url = this.manager.PassTripDetails(details);
            Assert.IsTrue(this.manager.VerifyPageWithoutTrips(url));
        }
        
        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForUnknownPlace))]
        public void SearchTrips_Receive_Unknown_Stations_Open_Page_Without_Trips(TripDetails details)
        {
            var url = this.manager.PassTripDetails(details);
            Assert.IsTrue(this.manager.VerifyPageWithUnknownPlace(url));
        }


        [OneTimeTearDown]
        public void CloseDriver()
        {
            this.manager.DestroyDriver();
        }
    }
}