using System;
using System.Collections.Generic;
using InterviewTest.Models;

namespace InterviewTest.Services 
{

    /// <summary>
    /// Service responsible for parsing numbers from a string
    /// </summary>
    public interface IParserService
    {

        /// <summary>
        /// Parses a set of numbers using prescribed delimiters
        /// </summary>
        /// <param name="delimiters">An array of delimiters which can be used to separate the numbers</param>
        /// <param name="input">A string of numbers, each separated by at least one of the delimiters</param>
        /// <returns>An enumerable of numbers which pass validation requirements</returns>
        IEnumerable<int> ParseNumbers(char[] delimiters, string input);
    }
}
