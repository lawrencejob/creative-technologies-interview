using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace InterviewTest.Services
{
    public class StringSummer : IStringSummer
    {

        private IDelimiterService _delimiterService;
        private IParserService _parserService;

        public StringSummer(IDelimiterService delimiterService, IParserService parserService)
        {
            _delimiterService = delimiterService;
            _parserService = parserService;
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