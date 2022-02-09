// See https://aka.ms/new-console-template for more information

using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace CSVFileUI
{
    class Program
    {
        private static IConfiguration _config;
        private static string csvFile;
        private static FileDataAccess db = new FileDataAccess();

        static void Main(string[] args)
        {
            InitializeConfiguration();

            csvFile = _config.GetValue<string>("CsvFile");

            var students = db.ReadAllRecords(csvFile);

            foreach(var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} born {student.DateOfBirth}" +
                    $" residing at {student.Street} in {student.City}, {student.StateAndZip}.");
                Console.WriteLine($"{student.FirstName} is in {student.Grade} grade with a {student.GPA} gpa"); 
            }


            Console.ReadLine();
        }

        public static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            _config = builder.Build();
        }
    }
}
