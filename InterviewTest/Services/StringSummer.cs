using System;
using System.Linq;

namespace InterviewTest.Services
{
    public class StringSummer : IStringSummer
    {
        public int Add(string input) 
        {

            if (input == "") {
                return 0;
            }

            var numbersAsStrings = input.Split(new char[] { ',', '\n'});

            if (numbersAsStrings.Contains(""))
            {
                throw new ArgumentException("Invalid argument - number fields (spaces between delimiters) cannot be empty");
            }

            return numbersAsStrings
                .Select(int.Parse)
                .Sum();
        }
    }
}