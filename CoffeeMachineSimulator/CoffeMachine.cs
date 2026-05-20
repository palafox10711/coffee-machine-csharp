using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace CoffeeMachineSimulator;

public class CoffeeMachine
{
    public int Water {get; private set;}
    public int Milk {get; private set;}
    public int Beans { get; private set;}
    public int Money { get; private set; }
    private MachineState _state = MachineState.Starting;

    public CoffeeMachine(int water = 400, int milk = 540, int beans = 120, int money = 550)
    {
        Water = water;
        Beans = beans;
        Milk = milk;
        Money = money;
        
    }

    private bool HasEnoughResources(CoffeeRecipe recipe)
    {
        return Water >= recipe.Water && Milk >= recipe.Milk && Beans >= recipe.Beans;
        
    }
    private void BuyCoffee(CoffeeRecipe recipe)
    {
        Water -= recipe.Water;
        Milk -= recipe.Milk;
        Beans -= recipe.Beans;
        Money += recipe.Price;
        _state = MachineState.ChoosingAction;
        Console.WriteLine("here is your coffee");
    }
    

    public void Run()
    {
        while(_state != MachineState.Off)
        {
            switch (_state)
            {
                case MachineState.Starting:
                    Console.WriteLine("Welcome to the coffee machine!");

                    _state = MachineState.ChoosingAction;
                    break;
                case MachineState.ChoosingAction:
                    Console.WriteLine("Write action (buy, fill, take, exit):");
                    string? action = Console.ReadLine();
                    switch (action)
                    {
                        case "buy":
                            _state = MachineState.BuyingCoffee;
                            break;
                        case "fill":
                            _state = MachineState.FillingSupplies;
                            break;
                        case "take":
                            _state = MachineState.TakingMoney;
                            break;
                        case "exit":
                            _state = MachineState.Off;
                            break;
                        default:
                            Console.WriteLine("Invalid action. Try again.");
                            break;
                    }
                    break; 
                case MachineState.BuyingCoffee:
                    Console.WriteLine("What do you want to buy? (espresso, latte, cappuccino, back):");

                    string? choice = Console.ReadLine();
                    
                    switch (choice)
                    {
                        case "espresso": 
                            if (HasEnoughResources(CoffeeRecipe.Espresso))
                            {
                                BuyCoffee(CoffeeRecipe.Espresso);
                            }
                            else {Console.WriteLine("Not enough resurces");}
                            break;
                        case "latte":
                            if (HasEnoughResources(CoffeeRecipe.Latte))
                            {
                                BuyCoffee(CoffeeRecipe.Latte);
                            }
                            else { Console.WriteLine("Not enough resurces"); }
                            break;
                        case "cappuccino":
                            if (HasEnoughResources(CoffeeRecipe.Cappuccino))
                            {
                                BuyCoffee(CoffeeRecipe.Cappuccino);
                            }
                            else { Console.WriteLine("Not enough resurces"); }
                            break;
                        case "back":
                            _state = MachineState.ChoosingAction;
                            break;
                        default: Console.WriteLine("Error: enter a valid opcion");
                            break;
                        }
                    break;
                case MachineState.FillingSupplies:
                    Console.WriteLine("How many ml of water to add:");
                    int.TryParse(Console.ReadLine(), out int waterAmount);
                    Water += waterAmount;
                    Console.WriteLine($"added {waterAmount}ml of water");

                    Console.WriteLine("How many ml of milk to add:");
                    int.TryParse(Console.ReadLine(), out int milkAmount);
                    Milk += milkAmount;
                    Console.WriteLine($"added {milkAmount}ml of Milk");

                    Console.WriteLine("How many grams of beans to add:");
                    int.TryParse(Console.ReadLine(), out int beansAmount);
                    Beans += beansAmount;
                    Console.WriteLine($"added {beansAmount}g of beans");

                    _state = MachineState.ChoosingAction;
                    break;
                case MachineState.TakingMoney:
                    Console.WriteLine($"I gave you ${Money}");
                    Money = 0;
                    _state = MachineState.ChoosingAction;
                    break;
            }
        }
    }
}

