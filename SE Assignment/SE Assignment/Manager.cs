using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Manager : Employee
    {
        private OrderCollection orderCollection;
        private DateTime companyStartDate;

        public DateTime CompanyStartDate {
            get { return companyStartDate; }
            set { companyStartDate = value; }
        }


        public Manager() { }
        public Manager(string name, int employeeId, string nric, char gender, DateTime datejoined, string status, OrderCollection oc, DateTime companyStartDate)
        {
            Name = name;
            EmployeeID = employeeId;
            NRIC = nric;
            Gender = gender;
            DateJoined = datejoined;
            Status = status;
            orderCollection = oc;
            CompanyStartDate = companyStartDate;
        }        

        public string getManagerDetails()
        {
            return ("Employee ID: " + EmployeeID + "\n" +
                    "Name : " + Name + "\n" +
                    "NRIC : " + NRIC + "\n" +
                    "Gender : " + Gender + "\n" +
                    "Status : " + Status + "\n" +
                    "Date Joined : " + DateJoined + "\n" +
                    "Company Start Date : " + CompanyStartDate);
        }        

        public void viewAllManagers(List<Manager> mList)
        {
            foreach (Manager m in mList)
            {
                Console.WriteLine("==================================");
                Console.WriteLine(m.getManagerDetails());
            }
        }
    }
}
