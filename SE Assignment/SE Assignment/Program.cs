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
        static MenuCollection setMenu = new MenuCollection();
        static MenuCollection alacarteMenu = new MenuCollection();
        static OrderCollection oc = new OrderCollection();
        static int OrderCount = 1;
        static int MenuCount = 1;
        static int FoodCount = 1;
        static int ReceiptCount = 1;
        static List<Receipt> receiptList = new List<Receipt>();

        static void initalizer(List<Manager> mList, List<Dispatcher> dList, List<Chef> cList, List<Customer>customerList, List<Receipt> rList)
        {

            Manager m1 = new Manager(1, "Cheng En", "S6666666X", 'M',"On Duty", oc, DateTime.UtcNow, DateTime.UtcNow);
            Manager m2 = new Manager(1,"cheng en", "S6666667X", 'M',"On Duty", oc, DateTime.UtcNow, DateTime.UtcNow);
            mList.Add(m1);
            mList.Add(m2);

            Chef c1 = new Chef("Cheng Hian", 1, "S7777777X", 'M', DateTime.UtcNow, "On Duty", oc);
            Chef c2 = new Chef("Hian Hian", 1, "S7777777X", 'F', DateTime.UtcNow, "On Duty", oc);
            cList.Add(c1);
            cList.Add(c2);

            Dispatcher d1 = new Dispatcher("Nikko", 2, "S3333333X", 'M', DateTime.UtcNow, "On Duty", oc);
            dList.Add(d1);

            Customer customer1 = new Customer("Victor", 100, 94204209, "Victor@np.com", "535 Clementi Rd, Singapore 599489");
            customerList.Add(customer1);
            
        }

        // EMPLOYEE SCREEN
        static void employeeScreen(Manager m, List<Manager> mList, Chef c, List<Chef> cList, Dispatcher d, List<Dispatcher> dList, MenuCollection setMenu, MenuCollection alcM)
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
                    managerScreen(m, mList, setMenu, alcM);
                }

                // TO CHEF SCREEN
                else if (option == "2")
                {
                    chefScreen(c, cList, setMenu, alcM);
                }

                // TO DISPATCHERS SCREEN
                else if (option == "3")
                {
                    dispatcherScreen(d, dList, setMenu, alcM);
                }

                // HOMESCREEN
                else if (option == "4")
                {
                    Main();
                }
            }
        }

        // MANAGER SCREEN
        static void managerScreen(Manager m, List<Manager> mList, MenuCollection setMenu, MenuCollection alcM)
        {
            List<Chef> cList = new List<Chef>();
            Chef c = new Chef();
            List<Dispatcher> dList = new List<Dispatcher>();
            Dispatcher d = new Dispatcher();

            while (true)
            {
                Console.WriteLine("\n ======= MANAGER SCREEN =======");
                Console.WriteLine("[1] View all manager details");
                Console.WriteLine("[2] Manage Food & Menus");
                Console.WriteLine("[3] Return to Employee Screen");

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if(option == "1")
                {
                    m.viewAllManagers(mList);
                }
                else if (option == "2")
                {
                    Console.WriteLine("\n ======= MANAGE FOOD & MENUS =======");
                    Console.WriteLine("[1] Add Menu");
                    Console.WriteLine("[2] Edit Menu");
                    Console.WriteLine("[3] Delete Menu");
                    Console.WriteLine("[4] Add Food");
                    Console.WriteLine("[5] Edit Food");
                    Console.WriteLine("[6] Delete Food");
                    Console.WriteLine("[0] Return to Employee Screen");

                    Console.Write("Select an option: ");
                    option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.WriteLine("Enter name for Menu: ");
                        string mName = Console.ReadLine();
                        Console.WriteLine("Enter price for "+mName);
                        string mPrice = Console.ReadLine();
                        FoodIterator newMenu = setMenu.CreateFoodIterator(setMenu.GetCount() + 1, mName, Convert.ToDouble(mPrice));
                        while (true)
                        {
                            Console.WriteLine("Select Food for Menu: ");
                            alcM.GetCurrent().ListAllFood();
                            string mFoodID = Console.ReadLine();
                            for (int i = 0; i < alacarteMenu.GetCount(); i++)
                            {
                                if (alacarteMenu.GetCurrent().GetCurrent().FoodID == Convert.ToInt32(mFoodID))
                                    newMenu.AddFood(alacarteMenu.GetCurrent().GetCurrent());
                                else
                                {
                                    while (alacarteMenu.GetCurrent().HasNextFood())
                                    {
                                        if (alacarteMenu.GetCurrent().NextFood().FoodID == Convert.ToInt32(mFoodID))
                                            newMenu.AddFood(alacarteMenu.GetCurrent().GetCurrent());
                                    }
                                }
                            }
                            Console.WriteLine("Add More?");
                            Console.WriteLine("[1] Yes");
                            Console.WriteLine("[2] No");
                            option = Console.ReadLine();
                            if (option == "1")
                                continue;
                            else
                                break;
                        }
                    }

                }
                else if (option == "3")
                {
                    employeeScreen(m, mList, c, cList, d, dList, setMenu, alcM);
                }
            }
        }

        // CHEF SCREEN
        static void chefScreen(Chef c, List<Chef> cList, MenuCollection setMenu, MenuCollection alcM)
        {
            List<Manager> mList = new List<Manager>();
            Manager m = new Manager();

            List<Dispatcher> dList = new List<Dispatcher>();
            Dispatcher d = new Dispatcher();

            while (true)
            {
                Console.WriteLine("\n ======= CHEF SCREEN =======");
                Console.WriteLine("[1] View New Orders");
                Console.WriteLine("[2] Prepare an order");
                Console.WriteLine("[3] Get preparing orders");
                Console.WriteLine("[4] Finish an order");
                Console.WriteLine("[5] Return to Employee Screen");

                Console.Write("Select an option:");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    cList[0].GetAllNewOrders();
                    Console.WriteLine("\n");
                }

                if (option == "2")
                {
                    Console.WriteLine("Enter Order ID: ");
                    int orderid = Int32.Parse(Console.ReadLine());
                    cList[0].PrepareOrder(orderid);
                    Console.WriteLine("\n");
                }

                if (option == "3")
                {
                    cList[0].GetAllPreparingOrders();
                    Console.WriteLine("\n Current preparing orders");
                }

                if (option == "4")
                {
                    Console.WriteLine("Enter Order ID: ");
                    int orderid = Int32.Parse(Console.ReadLine());
                    cList[0].CompleteOrder(orderid);
                }

                else if (option == "5")
                {
                    employeeScreen(m, mList, c, cList, d, dList, setMenu, alcM);
                }

            }
        }

        // DISPATCHER SCREEN
        static void dispatcherScreen(Dispatcher d, List<Dispatcher> dList, MenuCollection setMenu, MenuCollection alcM)
        {
            List<Manager> mList = new List<Manager>();
            Manager m = new Manager();

            List<Chef> cList = new List<Chef>();
            Chef c = new Chef();

            while (true)
            {
                Console.WriteLine("\n ======= DISPATCHER SCREEN =======");
                Console.WriteLine("[1] View all dispatcher details");
                Console.WriteLine("[2] Dispatch an order");
                Console.WriteLine("[3] Confirm a delivery");
                Console.WriteLine("[4] Return to Employee Screen");

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    d.viewAllDispatchers(dList);
                }
                else if (option == "2")
                {
                    if (oc.GetAllOrdersWhereState("ready").Count() != 0)
                    {
                        foreach (Order order in oc.GetAllOrdersWhereState("ready"))
                        {
                            Console.WriteLine("Order " + order.OrderID);
                        }
                        Console.WriteLine("Dispatch an order: ");
                        string input = Console.ReadLine();
                        d.dispatchOrder(oc.GetOrder(Convert.ToInt32(input)));
                    }
                    else
                        Console.WriteLine("You have no orders!");
                }
                else if (option == "3")
                {
                    if (oc.GetAllOrdersWhereState("dispatched").Count() != 0)
                    {
                        foreach (Order order in oc.GetAllOrdersWhereState("dispatched"))
                        {
                            Console.WriteLine("Order " + order.OrderID);
                        }
                        Console.WriteLine("Confirm a delivery: ");
                        string input = Console.ReadLine();
                        d.confirmDelivery(oc.GetOrder(Convert.ToInt32(input)));
                    }
                    else
                        Console.WriteLine("You have no orders!");
                }
                else if (option == "4")
                {
                    employeeScreen(m, mList, c, cList, d, dList, setMenu, alcM);
                }
            }
        }

        // CUSTOMER SCREEN
        //static void customerScreen(Customer c, Receipt r, List<Receipt> rList, Food f, List<Food> fList, FoodIterator alacartefood)
        static void customerScreen(Customer c, Receipt r, List<Receipt> rList, Food f, List<Food> fList, MenuCollection setM, MenuCollection alcM)
        {
            void pay(PaymentStrategy paymentMethod, double amount)
            {

                paymentMethod.pay(amount);
            }

            while (true)
            {
                Console.WriteLine("\n ======= CUSTOMER SCREEN =======");
                Console.WriteLine("[1] Make New Order");
                Console.WriteLine("[2] View All Receipts");
                Console.WriteLine("[3] View Current & Past Orders");
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

                        while (true)
                        {
                            Console.WriteLine("\n ======= What would you like to buy? =======");
                            Console.WriteLine("[1] Menu");
                            Console.WriteLine("[2] À la carte");
                            Console.WriteLine("[3] Proceed to pay");
                            Console.WriteLine("[4] Back");
                            Console.Write("Select an option: ");
                            string orderOption = Console.ReadLine();

                            if (orderOption == "1")
                            {
                                setM.ListAllMenus();
                                Console.Write("Add to Cart: ");
                                string foodChoice = Console.ReadLine();
                                c.custmenuList.Add(setMenu.GetMenu(Convert.ToInt32(foodChoice)));
                            }
                            else if (orderOption == "2")
                            {
                                Console.WriteLine(alcM.GetCurrent().ToString());
                                Console.Write("Add to Cart: ");
                                string foodChoice = Console.ReadLine();
                                c.custfoodList.Add(alacarteMenu.GetCurrent().GetFood(Convert.ToInt32(foodChoice)));
                            }

                            else if (orderOption == "3")
                            {
                                Console.WriteLine("\n ======= Delivery option =======");
                                Console.WriteLine("[1] Standard delivery");
                                Console.WriteLine("[2] Express delivery");
                                Console.Write("Select an option: ");
                                string deliveryoption = Console.ReadLine();

                                if (deliveryoption == "1")
                                {

                                    double alcmpaymentamount = c.GetcustfoodListTotalAmount();
                                    double setmpaymentamount = c.GetcustmenuListListTotalAmount();
                                    //express fee: 0.00
                                    publicamount = alcmpaymentamount + setmpaymentamount;
                                    Console.WriteLine("total to pay is " + publicamount.ToString());
                                    //double alcmpaymentamount = alcM.GetCurrent().GetTotalAmount();
                                    // Console.WriteLine("[alcm amount is " + alcmpaymentamount);


                                    //double setmpaymentamount = setM.GetCurrent().GetPrice();
                                    // Console.WriteLine("setm amount is " + setmpaymentamount);
                                    //no express fee, delivery
                                    //publicamount = alcmpaymentamount + setmpaymentamount;
                                    //Console.WriteLine("total to pay is " + publicamount.ToString());

                                }

                                else if (deliveryoption == "2")
                                {
                                    double alcmpaymentamount = c.GetcustfoodListTotalAmount();
                                    double setmpaymentamount = c.GetcustmenuListListTotalAmount();
                                    //express fee: 3.00
                                    publicamount = alcmpaymentamount + setmpaymentamount + 3.00;
                                    Console.WriteLine("total to pay is " + publicamount.ToString());
                                }


                                Console.WriteLine("\n ======= Payment option =======");
                                Console.WriteLine("[1] Credit Card");
                                Console.WriteLine("[2] Paypal");
                                Console.Write("Select an option: ");
                                string paymentoption = Console.ReadLine();
                                
                                if (paymentoption == "1")
                                {
                                    Console.WriteLine("Credit Card selected");
                                    Console.Write("Credit Card Name: ");
                                    string name = Console.ReadLine();
                                    //Console.WriteLine("Credit Card Number: ");
                                    //string creditcardnumber = Console.ReadLine();
                                    Console.Write("Cvc: ");
                                    string cvc = Console.ReadLine();
                                    Console.Write("Date of expiry: ");
                                    string DOE = Console.ReadLine();
                                    pay(new CreditCard(name, "1234567890123456", cvc, DOE), publicamount);
                                    Order newOrder = new Order(OrderCount, "New");
                                    OrderCount++;
                                    oc.AddOrder(newOrder);
                                    Receipt newReceipt = new Receipt(ReceiptCount, DateTime.UtcNow, DateTime.UtcNow, c.custmenuList, c.custfoodList, "Credit Card", publicamount);
                                    rList.Add(newReceipt);
                                    newReceipt.viewAllReceipt(rList);
                                    break;

                                }

                                if (paymentoption == "2")
                                {
                                    Console.WriteLine("Paypal selected");
                                    Console.Write("Recpient name: ");
                                    string name = Console.ReadLine();
                                    Console.Write("Currency: ");
                                    string curr = Console.ReadLine();
                                    pay(new Paypal(name, curr), publicamount);
                                    Order newOrder = new Order(OrderCount, "New");
                                    OrderCount++;
                                    oc.AddOrder(newOrder);
                                    Receipt newReceipt = new Receipt(ReceiptCount, DateTime.UtcNow, DateTime.UtcNow, c.custmenuList, c.custfoodList, "Paypal", publicamount);
                                    rList.Add(newReceipt);
                                    newReceipt.viewAllReceipt(rList);
                                    break;
                                }
                            }

                            else if (orderOption == "4")
                            {
                                break;
                            }
                        }

                    }
                }
                else if (option == "2")
                {

                }

                else if (option == "3")
                {
                    Console.WriteLine("=============== CURRENT ORDERS ====================");
                    if (oc.GetAllOrdersWhereState("dispatched").Count() != 0 || oc.GetAllOrdersWhereState("ready").Count() != 0 || oc.GetAllOrdersWhereState("preparing").Count() != 0
                        || oc.GetAllOrdersWhereState("new").Count() != 0)
                    {
                        foreach (Order order in oc.GetAllOrdersWhereState("dispatched"))
                        {
                            Console.WriteLine("Order " + order.OrderID + " " + order.getCurrentState().getStateName());
                        }
                        foreach (Order order in oc.GetAllOrdersWhereState("ready"))
                        {
                            Console.WriteLine("Order " + order.OrderID + " " + order.getCurrentState().getStateName());
                        }
                        foreach (Order order in oc.GetAllOrdersWhereState("preparing"))
                        {
                            Console.WriteLine("Order " + order.OrderID + " " + order.getCurrentState().getStateName());
                        }
                        foreach (Order order in oc.GetAllOrdersWhereState("new"))
                        {
                            Console.WriteLine("Order " + order.OrderID + " " + order.getCurrentState().getStateName());
                        }
                    }
                    else
                        Console.WriteLine("You have no current orders!");

                    Console.WriteLine("=============== PAST ORDERS ====================");
                    if (oc.GetAllOrdersWhereState("delivered").Count() != 0)
                    {
                        foreach (Order order in oc.GetAllOrdersWhereState("delivered"))
                        {
                            Console.WriteLine("Order " + order.OrderID);
                        }
                    }
                    else
                        Console.WriteLine("You have no past orders!");
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


            FoodIterator fi_wombo = setMenu.CreateFoodIterator(1, "Wombo Combo", 5.5);
            FoodIterator fi_cnd = setMenu.CreateFoodIterator(2, "Chips n Dips", 7);
            FoodIterator fi_truff = setMenu.CreateFoodIterator(3, "Truffle Trouble", 4.5);
            FoodIterator alacarte = alacarteMenu.CreateFoodIterator(0, "A la Carte Items", 0);

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
                employeeScreen(m, mList, c, cList, d, dList, setMenu, alacarteMenu);
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
