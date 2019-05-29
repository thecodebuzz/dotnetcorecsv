using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using TinyCsvParser;
using System.Linq;

namespace csv_dotnet_core
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<UserDetails> result;
            string jsonString;
            using (TextReader fileReader = File.OpenText("TestData.csv"))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                csv.Read();
                result = csv.GetRecords<UserDetails>().ToList();
            }

            jsonString = JsonConvert.SerializeObject(result);
            Console.WriteLine("Name " + "ID   " + "City  " + "Country");
            foreach (UserDetails details in result)
            {
                Console.WriteLine(details.Name + " " + details.ID + " " + details.City + " " + details.Country);
            }

            //converts this infromation to type of your choice dealing with
            jsonString = ReadCSVFile("TestData.csv");
            List<UserDetails> person = (List<UserDetails>)JsonConvert.DeserializeObject(jsonString, (typeof(List<UserDetails>)));
            Console.WriteLine("Name " + "ID   " + "City  " + "Country");
            foreach (UserDetails details in person)
            {
                Console.WriteLine(details.Name + " " + details.ID + " " + details.City + " " + details.Country);

            }

        }
        private static string ReadCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            string jsonString= string.Empty;
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields;
                    bool tableCreated = false;
                    while (tableCreated == false)
                    {
                        colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        tableCreated = true;
                    }
                    while (!csvReader.EndOfData)
                    {
                        csvData.Rows.Add(csvReader.ReadFields());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error:Parsing CSV";
            }
                //if everything goes well, create json string from table 
            jsonString = JsonConvert.SerializeObject(csvData);

            return jsonString;
        }

    }
}
