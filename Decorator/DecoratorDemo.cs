namespace StructuralPatternsDemo.Decorator;

// Intent: Add behavior to an object dynamically without changing its original class.

public interface ICoffee
{
    string GetDescription();
    decimal GetCost();
}

public sealed class PlainCoffee : ICoffee
{
    public string GetDescription() => "Plain coffee";

    public decimal GetCost() => 2.00m;
}

public abstract class CoffeeDecorator : ICoffee
{
    protected readonly ICoffee Coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        Coffee = coffee;
    }

    public virtual string GetDescription() => Coffee.GetDescription();

    public virtual decimal GetCost() => Coffee.GetCost();
}

public sealed class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription() => $"{Coffee.GetDescription()}, milk";

    public override decimal GetCost() => Coffee.GetCost() + 0.50m;
}

public sealed class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription() => $"{Coffee.GetDescription()}, sugar";

    public override decimal GetCost() => Coffee.GetCost() + 0.25m;
}

public static class DecoratorDemo
{
    public static void Run()
    {
        ICoffee coffee = new PlainCoffee();
        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);

        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine($"Total cost: ${coffee.GetCost()}");
    }
}