using System;
using InterviewTest.Models;
using Microsoft.Extensions.Options;

namespace InterviewTest.Services 
{

    /// <summary>
    /// Service responsible for interpreting the delimiter header from a number string
    /// </summary>
    public class DelimiterService : IDelimiterService
    {
        static readonly char[] DefaultDelimiters = new char[] { ',', '\n'};

        private IOptions<ParserOptions> _appSettings;

        public DelimiterService (
            IOptions<ParserOptions> appSettings
        )
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Extracts delimiters for a given string
        /// </summary>
        /// <param name="input">The string, optionally containing delimiters</param>
        /// <returns>A structure containing the set or default delimiters and the delimited body</returns>
        public DelimiterOutput ExtractDelimiters(string input)
        {
            var delimiters = DefaultDelimiters;

            if (!string.IsNullOrEmpty(_appSettings.Value.DefaultDelimiters))
            {
                delimiters = _appSettings.Value.DefaultDelimiters.ToCharArray();
            }

            // if there is a delimiter-specifying header in the file...
            if (input.StartsWith("//")) {

                var split = input.Split('\n', 2);

                // extract the new delimiters (excluding //)
                delimiters = split[0].Substring(2).ToCharArray();

                // reset input to the 
                input = split[1];

            }

            return new DelimiterOutput
            {
                Remainder = input,
                Delimiters = delimiters
            };
        }
    }
}
