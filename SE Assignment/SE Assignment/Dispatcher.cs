using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Dispatcher : Employee
    {
        private OrderCollection orderCollection;

        static private double totalCommission;
        
        public double TotalCommission
        {
            get { return totalCommission; }
            set { totalCommission = value; }
        }     
        

        public Dispatcher() { }

        public Dispatcher(string _name, int _employeeId, string _nric, 
                          char _gender, DateTime _datejoined, string _status, 
                          OrderCollection oc)
        {
            name = _name;
            employeeID = _employeeId;
            nric = _nric;
            gender = _gender;
            dateJoined = _datejoined;
            status = _status;
            orderCollection = oc;
        }
        
        public string getDispatcherDetails()
        {
            return ("Employee ID: " + employeeID + "\n" +
                    "Name : " + name + "\n" +
                    "NRIC : " + nric + "\n" +
                    "Gender : " + gender + "\n" +
                    "Status : " + status + "\n" +
                    "Date Joined : " + dateJoined + "\n" +
                    "Total commission earned this month: $" + TotalCommission);
        }
        
        public void viewAllDispatchers(List<Dispatcher> dList)
        {
            Console.WriteLine("\n======= DISPATCHER DETAILS =======");
            foreach (Dispatcher d in dList)
            {
                
                Console.WriteLine(d.getDispatcherDetails());
            }
        }

        // Assuming dispatchers earn $5 per commission or something
        public double addCommission(Order o, double tc)
        {
            // Reset commission if new month            
            if (DateTime.Now.Day == 1 && o.getCurrentState().getStateName() != "delivered")
            {
                TotalCommission = 0;
            }

            // Assign commission if delivery successful on new month
            else if (DateTime.Now.Day == 1 && o.getCurrentState().getStateName() == "delivered")
            {
                TotalCommission = tc + 5;
            }

            // Assign commission if delivery successful regardless
            else if (DateTime.Now.Day != 1 && o.getCurrentState().getStateName() == "delivered")
            {
                TotalCommission = tc + 5;
            }

            return TotalCommission;
        }

        public void dispatchOrder(Order o)
        {
            o.getCurrentState().dispatchOrder();
        }

        public void confirmDelivery(Order o)
        {
            o.getCurrentState().confirmOrder();
        }
    }
}
