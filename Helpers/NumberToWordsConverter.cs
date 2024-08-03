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
            string remainder = "";
            if (number == 0)
            {
                return string.Empty;
            }

            if (number < 20)
            {
                remainder = UnitsMap[number];
                return remainder;
            }

            if (number < 100)
            {
                string tens = TensMap[number / 10];
                remainder = UnitsMap[number % 10];
                return $"{tens}-{remainder}".TrimEnd('-');
            }

            if (number < 1000)
            {
                string hundreds = UnitsMap[number / 100];
                remainder = ConvertWholeNumberToWords(number % 100);
                return $"{hundreds} hundred {remainder}".Trim();
            }

            if (number < 1000000)
            {
                string thousands = ConvertWholeNumberToWords(number / 1000);
                remainder = ConvertWholeNumberToWords(number % 1000);
                return $"{thousands} thousand {remainder}".Trim();
            }

            if (number < 1000000000)
            {
                string millions = ConvertWholeNumberToWords(number / 1000000);
                remainder = ConvertWholeNumberToWords(number % 1000000);
                return $"{millions} million {remainder}".Trim();
            }

            string billions = ConvertWholeNumberToWords(number / 1000000000);
            remainder = ConvertWholeNumberToWords(number % 1000000000);
            return $"{billions} billion {remainder}".Trim();
        }

        private static string ConvertCentsToWords(int cents)
        {
            if (cents == 0)
                return "zero";

            return ConvertWholeNumberToWords(cents);
        }
    }
}
