using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Program
    {
        // OBJECTS CREATED HERE
        static void initalizer(List<Manager> mList, List<Dispatcher> dList, List<Chef> cList, List<Customer>customerList, List<Receipt> rList)
        {
            OrderCollection oc = new OrderCollection();
            
            Order o1 = new Order(1, "new");
            Order o2 = new Order(2, "new");
            Order o3 = new Order(3, "new");
            Order o4 = new Order(4, "preparing");
            Order o5 = new Order(5, "delivered");

            oc.AddOrder(o1);
            oc.AddOrder(o2);
            oc.AddOrder(o3);
            oc.AddOrder(o4);
            oc.AddOrder(o5);

            Manager m1 = new Manager("Cheng En", 1, "S6666666X", 'M', DateTime.UtcNow, "On Duty", oc, DateTime.UtcNow);
            Manager m2 = new Manager("En En", 1, "S6666667X", 'M', DateTime.UtcNow, "On Duty", oc, DateTime.UtcNow);
            mList.Add(m1);
            mList.Add(m2);

            Chef c1 = new Chef("Cheng Hian", 1, "S7777777X", 'M', DateTime.UtcNow, "On Duty", oc);
            Chef c2 = new Chef("Hian Hian", 1, "S7777777X", 'M', DateTime.UtcNow, "On Duty", oc);
            
            Dispatcher d1 = new Dispatcher("Nikko", 2, "S3333333X", 'M', DateTime.UtcNow, "On Duty", oc);
            dList.Add(d1);

            Customer customer1 = new Customer("Victor", 100, 94204209, "Victor@daddy.com", "535 Clementi Rd, Singapore 599489");
            customerList.Add(customer1);

            Receipt receipt1 = new Receipt(100, DateTime.UtcNow, DateTime.UtcNow, "Breakfast meal", "Visa", 12.50);
            Receipt receipt2 = new Receipt(101, DateTime.UtcNow, DateTime.UtcNow, "Lunch meal", "Visa", 15);
            rList.Add(receipt1);
            rList.Add(receipt2);
        }

        // EMPLOYEE SCREEN
        static void employeeScreen(Manager m, List<Manager> mList, Chef c, List<Chef> cList, Dispatcher d, List<Dispatcher> dList)
        {
            while (true)
            {
                Console.WriteLine("\n ======= EMPLOYEE SCREEN =======");
                Console.WriteLine("[1] Manager");
                Console.WriteLine("[2] Chef");
                Console.WriteLine("[3] Dispatcher");

                Console.WriteLine("\n ======= RETURN  =======");
                Console.WriteLine("[4] Go to home screen \n");

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                // TO MANAGER SCREEN
                if (option == "1")
                {
                    managerScreen(m, mList);
                }

                // TO CHEF SCREEN
                else if (option == "2")
                {
                    chefScreen(c, cList);
                }

                // TO DISPATCHERS SCREEN
                else if (option == "3")
                {
                    dispatcherScreen(d, dList);
                }

                // HOMESCREEN
                else if (option == "4")
                {
                    Main();
                }
            }
        }

        // MANAGER SCREEN
        static void managerScreen(Manager m, List<Manager> mList)
        {
            List<Chef> cList = new List<Chef>();
            Chef c = new Chef();
            List<Dispatcher> dList = new List<Dispatcher>();
            Dispatcher d = new Dispatcher();

            while (true)
            {
                Console.WriteLine("\n ======= MANAGER SCREEN =======");
                Console.WriteLine("[1] View all manager details");
                Console.WriteLine("[2] Return to Employee Screen");

                Console.Write("Select an option:");
                string option = Console.ReadLine();

                if(option == "1")
                {
                    m.viewAllManagers(mList);
                }
                else if (option == "2")
                {
                    employeeScreen(m, mList, c, cList, d, dList);
                }
            }
        }

        // CHEF SCREEN
        static void chefScreen(Chef c, List<Chef> cList)
        {
            List<Manager> mList = new List<Manager>();
            Manager m = new Manager();

            List<Dispatcher> dList = new List<Dispatcher>();
            Dispatcher d = new Dispatcher();

            while (true)
            {
                Console.WriteLine("\n ======= CHEF SCREEN =======");
                Console.WriteLine("[1] Krabby patty secret formula");
                Console.WriteLine("[2] Return to Employee Screen");

                Console.Write("Select an option:");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("\n bitch u thot");
                }

                else if (option == "2")
                {
                    employeeScreen(m, mList, c, cList, d, dList);
                }

            }
        }

        // DISPATCHER SCREEN
        static void dispatcherScreen(Dispatcher d, List<Dispatcher> dList)
        {
            List<Manager> mList = new List<Manager>();
            Manager m = new Manager();

            List<Chef> cList = new List<Chef>();
            Chef c = new Chef();

            while (true)
            {
                Console.WriteLine("\n ======= DISPATCHER SCREEN =======");
                Console.WriteLine("[1] View all dispatcher details");
                Console.WriteLine("[2] Select a dispatcher");
                Console.WriteLine("[3] Return to Employee Screen");

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    d.viewAllDispatchers(dList);
                }
                else if (option == "3")
                {
                    employeeScreen(m, mList, c, cList, d, dList);
                }
            }
        }

        // CUSTOMER SCREEN
        static void customerScreen(Customer c, Receipt r, List<Receipt> rList)
        {
            while (true)
            {
                Console.WriteLine("\n ======= CUSTOMER SCREEN =======");
                Console.WriteLine("[1] View all receipts");

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    r.viewAllReceipt(rList);
                }
                if (option == "2")
                {
                }
            }
        }
        
        static void Main()
        {
            List<Manager> mList = new List<Manager>();
            Manager m = new Manager();

            List<Dispatcher> dList = new List<Dispatcher>();
            Dispatcher d = new Dispatcher();

            List<Chef> cList = new List<Chef>();
            Chef c = new Chef();

            List<Customer> customerList = new List<Customer>();
            Customer customer = new Customer();

            List<Receipt> rList = new List<Receipt>();
            Receipt r = new Receipt();

            initalizer(mList, dList, cList, customerList, rList);

            string accountType;

            Console.WriteLine("======= SELECT AN ACCOUNT =======");
            Console.WriteLine("[1] Employee");
            Console.WriteLine("[2] Customer");
            Console.WriteLine("[0] Get hacked");


            Console.WriteLine("\n ======= EXIT? =======");
            Console.WriteLine("[0] Fuck this I'm out");

            Console.Write("\n Select an Account type: ");

            accountType = Console.ReadLine();

            // EXIT APPLICATION
            if (accountType == "0")
            {
                Environment.Exit(0);
            }

            // GOTO EMPLOYEE SCREEN
            if (accountType == "1")
            {
                employeeScreen(m, mList, c, cList, d, dList);
            }
            
            // GOTO CUSTOMER SCREEN
            else if (accountType == "2")
            {
                customerScreen(customer, r, rList);
            }
            Console.ReadKey();
            
            //==== Required Function Number 5: View receipt details ====

            //==== END OF Required Function Number 5: View receipt details ====

            Console.ReadKey();
        }
    }
}
