using BelarusianRailway.Models;
using BelarusianRailway.Services;
using NUnit.Framework;

namespace BelarusianRailway.Tests
{
    [TestFixture]
    public class HomePageTests
    {
        private WebDriverManager manager;
            
        [SetUp]
        public void Setup()
        {
            this.manager = new WebDriverManager();
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForAvailableTrips))]
        public void SearchTrips_Receive_Valid_TripDetails_Open_Page_With_Trips(TripDetails details, string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, this.manager.PassTripDetails(details));
        }
        
        [TearDown]
        public void CloseDriver()
        {
            this.manager.DestroyDriver();
        }
    }
}