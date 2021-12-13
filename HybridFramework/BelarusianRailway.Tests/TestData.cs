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
                    new TripDetails("Minsk", "Hrodna", new DateTime(2021, 12, 18)),
                    "https://pass.rw.by/en/route/?from=Minsk&from_exp=&from_esr=&to=Hrodna&to_exp=&to_esr=&front_date=18+Dec.+2021&date=2021-12-18");
            }
        }
    }
}