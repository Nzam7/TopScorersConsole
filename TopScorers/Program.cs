using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TopScorers
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Nzam Pistis\Downloads\TestData.csv";  // Path to your CSV file
            var people = ParseCSV(filePath);

            if (people.Count > 0)
            {
                var maxScore = people.Max(p => p.Score);
                var topScorers = people.Where(p => p.Score == maxScore)
                                       .OrderBy(p => p.FullName)
                                       .ToList();

                foreach (var person in topScorers)
                {
                    Console.WriteLine(person.FullName);
                }
                Console.WriteLine($"Score: {maxScore}");
            }
        }

        static List<Person> ParseCSV(string filePath)
        {
            var people = new List<Person>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1)) // Skipping header line
            {
                var parts = line.Split(','); // Assuming tab-separated values
                if (parts.Length == 3)
                {
                    people.Add(new Person
                    {
                        FirstName = parts[0],
                        SecondName = parts[1],
                        Score = int.Parse(parts[2])
                    });
                }
            }

            return people;
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Score { get; set; }

        public string FullName => $"{FirstName} {SecondName}";
    }
}
