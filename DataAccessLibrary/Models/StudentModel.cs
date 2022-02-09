using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateAndZip { get; set; }
        public string Grade { get; set; }
        public string GPA { get; set; }
    }
}
