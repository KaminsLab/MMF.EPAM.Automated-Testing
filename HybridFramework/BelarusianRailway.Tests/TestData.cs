using System;
using System.Collections.Generic;
using BelarusianRailway.Models;
using NUnit.Framework;

namespace BelarusianRailway.Tests
{
    public sealed class TestData
    {
        public static IEnumerable<TestCaseData> TestCasesForAvailableTrips
        {
            get
            {
                yield return new TestCaseData(
                    new TripDetails("Minsk", "Hrodna", new DateTime(2021, 12, 18)));
                yield return new TestCaseData(
                    new TripDetails("Viciebsk", "Brest", new DateTime(2021, 12, 20)));
                yield return new TestCaseData(
                    new TripDetails("Maladziečna", "Hrodna", new DateTime(2021, 12, 25)));
            }
        }
    }
}