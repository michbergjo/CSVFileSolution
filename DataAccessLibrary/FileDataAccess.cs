using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class FileDataAccess
    {
        public List<StudentModel> ReadAllRecords(string csvFile)
        {
            if (!File.Exists(csvFile))
            {
                return new List<StudentModel>();
            }

            var listOfStudents = new List<StudentModel>();
            var lines = File.ReadAllLines(csvFile);

            for(int i = 1; i < lines.Length-1; i++)
            {
                StudentModel student = new StudentModel();
                var vals = lines[i].Split(',');

                if(vals.Length < 6)
                {
                    throw new Exception($"Invalid row of Data: {lines[i]}");
                }

                student.FirstName = vals[0];
                student.LastName = vals[1];
                student.DateOfBirth = vals[2];
                student.Street = vals[3];
                student.City = vals[4];
                student.StateAndZip = vals[5];
                student.Grade = vals[6];
                student.GPA = vals[7];

                listOfStudents.Add(student);

            }
            return listOfStudents;

        }

        public void WriteAllRecords(List<StudentModel> students, string csvFile)
        {
            List<string> lines = new List<string>();

            foreach (var student in students)
            {
                lines.Add($"{student.FirstName},{student.LastName},{student.DateOfBirth},{student.Street},{student.City},{student.StateAndZip},{student.Grade},{student.GPA}");
            }

            File.WriteAllLines(csvFile, lines);
        }
    }
}
