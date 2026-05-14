namespace CoffeeMachineSimulator;

public class CoffeeMachine
{
    public int Water {get; private set;}
    public int Milk {get; private set;}
    public int Coffee{ get; private set;}
    public int Money { get; private set; }

    public CoffeeMachine(int water = 400, int milk = 540, int coffee = 120, int money = 550)
    {
        Water = water;
        Coffee = coffee;
        Milk = milk;
        Money = money;
    }

}