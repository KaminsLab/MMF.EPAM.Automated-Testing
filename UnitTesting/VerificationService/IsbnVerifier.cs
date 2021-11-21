using System;
using System.Text.RegularExpressions;

namespace VerificationService
{
    /// <summary>
    /// Verifies if the string representation of number is a valid ISBN-10 or ISBN-13 identification number of book.
    /// </summary>
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 or ISBN-13 identification number of book.
        /// </summary>
        /// <param name="isbn">The string representation of book's isbn.</param>
        /// <returns>true if number is a valid ISBN-10 or ISBN-13 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if isbn is null.</exception>
        public static bool IsValid(string isbn) => IsValidTenFormat(isbn) || IsValidThirteenFormat(isbn);

        private static bool IsValidTenFormat(string number)
        {
            if (number is null)
            {
                throw new ArgumentNullException(nameof(number),"ISBN is null.");
            }
            
            const string pattern = @"^\d-?\d{3}-?\d{5}-?[0-9X]$";

            if (!Regex.IsMatch(number, pattern))
            {
                return false;
            }

            const int isbnSize = 10;
            int[] symbols = FilterDigits(number, isbnSize);
            symbols[^1] = number[^1] == 'X' ? 10 : (int)char.GetNumericValue(number[^1]);

            return FindSumTenFormat(symbols) % 11 == 0;
        }

        private static bool IsValidThirteenFormat(string number)
        {
            if (number is null)
            {
                throw new ArgumentNullException(nameof(number),"ISBN is null.");
            }

            const string pattern = @"^\d{3}-?\d-?\d{3}-?\d{5}-?\d$";
            
            if (!Regex.IsMatch(number, pattern))
            {
                return false;
            }
            
            const int isbnSize = 13;
            int[] digits = FilterDigits(number, isbnSize);
            int checkSum = FindSumThirteenFormat(digits);

            return 10 - (checkSum % 10) == digits[^1];
        }

        private static int[] FilterDigits(string number, int length)
        {
            int[] digits = new int[length];
            
            for (int i = 0, j = 0; j < digits.Length; i++)
            {
                if (number[i] != '-')
                {
                    digits[j++] = (int)char.GetNumericValue(number[i]);
                }
            }

            return digits;
        }

        private static int FindSumTenFormat(int[] digits)
        {
            int checkSum = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                checkSum += digits[i] * (digits.Length - i);
            }

            return checkSum;
        }
        
        private static int FindSumThirteenFormat(int[] digits)
        {
            int checkSum = 0;
            
            for (int i = 0; i < digits.Length - 1; i++)
            {
                int coefficient = i % 2 == 0 ? 1 : 3;
                checkSum += digits[i] * coefficient;
            }

            return checkSum;
        }
    }
}
