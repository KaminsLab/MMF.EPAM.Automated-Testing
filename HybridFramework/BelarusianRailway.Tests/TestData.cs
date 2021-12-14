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
                yield return new TestCaseData(
                    new TripDetails("Minsk", "Brest", new DateTime(2022, 1, 5)));
            }
        }
        
        public static IEnumerable<TestCaseData> TestCasesForNotAvailableTrips
        {
            get
            {
                yield return new TestCaseData(
                    new TripDetails("Minsk", "Lviv", new DateTime(2021, 12, 17)));
                yield return new TestCaseData(
                    new TripDetails("Hrodna", "Riga", new DateTime(2022, 1, 7)));
                yield return new TestCaseData(
                    new TripDetails("Maladziečna", "Kyiv", new DateTime(2021, 12, 25)));
            }
        }
        
        public static IEnumerable<TestCaseData> TestCasesForUnknownPlace
        {
            get
            {
                yield return new TestCaseData(
                    new TripDetails("Minsk", "fohif", new DateTime(2021, 12, 17)));
                yield return new TestCaseData(
                    new TripDetails("lggt", "Riga", new DateTime(2022, 1, 7)));
                yield return new TestCaseData(
                    new TripDetails("some place", "to", new DateTime(2021, 12, 25)));
            }
        }

    }
}