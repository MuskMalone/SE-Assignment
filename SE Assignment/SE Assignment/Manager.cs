using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
     public class Manager : Employee, FoodAggregate
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

        List<FoodCollection> menuList = new List<FoodCollection>();

        public void ViewAllMenus()
        {
            for (int i = 0; i < menuList.Count(); i++)
            {
                Console.WriteLine();
                Console.WriteLine("Menu "+ menuList[i].MenuID+": "+menuList[i].Name);
                Console.WriteLine("Size: " + menuList[i].Size);
                Console.WriteLine(menuList[i].GetCurrent());
                while (menuList[i].HasNextFood())
                {
                    Console.WriteLine(menuList[i].NextFood().ToString());
                }
            }
        }

        public FoodIterator CreateFoodIterator(int id, string menuName)
        {
            FoodCollection fi = new FoodCollection(id, menuName);
            menuList.Add(fi);
            Console.WriteLine("Created Menu Successfully!");
            return fi;
        }

        public void editMenu(int id, FoodCollection fc)
        {
            for (int i = 0; i < menuList.Count() - 1; i++)
            {
                if (menuList[i].MenuID == id)
                {
                    menuList[i] = fc;
                    Console.WriteLine("Successfully Edited "+fc.Name+"!");
                }
            }
        }

        public void deleteMenu(int id)
        {
            for (int i = 0; i < menuList.Count() - 1; i++)
            {
                if (menuList[i].MenuID == id)
                {
                    menuList.RemoveAt(i);
                    Console.WriteLine("Menu Successfully Deleted!");
                }

            }
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
    }
}
