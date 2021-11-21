using System;
using NUnit.Framework;
using VerificationService;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable SA1600 // Elements should be documented

namespace BookClass.Tests
{
    [TestFixture]
    public class IsbnVerifierTests
    {
        [TestCase("0-545-01022-5")]
        [TestCase("0-198-53453-1")]
        [TestCase("9781861972712")]
        [TestCase("978-0-545-01022-1")]
        [TestCase("978-9-667-34329-3")]
        [TestCase("039304002X")]
        public void IsValid_ISBNIsValid_ReturnsTrue(string isbn) => Assert.True(IsbnVerifier.IsValid(isbn));

        [TestCase("")]
        [TestCase("969-7343-29-4")]
        [TestCase("978-1-681-972-2")]
        [TestCase("978-1-681-97271-2")]
        [TestCase("978-1-861-97371-2")]
        [TestCase("978-966-2046-62-7")]
        [TestCase("96-67343-29-4")]
        public void IsValid_ISBNIsNotValid_ReturnsFalse(string isbn) => Assert.False(IsbnVerifier.IsValid(isbn));

        [Test]
        public void IsValid_ISBNIsNull_TrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => IsbnVerifier.IsValid(null));
    }
}
