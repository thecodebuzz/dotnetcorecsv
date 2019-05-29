using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TinyCsvParser;

namespace csv_dotnet_core
{
    partial class Program
    {
        static void Main(string[] args)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvUserDetailsMapping csvMapper = new CsvUserDetailsMapping();
            CsvParser<UserDetails> csvParser = new CsvParser<UserDetails>(csvParserOptions, csvMapper);
            var result = csvParser
                         .ReadFromFile(@"TestData.csv", Encoding.ASCII)
                         .ToList();

            Console.WriteLine("Name " + "ID   " + "City  " + "Country");

            foreach (var details in result)
            {
                Console.WriteLine(details.Result.Name + " " + details.Result.ID + " " + details.Result.City + " " + details.Result.Country);

            }
        }
    }
}
