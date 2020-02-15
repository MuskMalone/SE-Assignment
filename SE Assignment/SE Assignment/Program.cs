using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Program
    {
        static Manager me = new Manager(1, "Cheng En", "T0034912C", 'M', "Present", null, DateTime.UtcNow, DateTime.UtcNow);
        static FoodIterator mainMenu = me.CreateFoodIterator();
        static void Main(string[] args)
        {
            int globalFoodID = 1;

            MenuItem m1 = new MenuItem(99, "Food 1", "desc 1", "Category 1", 98, "1 Calorie", "Available", false);
            MenuItem m2 = new MenuItem(98, "Food 2", "desc 2", "Category 2", 24, "2 Calories", "Available", false);
            MenuItem m3 = new MenuItem(97, "Food 3", "desc 3", "Category 3", 45, "3 Calories", "Unavailable", false);
            Food f1 = new Food("Food 1", 98);
            Food f2 = new Food("Food 2", 24);
            Food f3 = new Food("Food 3", 45);
            m1.addFood(f1);
            m2.addFood(f2);
            m3.addFood(f3);
            mainMenu.AddFood(m1);
            mainMenu.AddFood(m2);
            mainMenu.AddFood(m3);
            while (true)
            {
                Console.WriteLine("[1] Customer");
                Console.WriteLine("[2] Manager");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("Select Option:");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("======== What Would You Like to Buy? ========");
                        Console.WriteLine("[1] Set Meal");
                        Console.WriteLine("[2] À la Carte");
                        Console.WriteLine("[0] Back");
                        Console.WriteLine("Select Option:");
                        option = Console.ReadLine();

                        if (option == "1")
                        {
                            // Display all Set Menus
                            Console.WriteLine("========== Set Menus ===========");
                            if (mainMenu.GetCurrent().IsSetMenu == true && mainMenu.GetCurrent().getSize() >= 2 && mainMenu.GetCurrent().Status == "Available")
                                Console.WriteLine(mainMenu.GetCurrent().ToString());
                            while (mainMenu.HasNextFood())
                            {
                                if (mainMenu.NextFood().IsSetMenu == true && mainMenu.GetCurrent().getSize() >= 2 && mainMenu.GetCurrent().Status == "Available")

                                    Console.WriteLine("\n" + mainMenu.GetCurrent().ToString());
                            }

                            Console.WriteLine("Add to Cart: ");
                        }
                        else if (option == "2")
                        {
                            // Display all À la Carte
                            Console.WriteLine("========== À la Carte ===========");
                            if (mainMenu.GetCurrent().IsSetMenu == false && mainMenu.GetCurrent().Status == "Available")
                                Console.WriteLine(mainMenu.GetCurrent().ToString());
                            while (mainMenu.HasNextFood())
                            {
                                if (mainMenu.NextFood().IsSetMenu == false && mainMenu.GetCurrent().Status == "Available")

                                    Console.WriteLine("\n" + mainMenu.GetCurrent().ToString());
                            }
                        }
                        else if (option == "0")
                        {
                            break;
                        }
                        else
                            continue;
                    }
                }
                else if (option == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("[1] Add Food");
                        Console.WriteLine("[2] Edit Food (WIP)");
                        Console.WriteLine("[3] Delete Food");
                        Console.WriteLine("[0] Back");
                        Console.WriteLine("Select Option:");
                        option = Console.ReadLine();
                        if (option == "1")  // Add Food
                        {
                            if (mainMenu.HasNextFood())
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
                                    if (input == "1" || input == "2")   // If input is valid
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
                                                        Console.WriteLine(mainMenu.GetCurrent().ToString());
                                                    while (mainMenu.HasNextFood())
                                                    {
                                                        if (mainMenu.NextFood().IsSetMenu == false)
                                                            Console.WriteLine(mainMenu.GetCurrent().ToString());
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
                                            MenuItem newMenuItem = new MenuItem(globalFoodID, newTitle, newDesc, newCat, newPrice, newUnit, statusList[Convert.ToInt32(newStatus)], false);
                                            globalFoodID++;
                                            Food newFood = new Food(newTitle, newPrice);
                                            newMenuItem.addFood(newFood);
                                            mainMenu.AddFood(newMenuItem);  // Add food to main menu
                                            break;
                                        }
                                    }
                                    else if (input == "0")  // Return to previous screen
                                        break;
                                    else    // Invalid input
                                        continue;
                                }
                            }
                            else
                                Console.WriteLine("You need at least 2 Food to creat a Set Menu!\n");
                        }
                        else if (option == "2") // Edit Food
                        {
                            while (true)
                            {
                                // Display all existing Food
                                Console.WriteLine("========== Existing Food ===========");
                                Console.WriteLine(mainMenu.GetCurrent().ToString());
                                while (mainMenu.HasNextFood())
                                {
                                    Console.WriteLine(mainMenu.NextFood().ToString());

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
                                                        Console.WriteLine(mainMenu.GetCurrent().ToString());
                                                    while (mainMenu.HasNextFood())
                                                    {
                                                        if (mainMenu.NextFood().IsSetMenu == false)
                                                            Console.WriteLine(mainMenu.GetCurrent().ToString());
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
                                Console.WriteLine(mainMenu.GetCurrent().ToString());
                                while (mainMenu.HasNextFood())
                                {
                                    Console.WriteLine(mainMenu.NextFood().ToString());
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
                            break;
                        }
                        else
                            continue;
                    }
                }
            }
        }
    }
}
