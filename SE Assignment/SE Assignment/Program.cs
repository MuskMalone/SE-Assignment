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
        static void initalizer(List<Manager> mList, List<Dispatcher> dList, List<Chef> cList, List<Customer>customerList, List<Receipt> rList, List<Food> fList)
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

            //Food burger = new Food(1, "Beef Burger", "Lunch set", 7.50, "available");
            //Food steak = new Food(2, "steak", "dinner set", 13.50, "available");
            //fList.Add(steak);
            //fList.Add(burger);


            Manager m1 = new Manager(1, "Cheng En", "S6666666X", 'M',"On Duty", oc, DateTime.UtcNow, DateTime.UtcNow);
            Manager m2 = new Manager(1,"cheng en", "S6666667X", 'M',"On Duty", oc, DateTime.UtcNow, DateTime.UtcNow);
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
        static void customerScreen(Customer c, Receipt r, List<Receipt> rList, Food f, List<Food> fList)
        {
            while (true)
            {
                Console.WriteLine("\n ======= CUSTOMER SCREEN =======");
                Console.WriteLine("[2] Make New Order");
                Console.WriteLine("[1] View All Receipts");
                Console.WriteLine("[0] Homepage");
                double publicamount = 0.00;

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("\n ======= select resteraunt =======");
                    Console.WriteLine("[1] Krusty Krab");
                    Console.Write("Select an option: ");
                    string resterauntoption = Console.ReadLine();

                     
                    if (resterauntoption == "1")
                    {
                        Console.WriteLine("\n ======= Food Items =======");
                        f.viewAllFood(fList);
                        Console.Write("select food item: ");
                        string foodoption = Console.ReadLine();
                        Console.WriteLine("\n ======= Delivery option =======");
                        Console.WriteLine("[1] Standard delivery");
                        Console.WriteLine("[2] Express delivery");
                        Console.Write("Select an option: ");
                        string deliveryoption = Console.ReadLine();

                        foreach (Food finder in fList)
                        {

                           if (finder.FoodID.ToString() == foodoption)
                            {
                               

                                if (deliveryoption == "1")
                                {
                                    double paymentamount = finder.Price;
                                    //no express fee, delivery 
                                    Console.WriteLine("total to pay is " + paymentamount.ToString());
                                    publicamount = paymentamount;
                                }

                               else
                                {
                                    double paymentamount = finder.Price;
                                    //express fee is 3 dollars
                                    paymentamount = paymentamount + 3.00;
                                    Console.WriteLine("total to pay is " + paymentamount.ToString());
                                    publicamount = paymentamount;
                                } 
                            }

                        }

                        Console.WriteLine("\n ======= Payment option =======");
                        Console.WriteLine("[1] Credit Card");
                        Console.WriteLine("[2] Paypal");
                        Console.Write("Select an option: ");
                        string paymentoption = Console.ReadLine();

                        if (paymentoption == "1")
                        {
                            Console.WriteLine("Credit Card selected");
                        }

                        if (paymentoption == "2")
                        {
                            Console.WriteLine("Paypal selected");
                        }




                    }
                }
                if (option == "2")
                {
                    r.viewAllReceipt(rList);
                }
                if (option == "0")
                {
                   Main();
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

            List<Food> fList = new List<Food>();
            Food f = new Food();

            initalizer(mList, dList, cList, customerList, rList, fList);

            string accountType;

            Console.WriteLine("======= SELECT AN ACCOUNT =======");
            Console.WriteLine("[1] Employee");
            Console.WriteLine("[2] Customer");
            Console.WriteLine("[0] Get hacked");


            Console.WriteLine("\n ======= EXIT? =======");
           

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
                customerScreen(customer, r, rList, f, fList);
            }
            Console.ReadKey();
            
            //==== Required Function Number 5: View receipt details ====

            //==== END OF Required Function Number 5: View receipt details ====

            Console.ReadKey();
        }
    }
}
