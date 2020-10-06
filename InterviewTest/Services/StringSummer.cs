using System.Linq;

namespace InterviewTest.Services
{
    public class StringSummer : IStringSummer
    {
        public int Add(string input) 
        {
            var numbers = input
                .Split(',', System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            return numbers.Sum();
        }
    }
}