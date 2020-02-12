﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Manager : Employee
    {
        private OrderCollection orderCollection;
        private DateTime companyStartDate;

        public DateTime CompanyStartDate
        {
            get { return companyStartDate; }
            set { companyStartDate = value; }
        }

        public Manager() { }

        public Manager(int id, string _name, string _nric, char _gender, string _status,
                       OrderCollection oc, DateTime _dateJoined, DateTime startDate)
        {
            employeeID = id;
            name = _name;
            nric = _nric;
            gender = _gender;
            status = _status;
            orderCollection = oc;
            dateJoined = _dateJoined;
            companyStartDate = startDate;
        }
        
        public string getManagerDetails()
        {
            return ("Employee ID: " + employeeID + "\n" +
                    "Name : " + name + "\n" +
                    "NRIC : " + nric + "\n" +
                    "Gender : " + gender + "\n" +
                    "Status : " + status + "\n" +
                    "Date Joined : " + dateJoined + "\n" +
                    "Company Start Date : " + companyStartDate);
        }        

        public void viewAllManagers(List<Manager> mList)
        {
            foreach (Manager m in mList)
            {
                Console.WriteLine("==================================");
                Console.WriteLine(m.getManagerDetails());
            }
        }

        public FoodIterator CreateFoodIterator()
        {
            FoodIterator mc = new FoodCollection();
            Console.WriteLine("Created Menu Successfully!");
            return mc;
        }
    }
}
