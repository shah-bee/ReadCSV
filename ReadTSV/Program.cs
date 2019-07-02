
using CsvHelper;
using MarkdownLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadTSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter file location!");
            var filePath = Console.ReadLine();
            Console.WriteLine("Sort results by column 'Start date' in ascending order [asc/desc]");
            var sortByStartDate = Console.ReadLine();
            Console.WriteLine("Filter results by Project Id");
            var projectId = Console.ReadLine();
            ReadData(filePath, sortByStartDate, projectId);

        }

        private static void ReadData(string filePath, string sortByStartDate, string projectId)
        {

            if (!File.Exists(filePath)) throw new FileNotFoundException();

            using (var reader = new StreamReader(filePath))
            {
                try
                {
                    var configuration = new CsvHelper.Configuration.Configuration();
                    configuration.IgnoreBlankLines = true;
                    configuration.ShouldSkipRecord = content =>
                    {
                        if (content[0].StartsWith("#"))
                            return true;
                        return false;
                    };
                    configuration.Delimiter = "\t";
                    var csvReader = new CsvReader(reader, configuration);
                    csvReader.Configuration.RegisterClassMap<ProjectModelMapper>();
                    var records = csvReader.GetRecords<ProjectModel>();
                    records = sortByStartDate.ToLowerInvariant().Equals("asc") ? records.OrderBy(o => o.StartDate) :
                         records.OrderByDescending(o => o.StartDate);
                    records = records.Where(o => o.ProjectId.Equals(projectId));
                    Console.WriteLine(records.ToMarkdownTable());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}