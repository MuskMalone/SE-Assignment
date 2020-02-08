using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Employee
    {
        private int employeeID;
        private string name;
        private string nric;
        private char gender;
        private string status;
        private DateTime dateJoined;
        
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string NRIC
        {
            get { return nric; }
            set { nric = value; }
        }
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public DateTime DateJoined
        {
            get { return dateJoined; }
            set { dateJoined = value; }
        }
    }
}
