using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace InterviewTest.Services
{
    public class StringSummer : IStringSummer
    {

        public int Add(string input) 
        {

            var delimiters = new char[] { ',', '\n'};

            // if there is a delimiter-specifying header in the file...
            if (input.StartsWith("//")) {

                var split = input.Split('\n', 2);

                // extract the new delimiters (excluding //)
                delimiters = split[0].Substring(2).ToCharArray();

                // reset input to the 
                input = split[1];
            }

            // deal with the special case of an empty input
            if (input == "") {
                return 0;
            }

            var numbersAsStrings = ParseNumbers(delimiters, input);

            // look for and handle any negative numbers
            if (numbersAsStrings.Any( x => x < 0)) {

                throw new Exception($"Negatives not allowed: {string.Join(", ", numbersAsStrings.Where(x => x < 0))}");
            }

            // sum all the numbers below 1000
            return numbersAsStrings
                .Where(x => x <= 1000)
                .Sum();
        }

        private IEnumerable<int> ParseNumbers(char[] delimiters, string input) {

            // break up the string by the delimiters
            foreach (string current in input.Split(delimiters)) {

                // make sure there are no double-delimiters (leaving empty strings after the split) e.g. "1,\n"
                if (string.IsNullOrWhiteSpace(current))
                {
                    throw new ArgumentException("Invalid argument - number fields (spaces between delimiters) cannot be empty");
                }

                // try to interpret the integer, and (yield) return if possible
                if (int.TryParse(current, NumberStyles.Integer, null, out var convertedInt)) {
                    yield return convertedInt;
                }
                else {
                    throw new ArgumentException($"Could not convert {current} to a number.");
                }
            }
        }
    }
}