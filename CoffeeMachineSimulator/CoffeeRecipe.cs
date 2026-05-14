namespace CoffeeMachineSimulator;

record CoffeeRecipe(int Water, int Milk, int Beans, int Price)
{
    public static readonly CoffeeRecipe Espresso = new(250, 0, 16, 4);
    public static readonly CoffeeRecipe Latte = new(350, 75, 20, 7);
    public static readonly CoffeeRecipe Cappuccino = new(200, 100, 12, 6);
}