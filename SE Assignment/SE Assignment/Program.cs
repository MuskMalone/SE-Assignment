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
        static void customerScreen(Customer c, Receipt r, List<Receipt> rList, Food f, List<Food> fList, MenuCollection setM, MenuCollection alcM)
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
                else if (option == "2")
                {
                    //r.viewAllReceipt(rList);
                    while (true) {
                        Console.WriteLine("\n ======= What would you like to buy? =======");
                        Console.WriteLine("[1] Menu");
                        Console.WriteLine("[2] À la carte");
                        Console.WriteLine("[3] Back");
                        Console.Write("Select an option: ");
                        string orderOption = Console.ReadLine();

                        if (orderOption == "1")
                        {
                            setM.ListAllMenus();
                            Console.Write("Add to Cart: ");
                            string foodChoice = Console.ReadLine();
                            // Call customer function
                        }
                        else if (orderOption == "2")
                        {
                            alcM.GetCurrent().ToString();
                            Console.Write("Add to Cart: ");
                            string foodChoice = Console.ReadLine();
                            // Call customer function
                        }
                        else if (orderOption == "3")
                        {
                            break;
                        }
                    }
                }
                else if (option == "0")
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

            MenuCollection setMenu = new MenuCollection();
            MenuCollection alacarteMenu = new MenuCollection();

            FoodIterator fi_wombo = setMenu.CreateFoodIterator(1, "Wombo Combo", 5.5);
            FoodIterator fi_cnd = setMenu.CreateFoodIterator(2, "Chips n Dips", 7);
            FoodIterator fi_truff = setMenu.CreateFoodIterator(3, "Truffle Trouble", 4.5);
            FoodIterator alacarte = alacarteMenu.CreateFoodIterator(4, "A la Carte Items", 0);

            Food Burger = new Food(1, "Completely Normal Hamburger", "Fast Food", 5, "Available");
            Food Soda = new Food(2, "Too-Gassy-4-Me Soda", "Fast Food", 1.5, "Available");
            Food Onion_Rings = new Food(3, "Onion Ringz", "Fast Food", 2, "Available");
            fi_wombo.AddFood(Burger);
            fi_wombo.AddFood(Soda);
            fi_wombo.AddFood(Onion_Rings);
            Food Dip = new Food(4, "Super Special Spicy Sauce", "Fast Food", 2, "Available");
            Food Fries = new Food(5, "Frenzy Fries", "Fast Food", 3.5, "Available");
            Food Nachos = new Food(6, "Nasty Nachos", "Fast Food", 2, "Available");
            fi_cnd.AddFood(Dip);
            fi_cnd.AddFood(Fries);
            fi_cnd.AddFood(Nachos);
            Food MnC = new Food(7, "Truffle Mac n Cheeeeese", "Fast Food", 6.5, "Available");
            Food Pizza = new Food(8, "Truffa Pizza", "Fast Food", 9.9, "Available");
            Food Truff = new Food(9, "Truffries", "Fast Food", 4.5, "Available");
            fi_truff.AddFood(MnC);
            fi_truff.AddFood(Pizza);
            fi_truff.AddFood(Truff);

            alacarte.AddFood(Burger);
            alacarte.AddFood(Soda);
            alacarte.AddFood(Fries);
            alacarte.AddFood(Onion_Rings);
            alacarte.AddFood(Nachos);
            alacarte.AddFood(MnC);
            alacarte.AddFood(Dip);
            alacarte.AddFood(Truff);
            alacarte.AddFood(Pizza);

            initalizer(mList, dList, cList, customerList, rList);

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
                customerScreen(customer, r, rList, f, fList, setMenu, alacarteMenu);
            }
            Console.ReadKey();
            
            //==== Required Function Number 5: View receipt details ====

            //==== END OF Required Function Number 5: View receipt details ====

            Console.ReadKey();
        }
    }
}
