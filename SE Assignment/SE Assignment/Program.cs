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
        static OrderCollection oc = new OrderCollection();
        static Manager m1 = new Manager(1, "Cheng En", "T0034912C", 'M', "On Duty", oc, DateTime.UtcNow, DateTime.UtcNow);
        static FoodIterator mainMenu = m1.CreateFoodIterator();
        static int OrderCount = 1;
        static int globalFoodID = 1;
        static int ReceiptCount = 1;
        static List<Receipt> receiptList = new List<Receipt>();
        static List<Dispatcher> dList = new List<Dispatcher>();
        static List<Manager> mList = new List<Manager>();


        static void initalizer(List<Manager> mList, List<Dispatcher> dList, List<Chef> cList, List<Customer> customerList, List<Receipt> rList)
        {
            //Manager m1 = new Manager(1, "Cheng En", "S6666666X", 'M', "On Duty", oc, DateTime.UtcNow, DateTime.UtcNow);
            //Manager m2 = new Manager(2, "cheng en", "S6666667X", 'M', "On Duty", oc, DateTime.UtcNow, DateTime.UtcNow);
            mList.Add(m1);
            //mList.Add(m2);

            Dispatcher d1 = new Dispatcher("Nikko", 3, "S3333333X", 'M', DateTime.UtcNow, "On Duty", oc);
            dList.Add(d1);

            Chef c1 = new Chef("Cheng Hian", 1, "S7777777X", 'M', DateTime.UtcNow, "On Duty", oc);
            Chef c2 = new Chef("Hian Hian", 1, "S7777777X", 'F', DateTime.UtcNow, "On Duty", oc);
            cList.Add(c1);
            cList.Add(c2);

            Customer customer1 = new Customer("Victor", 100, 94204209, "Victor@np.com", "535 Clementi Rd, Singapore 599489");
            customerList.Add(customer1);
        }

        // EMPLOYEE SCREEN
        static void employeeScreen(Manager m, List<Manager> mList, Chef c, List<Chef> cList, Dispatcher d, List<Dispatcher> dList)
        {
            List<Customer> customerList = new List<Customer>();
            List<Receipt> rList = new List<Receipt>();

            initalizer(mList, dList, cList, customerList, rList);

            while (true)
            {
                Console.WriteLine("\n ======= EMPLOYEE SCREEN =======");
                Console.WriteLine("[1] Manager");
                Console.WriteLine("[2] Chef");
                Console.WriteLine("[3] Dispatcher");

                Console.WriteLine("\n ======= RETURN  =======");
                Console.WriteLine("[0] Go to home screen \n");

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
                else if (option == "0")
                {
                    Main();
                }
            }
        }

        // MANAGER SCREEN
        static void managerScreen(Manager m, List<Manager> mList)
        {
            List<Customer> customerList = new List<Customer>();
            List<Receipt> rList = new List<Receipt>();
            List<Chef> cList = new List<Chef>();
            Chef c = new Chef();
            List<Dispatcher> dList = new List<Dispatcher>();
            Dispatcher d = new Dispatcher();

            while (true)
            {
                Console.WriteLine("\n ======= MANAGER SCREEN =======");
                Console.WriteLine("[1] Add Food");
                Console.WriteLine("[2] Edit Food");
                Console.WriteLine("[3] Delete Food");
                Console.WriteLine("[0] Back");
                Console.WriteLine("Select Option:");
                string option = Console.ReadLine();
                if (option == "1")  // Add Food
                {
                    while (true)
                    {
                        Console.WriteLine("Set Meal or À la Carte?");
                        Console.WriteLine("[1] Set Menu");
                        Console.WriteLine("[2] À la Carte?");
                        Console.WriteLine("[0] Cancel");
                        Console.WriteLine("\nSelect Option:");
                        string input = Console.ReadLine();
                        string foodType = "";
                        if ((input == "1" && mainMenu.HasNextFood()) || input == "2")   // If input is valid
                        {
                            if (input == "1")
                                foodType = "Set Menu: ";
                            else
                                foodType = "À la Carte: ";
                            Console.WriteLine("Name of " + foodType);
                            string newTitle = Console.ReadLine();
                            Console.WriteLine("Description of " + foodType);
                            string newDesc = Console.ReadLine();
                            Console.WriteLine("Category of " + foodType);
                            string newCat = Console.ReadLine();
                            input = "";
                            double newPrice;
                            while (!double.TryParse(input, out newPrice))   // Check if input is valid
                            {
                                Console.WriteLine("Price of " + foodType);
                                input = Console.ReadLine();
                                if (!double.TryParse(input, out newPrice))
                                    Console.WriteLine("Invalid Price!\n");
                            }
                            newPrice = Convert.ToDouble(input);

                            Console.WriteLine("Unit of " + foodType);
                            string newUnit = Console.ReadLine();
                            string newStatus = "";
                            while (newStatus != "1" && newStatus != "2")    // Checck that input is only 1 or 2
                            {
                                Console.WriteLine("Status of " + foodType);
                                Console.WriteLine("[1] Available");
                                Console.WriteLine("[2] Unavailable");
                                Console.WriteLine("Select Option:");
                                newStatus = Console.ReadLine();
                            }
                            List<string> statusList = new List<string> { "Available", "Unavailable" };
                            // If Set Menu selected
                            if (foodType == "Set Menu: ")
                            {
                                int newSize = 0;
                                input = "";
                                // Check if input is valid
                                while (newSize <= 1 || newSize > 10 || !int.TryParse(input, out newSize))
                                {
                                    Console.WriteLine("Size of Set Meal:");
                                    input = Console.ReadLine();
                                    if (int.TryParse(input, out newSize))   // If input is int
                                    {
                                        newSize = Convert.ToInt32(input);
                                        if (newSize <= 1 || newSize > 10)   // If input is not within range
                                            Console.WriteLine("Size should be 2 to 10!");
                                    }
                                    else
                                        Console.WriteLine("Size must be an integer!\n");
                                }
                                // Create New Set Meal as MenuItem object
                                MenuItem newSetMenu = new MenuItem(globalFoodID, newTitle, newDesc, newCat, newPrice, newUnit, statusList[Convert.ToInt32(newStatus)-1], true);
                                globalFoodID++;
                                // Display all A la Carte items
                                for (int i = 0; i < newSize; i++)
                                {
                                    try
                                    {
                                        Console.WriteLine("========== Choose Food for " + newTitle + " ===========");
                                        if (mainMenu.GetCurrent().IsSetMenu == false)
                                            Console.WriteLine(mainMenu.GetCurrent().NewToString(true));
                                        while (mainMenu.HasNextFood())
                                        {
                                            if (mainMenu.NextFood().IsSetMenu == false)
                                                Console.WriteLine(mainMenu.GetCurrent().NewToString(true));
                                        }

                                        Console.WriteLine("\n\nFood to Add:");
                                        string idToAdd = Console.ReadLine();
                                        // Add Food to New Set Menu
                                        Food foodToAdd = mainMenu.GetMenuItem(Convert.ToInt32(idToAdd)).FoodList[0];
                                        newSetMenu.addFood(foodToAdd);
                                        Console.WriteLine("\n" + foodToAdd.Name + " Added!\n");
                                    }
                                    catch
                                    {
                                        newSize += 1;
                                        Console.WriteLine("Invalid Selection!");
                                    }
                                }
                                mainMenu.AddFood(newSetMenu);   // Add set menu to main menu
                                break;
                            }
                            // If À la Carte selected
                            else
                            {
                                // Create New Food as MenuItem object
                                MenuItem newMenuItem = new MenuItem(globalFoodID, newTitle, newDesc, newCat, newPrice, newUnit, statusList[Convert.ToInt32(newStatus)-1], false);
                                globalFoodID++;
                                Food newFood = new Food(newTitle, newPrice);
                                newMenuItem.addFood(newFood);
                                mainMenu.AddFood(newMenuItem);  // Add food to main menu
                                break;
                            }
                        }
                        else if (input == "1")
                            Console.WriteLine("You need at least 2 Food to creat a Set Menu!\n");
                        else if (input == "0")  // Return to previous screen
                            break;
                        else    // Invalid input
                            continue;
                    }
                }
                else if (option == "2") // Edit Food
                {
                    while (true)
                    {
                        // Display all existing Food
                        Console.WriteLine("========== Existing Food ===========");
                        Console.WriteLine(mainMenu.GetCurrent().NewToString(true));
                        while (mainMenu.HasNextFood())
                        {
                            Console.WriteLine(mainMenu.NextFood().NewToString(true));

                        }
                        Console.WriteLine("\n[0] Cancel");
                        Console.WriteLine("Note: Set Menus with Less than 2 items will not be displayed on the menu");
                        string input = "";
                        int selectedIndex;
                        while (!int.TryParse(input, out selectedIndex)) // Check if input is int
                        {
                            Console.WriteLine("\nFood to Edit: ");
                            input = Console.ReadLine();
                            if (!int.TryParse(input, out selectedIndex))
                                Console.WriteLine("Invalid Option!\n");
                        }
                        if (selectedIndex != 0) // If Cancel option not selected
                        {
                            selectedIndex = Convert.ToInt32(input);
                            bool isSetMenu;
                            MenuItem foodToEdit = mainMenu.GetMenuItem(selectedIndex);
                            if (foodToEdit.IsSetMenu == true) // If selected food is Set Menu
                                isSetMenu = true;
                            else    // Else À la Carte
                                isSetMenu = false;
                            while (true)
                            {
                                Console.WriteLine("========= Options for " + foodToEdit.Title + " =========");
                                Console.WriteLine("[1] Edit Title");
                                Console.WriteLine("[2] Edit Description");
                                Console.WriteLine("[3] Edit Category");
                                Console.WriteLine("[4] Edit Price");
                                Console.WriteLine("[5] Edit Unit");
                                Console.WriteLine("[6] Change Status");
                                if (isSetMenu)  // Show only if Set Menu selected
                                    Console.WriteLine("[7] Edit Set Menu Contents");
                                Console.WriteLine("[0] Back");
                                Console.WriteLine("\nSelect Option: ");
                                input = Console.ReadLine();
                                // Store current values
                                string currentTitle = foodToEdit.Title; string currentDesc = foodToEdit.Description;
                                string currentCat = foodToEdit.Category; double currentPrice = foodToEdit.Price;
                                string currentUnit = foodToEdit.Unit; string currentStatus = foodToEdit.Status;
                                if (input == "1")   // Edit Title
                                {
                                    Console.WriteLine("Current Title: " + currentTitle);
                                    Console.WriteLine("\nChange to:");
                                    currentTitle = Console.ReadLine();
                                    foodToEdit.Title = currentTitle;
                                    if (foodToEdit.IsSetMenu == false)
                                        foodToEdit.FoodList[0].Name = currentTitle;
                                }
                                else if (input == "2")  // Edit Description
                                {
                                    Console.WriteLine("Current Description: " + currentDesc);
                                    Console.WriteLine("\nChange to:");
                                    currentDesc = Console.ReadLine();
                                    foodToEdit.Description = currentDesc;
                                }
                                else if (input == "3")  // Edit Category
                                {
                                    Console.WriteLine("Current Category: " + currentCat);
                                    Console.WriteLine("\nChange to:");
                                    currentCat = Console.ReadLine();
                                    foodToEdit.Category = currentCat;
                                }
                                else if (input == "4")  // Edit Price
                                {
                                    string inputPrice = "";
                                    while (!double.TryParse(inputPrice, out currentPrice))   // Check if input is valid
                                    {
                                        Console.WriteLine("Current Price: $" + currentPrice);
                                        Console.WriteLine("\nChange to: $");
                                        inputPrice = Console.ReadLine();
                                        if (!double.TryParse(inputPrice, out currentPrice))
                                            Console.WriteLine("Invalid Price!\n");
                                    }
                                    currentPrice = Convert.ToDouble(inputPrice);
                                    foodToEdit.Price = currentPrice;
                                    if (foodToEdit.IsSetMenu == false)
                                        foodToEdit.FoodList[0].Price = currentPrice;
                                }
                                else if (input == "5")  // Edit Unit
                                {
                                    Console.WriteLine("Current Unit: " + currentUnit);
                                    Console.WriteLine("\nChange to:");
                                    currentUnit = Console.ReadLine();
                                    foodToEdit.Unit = currentUnit;
                                }
                                else if (input == "6")  // Change Status
                                {
                                    // Swap status
                                    if (foodToEdit.Status == "Available")
                                        currentStatus = "Unavailable";
                                    else
                                        currentStatus = "Available";
                                    foodToEdit.Status = currentStatus;
                                    Console.WriteLine("Status changed to \"" + currentStatus + "\"");
                                }
                                else if (input == "7" && isSetMenu) // Edit Set Menu Contents
                                {
                                    Console.WriteLine("======= Choose Food to Remove from " + currentTitle + " =======");
                                    foodToEdit.listFood();
                                    Console.WriteLine("[0] Add Food Instead");
                                    int optionToEdit;
                                    Console.WriteLine("\nFood to Edit:");
                                    Console.WriteLine("Select Option:");
                                    try
                                    {
                                        optionToEdit = Convert.ToInt32(Console.ReadLine());
                                        if (optionToEdit != 0)  // Remove Food
                                        {
                                            foodToEdit.removeFood(optionToEdit);
                                        }
                                        else    // Add Food
                                        {
                                            Console.WriteLine("\n========== Add Food to " + currentTitle + " ===========");
                                            // Display all À la Carte items
                                            if (mainMenu.GetCurrent().IsSetMenu == false)
                                                Console.WriteLine(mainMenu.GetCurrent().NewToString(true));
                                            while (mainMenu.HasNextFood())
                                            {
                                                if (mainMenu.NextFood().IsSetMenu == false)
                                                    Console.WriteLine(mainMenu.GetCurrent().NewToString(true));
                                            }
                                            Console.WriteLine("\n\nFood to Add:");
                                            try   // Check if input is valid
                                            {
                                                int idToAdd = Convert.ToInt32(Console.ReadLine());
                                                // Add Food to New Set Menu
                                                Food foodToAdd = mainMenu.GetMenuItem(idToAdd).FoodList[0];
                                                foodToEdit.addFood(foodToAdd);
                                                Console.WriteLine("\n" + foodToAdd.Name + " Added!\n");
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Invalid Option!\n");
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid Option!\n");
                                    }
                                }
                                else if (input == "0")  // Return to previous menu
                                {
                                    break;
                                }
                                else
                                    Console.WriteLine("Invalid Option!\n");
                            }
                        }
                        else if (selectedIndex == 0)
                            break;
                        else
                            Console.WriteLine("\n");
                    }
                }
                else if (option == "3") // Delete Food
                {
                    if (mainMenu.GetCurrent() != null)
                    {
                        // Display all existing Food
                        Console.WriteLine("========== Existing Food ===========");
                        Console.WriteLine(mainMenu.GetCurrent().NewToString(true));
                        while (mainMenu.HasNextFood())
                        {
                            Console.WriteLine(mainMenu.NextFood().NewToString(true));
                        }
                        Console.WriteLine("\n[0] Cancel");
                        Console.WriteLine("\nFood to Delete: ");
                        try
                        {
                            int foodToDel = Convert.ToInt32(Console.ReadLine());
                            if (foodToDel != 0) // If Cancel option not selected
                            {
                                mainMenu.RemoveFood(foodToDel);
                            }
                            else
                                Console.WriteLine("\n");
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Option!\n");
                        }
                    }
                    else
                        Console.WriteLine("No Existing Food!\n");
                }
                else if (option == "0")
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

            List<Customer> customerList = new List<Customer>();
            List<Receipt> rList = new List<Receipt>();

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
                        Console.WriteLine("\n You have no orders to dispatch!");
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
                        d.addCommission(oc.GetOrder(Convert.ToInt32(input)), d.TotalCommission);

                        Console.WriteLine("\nTotal commission earned this month is now $" + d.TotalCommission);
                    }
                    else
                        Console.WriteLine("\n You have no orders that can be confirmed as delivered!");
                }

                else if (option == "4")
                {
                    employeeScreen(m, mList, c, cList, d, dList);
                }
            }
        }

        // CUSTOMER SCREEN
        //static void customerScreen(Customer c, Receipt r, List<Receipt> rList, Food f, List<Food> fList, FoodIterator alacartefood)
        static void customerScreen(Customer c, List<Customer> cList, Receipt r, List<Receipt> rList)
        {
            void pay(PaymentStrategy paymentMethod, double amount)
            {

                paymentMethod.pay(amount);
            }

            while (true)
            {
                Console.WriteLine("\n ======= CUSTOMER SCREEN =======");
                Console.WriteLine("[1] Make New Order");
                Console.WriteLine("[2] View Current & Past Orders");
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
                            Console.WriteLine("[1] Set Menu");
                            Console.WriteLine("[2] À la Carte");
                            Console.WriteLine("[3] Proceed to pay");
                            Console.WriteLine("[0] Back");
                            Console.Write("Select an option: ");
                            string orderOption = Console.ReadLine();

                            if (orderOption == "1")
                            {
                                if (mainMenu.HasAvailableSetMenu())
                                {
                                    try
                                    {
                                        // Display all Set Menus
                                        Console.WriteLine("========== Set Menus ===========");
                                        if (mainMenu.GetCurrent().IsSetMenu == true && mainMenu.GetCurrent().getSize() >= 2 && mainMenu.GetCurrent().Status == "Available")
                                            Console.WriteLine(mainMenu.GetCurrent().NewToString(false));
                                        while (mainMenu.HasNextFood())
                                        {
                                            if (mainMenu.NextFood().IsSetMenu == true && mainMenu.GetCurrent().getSize() >= 2 && mainMenu.GetCurrent().Status == "Available")

                                                Console.WriteLine("\n" + mainMenu.GetCurrent().NewToString(false));
                                        }

                                        Console.WriteLine("Add to Cart: ");
                                        int foodChoice = Convert.ToInt32(Console.ReadLine());
                                        if (mainMenu.GetMenuItem(foodChoice) != null)
                                            c.custfoodList.Add(mainMenu.GetMenuItem(foodChoice));
                                        else
                                            Console.WriteLine("Invalid Selection!");
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid Selection!");
                                    }
                                }
                                else
                                    Console.WriteLine("No Set Menus available");
                            }
                            else if (orderOption == "2")
                            {
                                if (mainMenu.HasAvailableFood())
                                {
                                    try
                                    {
                                        // Display all À la Carte
                                        Console.WriteLine("========== À la Carte ===========");
                                        if (mainMenu.GetCurrent().IsSetMenu == false && mainMenu.GetCurrent().Status == "Available")
                                            Console.WriteLine(mainMenu.GetCurrent().NewToString(false));
                                        while (mainMenu.HasNextFood())
                                        {
                                            if (mainMenu.NextFood().IsSetMenu == false && mainMenu.GetCurrent().Status == "Available")

                                                Console.WriteLine("\n" + mainMenu.GetCurrent().NewToString(false));
                                        }
                                        Console.Write("Add to Cart: ");
                                        int foodChoice = Convert.ToInt32(Console.ReadLine());
                                        if (mainMenu.GetMenuItem(foodChoice) != null)
                                            c.custfoodList.Add(mainMenu.GetMenuItem(foodChoice));
                                        else
                                            Console.WriteLine("Invalid Selection!");
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid Selection!");
                                    }
                                }
                                else
                                    Console.WriteLine("No Food available");
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
                                    // No extra charge
                                    publicamount = c.GetCartTotal();
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
                                    //express fee: 3.00
                                    publicamount = c.GetCartTotal() + 3.00;
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
                                    oc.AddOrder(newOrder, c);
                                    Receipt newReceipt = new Receipt(ReceiptCount, DateTime.UtcNow, DateTime.UtcNow, c.custmenuList, c.custfoodList, "Credit Card", publicamount);
                                    rList.Add(newReceipt);
                                    newReceipt.viewAllReceipt(rList);
                                    c.custfoodList.Clear();
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
                                    oc.AddOrder(newOrder, c);
                                    Receipt newReceipt = new Receipt(ReceiptCount, DateTime.UtcNow, DateTime.UtcNow, c.custmenuList, c.custfoodList, "Paypal", publicamount);
                                    rList.Add(newReceipt);
                                    newReceipt.viewAllReceipt(rList);
                                    c.custfoodList.Clear();
                                    break;
                                }
                            }

                            else if (orderOption == "0")
                            {
                                break;
                            }
                        }
                    }
                }

                else if (option == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("\n ======= VIEW ORDERS =======");
                        Console.WriteLine("[1] View Current Orders");
                        Console.WriteLine("[2] View Past Orders");
                        Console.WriteLine("[3] Return to customer screen");
                        Console.Write("\nSelect an option: ");
                        string orderOption = Console.ReadLine();

                        if (orderOption == "1")
                        {
                            Console.WriteLine("\n=============== CURRENT ORDERS ====================");
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

                        }
                        else if (orderOption == "2")
                        {
                            Console.WriteLine("\n=============== PAST ORDERS ====================");
                            if (oc.GetAllOrdersWhereState("delivered").Count() != 0)
                            {
                                foreach (Order order in oc.GetAllOrdersWhereState("delivered"))
                                {
                                    Console.WriteLine("Order " + order.OrderID + " " + order.getCurrentState().getStateName());
                                }
                            }
                            else
                                Console.WriteLine("You have no past orders!");
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

            //MenuItem m1 = new MenuItem(99, "Food 1", "desc 1", "Category 1", 98, "1 Calorie", "Available", false);
            //MenuItem m2 = new MenuItem(98, "Food 2", "desc 2", "Category 2", 24, "2 Calories", "Available", false);
            //MenuItem m3 = new MenuItem(97, "Food 3", "desc 3", "Category 3", 45, "3 Calories", "Unavailable", false);
            //Food f1 = new Food("Food 1", 98);
            //Food f2 = new Food("Food 2", 24);
            //Food f3 = new Food("Food 3", 45);
            //m1.addFood(f1);
            //m2.addFood(f2);
            //m3.addFood(f3);
            //mainMenu.AddFood(m1);
            //mainMenu.AddFood(m2);
            //mainMenu.AddFood(m3);

            string accountType;

            Console.WriteLine("======= SELECT AN ACCOUNT =======");
            Console.WriteLine("[1] Employee");
            Console.WriteLine("[2] Customer");
            Console.WriteLine("\n ======= EXIT? =======");
            Console.WriteLine("[0] Exit Application");

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
                customerScreen(customer, customerList, r, rList);
            }
            Console.ReadKey();

            //==== Required Function Number 5: View receipt details ====

            //==== END OF Required Function Number 5: View receipt details ====

            Console.ReadKey();
        }
    }
}
