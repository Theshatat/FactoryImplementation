using SimpleFactory;

namespace Metigator.DesignPattern.Before;

class Program
{
    // solution1 : I hide the meal components from client in another class called DishFactory, which is responsible for creating the meal components.
    // solution2 : If i want to edit or add the meal components, i can do it in the DishFactory class without changing the Program class.
    // solution3 : I am not dependent on the concrete classes of the meal components in the Program class, i am  dependent on the DishFactory. 


    public static void Main(string[] args)
    {
        (IAppetizer Appetizer, IMainDish MainDish, IDessert Dessert) meal = new(); // Tuple to hold the meal components

        int choice;

        Console.WriteLine("Appetizers");
        Console.WriteLine($" ├ [01] Chicken Salad");
        Console.WriteLine($" ├ [02] Butter Cracker");
        Console.WriteLine($" ├ [03] Cheese Twist");
        Console.WriteLine($" ├ [04] Potato Bite");
        Console.WriteLine($" └ Any other key to skip");


        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    meal.Appetizer = DishFactory.CreateAppetizer("ChickenSalad");      
                    break;
                case 2:
                    meal.Appetizer = DishFactory.CreateAppetizer("ButterCracker");
                    break;
                case 3:
                    meal.Appetizer = DishFactory.CreateAppetizer("CheeseTwist");
                    break;
                case 4:
                    meal.Appetizer = DishFactory.CreateAppetizer("PotatoBite");
                    break;
                default:
                    break;
            }
        }

        Console.Clear();

        Console.WriteLine("Main Dish");
        Console.WriteLine($" ├ [05] Lasagna");
        Console.WriteLine($" ├ [06] Steak");
        Console.WriteLine($" ├ [07] Molokhiya");
        Console.WriteLine($" ├ [08] Grilled Chicken");
        Console.WriteLine($" └ Any other key to skip");

        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 5:
                    meal.MainDish = DishFactory.CreateMainDish("Lasagna");
                    break;
                case 6:
                    meal.MainDish = DishFactory.CreateMainDish("Steak");
                    break;
                case 7:
                    meal.MainDish = DishFactory.CreateMainDish("Molokhiya");
                    break;
                case 8:
                    meal.MainDish = DishFactory.CreateMainDish("GrilledChicken");
                    break;
                default:
                    break;
            }
        }

        Console.Clear();

        Console.WriteLine("Desserts");
        Console.WriteLine($" ├ [09] Fruit Salad");
        Console.WriteLine($" ├ [10] Tiramisu");
        Console.WriteLine($" ├ [11] Browny");
        Console.WriteLine($" ├ [12] IceCream");
        Console.WriteLine($" └ Any other key to skip");

        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 9:
                    meal.Dessert = DishFactory.CreateDessert("FruitSalad");
                    break;
                case 10:
                    meal.Dessert = DishFactory.CreateDessert("Tiramisu");
                    break;
                case 11:
                    meal.Dessert = DishFactory.CreateDessert("Browny");
                    break;
                case 12:
                    meal.Dessert = DishFactory.CreateDessert("IceCream");
                    break;
                default:
                    break;
            }
        }
        Console.Clear();

        meal.Appetizer?.Serve(); // Use null-conditional operator to avoid NullReferenceException if the user skips a meal component
        meal.MainDish?.Serve();
        meal.Dessert?.Serve();
    }
}