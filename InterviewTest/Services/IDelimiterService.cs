using System;
using InterviewTest.Models;

namespace InterviewTest.Services 
{

    /// <summary>
    /// Service responsible for interpreting the delimiter header from a number string
    /// </summary>
    public interface IDelimiterService
    {
        /// <summary>
        /// Extracts delimiters for a given string
        /// </summary>
        /// <param name="input">The string, optionally containing delimiters</param>
        /// <returns>A structure containing the set or default delimiters and the delimited body</returns>
        DelimiterOutput ExtractDelimiters(string input);
    }
}
