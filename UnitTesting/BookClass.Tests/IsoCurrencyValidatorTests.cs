using System;
using NUnit.Framework;
using VerificationService;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable SA1600 // Elements should be documented

namespace BookClass.Tests
{
    [TestFixture]
    public class IsoCurrencyValidatorTests
    {
        [TestCase("EUR")]
        [TestCase("USD")]
        [TestCase("UAH")]
        [TestCase("AMD")]
        [TestCase("BYN")]
        [TestCase("DKK")]
        [TestCase("HUF")]
        public void IsValid_ValidCurrency_ReturnsTrue(string currency)
            => Assert.True(IsoCurrencyValidator.IsValid(currency));

        [TestCase("Some currency")]
        [TestCase("CCC")]
        [TestCase("Rpfjoh")]
        [TestCase("$")]
        public void IsValid_NonExistentCurrency_ReturnsFalse(string currency)
            => Assert.False(IsoCurrencyValidator.IsValid(currency));

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void IsValid_CurrencyIsNullOrEmptyOrWhitespace_ThrowsArgumentException(string currency)
            => Assert.Throws<ArgumentException>(() => IsoCurrencyValidator.IsValid(currency));
    }
}