using System;
using System.Collections.Generic;

/*
UnitsMap and TensMap: Arrays for quick lookup of words for numbers 0-19 and tens 20-90.
Convert Method: Takes a decimal number, splits it into whole and decimal parts, and converts each to words.
ConvertWholeNumberToWords: Recursively converts numbers to words for thousands, millions, etc.
ConvertCentsToWords: Converts cents to words.
*/
namespace ChequeWriterApp
{
    public class NumberToWordsConverter
    {
        private static readonly string[] UnitsMap = {
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private static readonly string[] TensMap = {
            "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        public static string Convert(decimal number)
        {
            if (number == 0)
            {
                return "Zero dollars";
            }

            var parts = number.ToString("0.00").Split('.');
            int wholePart = int.Parse(parts[0]);
            int decimalPart = int.Parse(parts[1]);

            string dollars = ConvertWholeNumberToWords(wholePart);
            string cents = ConvertCentsToWords(decimalPart);

            return $"{dollars} dollars and {cents} cents";
        }

        private static string ConvertWholeNumberToWords(int number)
        {
            if (number == 0)
                return string.Empty;

            if (number < 20)
                return UnitsMap[number];

            if (number < 100)
                return $"{TensMap[number / 10]}-{UnitsMap[number % 10]}".TrimEnd('-');

            if (number < 1000)
                return $"{UnitsMap[number / 100]} hundred {ConvertWholeNumberToWords(number % 100)}".Trim();

            if (number < 1000000)
                return $"{ConvertWholeNumberToWords(number / 1000)} thousand {ConvertWholeNumberToWords(number % 1000)}".Trim();

            if (number < 1000000000)
                return $"{ConvertWholeNumberToWords(number / 1000000)} million {ConvertWholeNumberToWords(number % 1000000)}".Trim();

            return $"{ConvertWholeNumberToWords(number / 1000000000)} billion {ConvertWholeNumberToWords(number % 1000000000)}".Trim();
        }

        private static string ConvertCentsToWords(int cents)
        {
            if (cents == 0)
                return "zero";

            return ConvertWholeNumberToWords(cents);
        }
    }
}
