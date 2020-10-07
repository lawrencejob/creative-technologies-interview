using System;
using System.Collections.Generic;
using System.Globalization;

namespace InterviewTest.Services 
{

    /// <summary>
    /// Service responsible for parsing numbers from a string
    /// </summary>
    public class ParserService : IParserService
    {

        /// <summary>
        /// Parses a set of numbers using prescribed delimiters
        /// </summary>
        /// <param name="delimiters">An array of delimiters which can be used to separate the numbers</param>
        /// <param name="input">A string of numbers, each separated by at least one of the delimiters</param>
        /// <returns>An enumerable of numbers which pass validation requirements</returns>
        public IEnumerable<int> ParseNumbers(char[] delimiters, string input)
        {
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
