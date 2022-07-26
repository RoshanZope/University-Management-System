using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_Management_System
{
    public class Students
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int DeptId { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public int Semester { get; set; }
        public string Email { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int ZIP { get; set; }
        public string GenderText { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string SemesterName { get; set; }
    }
}