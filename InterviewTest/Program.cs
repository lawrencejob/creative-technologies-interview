using System;
using Microsoft.Extensions.DependencyInjection;
using InterviewTest.Services;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InterviewTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServices();

            var summer = serviceProvider.GetService<IStringSummer>();

            Console.WriteLine(summer.Add("1,2,3"));

            Console.WriteLine("Hello World!");
        }

        public static ServiceProvider BuildServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddLogging()
                .AddTransient<IStringSummer, StringSummer>()
                .AddTransient<IDelimiterService, DelimiterService>()
                .AddTransient<IParserService, ParserService>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.Configure<ParserOptions>(configuration.GetSection("ParserOptions"));

            return serviceCollection.BuildServiceProvider();
        }
    }
}
