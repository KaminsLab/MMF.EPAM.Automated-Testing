using System;
using System.Globalization;

namespace VerificationService
{
    /// <summary>
    /// Class for validating currency strings.
    /// </summary>
    public static class IsoCurrencyValidator
    {
        /// <summary>
        /// Determines whether a specified string is a valid ISO currency symbol.
        /// </summary>
        /// <param name="currency">Currency string to check.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="currency"/> is a valid ISO currency symbol; <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if currency is null or empty or whitespace.</exception>
        public static bool IsValid(string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException("Currency is null or empty or whitespace");
            }

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            bool isValid = false;

            foreach (var culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.Name);
                if (currency.Equals(region.ISOCurrencySymbol))
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
