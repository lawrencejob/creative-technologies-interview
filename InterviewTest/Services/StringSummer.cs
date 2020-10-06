using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace InterviewTest.Services
{
    public class StringSummer : IStringSummer
    {

        IDelimiterService _delimiterService;
        IParserService _parserService;

        StringSummer(DelimiterService delimiterService)
        {
            _delimiterService = delimiterService;
        }

        public int Add(string input) 
        {
            var delimitedBody = _delimiterService.ExtractDelimiters(input);

            // deal with the special case of an empty input
            if (input == "") {
                return 0;
            }

            var numbersAsStrings = _parserService.ParseNumbers(delimitedBody.Delimiters, delimitedBody.Remainder);

            // look for and handle any negative numbers
            if (numbersAsStrings.Any( x => x < 0)) {

                throw new Exception($"Negatives not allowed: {string.Join(", ", numbersAsStrings.Where(x => x < 0))}");
            }

            // sum all the numbers below 1000
            return numbersAsStrings
                .Where(x => x <= 1000)
                .Sum();
        }
    }
}