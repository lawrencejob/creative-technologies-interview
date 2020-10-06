using System;
using Microsoft.Extensions.DependencyInjection;
using InterviewTest.Services;

namespace InterviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServices();

            var summer = serviceProvider.GetService<IStringSummer>();

            Console.WriteLine(summer.Add("1,2,3"));

            Console.WriteLine("Hello World!");
        }

        static private ServiceProvider BuildServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IStringSummer, StringSummer>()
                .AddSingleton<IDelimiterService, DelimiterService>()
                .AddSingleton<IParserService, ParserService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
