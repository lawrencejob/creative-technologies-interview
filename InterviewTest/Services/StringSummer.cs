using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace InterviewTest.Services
{
    public class StringSummer : IStringSummer
    {

        public int Add(string input) 
        {

            var delimiters = new char[] { ',', '\n'};

            // deal with the special case of an empty input
            if (input == "") {
                return 0;
            }

            // if there is a delimiter-specifying header in the file...
            if (input.StartsWith("//")) {

                // extract the new delimiter
                delimiters = new char[] { input[2] };

                // cut the delimiter section from the front of the string
                input = input.Substring(4);
            }

            var numbersAsStrings = ParseNumbers(delimiters, input);

            return numbersAsStrings.Sum();
        }

        private IEnumerable<int> ParseNumbers(char[] delimiters, string input) {

            // break up the string by the delimiters
            foreach (string current in input.Split(delimiters)) {

                System.Console.WriteLine($"Reading {current}");

                // make sure there are no double-delimiters (leaving empty strings after the split) e.g. "1,\n"
                if (string.IsNullOrWhiteSpace(current))
                {
                    throw new ArgumentException("Invalid argument - number fields (spaces between delimiters) cannot be empty");
                }

                // try to interpret the integer, and (yield) return if possible
                if (int.TryParse(current, NumberStyles.None, null, out var convertedInt)) {
                    yield return convertedInt;
                }
                else {
                    throw new ArgumentException($"Could not convert {current} to a number.");
                }
            }
        }
    }
}