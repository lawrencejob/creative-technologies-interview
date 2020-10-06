namespace InterviewTest.Models 
{
    struct DelimiterOutput
    {
        /// <summary>
        /// The part of the string left after extracting delimiters from it
        /// </summary>
        public string Remainder;

        /// <summary>
        /// The delimiters declared by the string, or the default delimiter options
        /// </summary>
        public char[] Delimiters;
    }
}